﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DataLayer;
using GridAndChartStyleLibrary;

namespace Cotacoes {
    public partial class frmCotacoes : Form {
        private bool _precisaCarregarListaDeAtivos = true;
        private System.Threading.Timer _updateTimer;

        public frmCotacoes() {
            InitializeComponent();
        }

        private void frmCotacoes_Load(object sender, EventArgs e) {
            InitializeDataGrid();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor =
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = dgvCotacoes.GridColor;

            var cbx = toolStripComboBoxConta.ComboBox;
            using (var ctx = new InvestimentosEntities()) {
                cbx.Items.AddRange(ctx.Contas.OrderBy(c => c.Nome).ToArray());
            }
            cbx.DisplayMember = "Nome";
            cbx.ValueMember = "ContaId";
            cbx.SelectedIndex = 0;

            Width = 25 + GridStyles.GridVisibleWidth(dgvCotacoes);
        }

        private void frmCotacoes_Resize(object sender, EventArgs e) {
            if (WindowState != FormWindowState.Minimized) return;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);
            ShowInTaskbar = false;
        }

        #region Timer
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (DesignMode) return;
            var agora = DateTime.Now;
            if (toolStripMenuItemDesligado.Checked)
                CarregarDados();
            else if (agora.Hour < 10 || agora.Hour > 17 ||
                     agora.DayOfWeek == DayOfWeek.Saturday ||
                     agora.DayOfWeek == DayOfWeek.Sunday) {
                DefinirFrequencia(toolStripMenuItemDesligado);
                CarregarDados();
            }
            else
                DefinirFrequencia(toolStripMenuItem5segundos);
        }

        private void AtualizarDados(object state) {
            // do your stuff here
            try {
                YahooFinance.AtualizarCotacoes();
                ResultadoAtualizacao = true;
            }
            catch (WebException) {
                ResultadoAtualizacao = false;
            }
            // do not access control directly, use BeginInvoke!
        }

        private bool ResultadoAtualizacao {
            set {
                if (InvokeRequired) {
                    BeginInvoke(new Action(() => {
                        CarregarDados();
                        if (!value) {
                            Erros++;
                            // PerguntarSobreFrequencia();
                        }
                        else if (DateTime.Now.Hour >= 17 && DateTime.Now.Minute >= 12)
                            DefinirFrequencia(toolStripMenuItemDesligado);
                    }));
                }
            }
        }

        public int Erros { get; set; }

        private void PerguntarSobreFrequencia() {
            AjustarTimer(0);
            if (MessageBox.Show(@"Erro ao acessar Yahoo Finance. Suspender acesso?",
                @"Cotações", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                DefinirFrequencia();
            else
                DefinirFrequencia(toolStripMenuItemDesligado);
        }
        #endregion Timer

        private void InitializeDataGrid() {
            GridStyles.FormatGrid(dgvCotacoes);
            GridStyles.FormatColumns(dgvCotacoes, 5, 0, GridStyles.StyleCurrency, 65);
            GridStyles.FormatColumns(dgvCotacoes, new[] { 2, 16, 18 }, GridStyles.StyleCurrency, 85);
            GridStyles.FormatColumns(dgvCotacoes, new[] { 1, 17 }, GridStyles.StyleInteger, 65);
            GridStyles.FormatColumn(dgvCotacoes.Columns[3], GridStyles.StyleDayAndTime, 90);
            GridStyles.FormatColumn(dgvCotacoes.Columns[4], GridStyles.StyleTrend, 20);
            GridStyles.FormatColumn(dgvCotacoes.Columns[9], GridStyles.StylePercent, 65);

            GridStyles.FormatGridAsTotal(dgvTotal, dgvCotacoes);

            foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems)
                i.Click += FrequenciaButtonsClick;
            foreach (ToolStripItem i in toolStripDropDownButtonAtivos.DropDownItems)
                i.Click += AtivosButtonsClick;
        }

        private void CarregarDados() {
            AtualizarGrafico(false);
            if (_precisaCarregarListaDeAtivos) {
                List<AtivoCotacao> ativos;
                switch (toolStripDropDownButtonAtivos.Text) {
                    case "Ativos Correntes":
                        ativos = YahooFinance.AtivosParaExibicao(AtivosTipos.Correntes);
                        break;
                    case "Já Negociados":
                        ativos = YahooFinance.AtivosParaExibicao(AtivosTipos.JaNegociados);
                        break;
                    default:
                        ativos = YahooFinance.AtivosParaExibicao(AtivosTipos.Todos);
                        break;
                }
                bindingSourceCotacoes.DataSource = ativos;
                _precisaCarregarListaDeAtivos = false;
            }
            else
                dgvCotacoes.Refresh();

            var total = AtivoCotacaoTotal.New((List<AtivoCotacao>)bindingSourceCotacoes.DataSource);
            bindingSourceTotal.DataSource = total;

            toolStripStatusLabelAtualizadoEm.Text = $@"Atualizado em: {DateTime.Now}";
            toolStripStatusLabelErros.Text = $@"Erros: {Erros}";

            // Resize if number of Ativos changes
            var oldHeight = (int)tableLayoutPanel1.RowStyles[0].Height;
            var newHeight = dgvCotacoes.ColumnHeadersHeight +
                (dgvCotacoes.RowTemplate.Height + 2) *
                Math.Min(10, bindingSourceCotacoes.Count);

            if (oldHeight == newHeight) return;
            tableLayoutPanel1.RowStyles[0].Height = newHeight;
            Height = Height - oldHeight + newHeight;
        }

        private void AtualizarGrafico(bool forcePack) {
            chart1.Series.Clear();
            if (dgvCotacoes.SelectedRows.Count == 0)
                return;

            double chartMax = 0;
            double chartMin = 1000;
            foreach (DataGridViewRow row in dgvCotacoes.SelectedRows) {
                var ativo = YahooFinance.AtivoPorCodigo((string)row.Cells[0].Value);
                ativo.AtualizarCotacao();
                if (!ativo.HasTrades) continue;
                ativo.PackTrades(forcePack);
                var serie = chart1.Series.Add(row.Cells[0].Value.ToString());
                serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                foreach (var trade in ativo.Cotacoes) {
                    serie.Points.AddXY(trade.Key, trade.Value.close);
                }
                //serie.Points.AddXY(ativo.LastTradeDate, ativo.LastTrade);
                chartMax = Math.Max(chartMax, ativo.MaxTrade);
                chartMin = Math.Min(chartMin, ativo.MinTrade);
            }
            ChartMinMax.ChartSetYAxisMinMax(chart1, chartMin, chartMax);
        }

        private void FrequenciaButtonsClick(object sender, EventArgs e) {
            DefinirFrequencia((ToolStripMenuItem)sender);
        }

        /// <summary>
        /// Acerta a frequencia para o valor selecionado no menu
        /// </summary>
        private void DefinirFrequencia() {
            foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems)
                if (i is ToolStripMenuItem && ((ToolStripMenuItem)i).Checked)
                    DefinirFrequencia((ToolStripMenuItem)i);
        }

        /// <summary>
        /// Acerta a frequencia para o valor do botão indicado
        /// </summary>
        /// <param name="botao">Botão a ser selecionado</param>
        private void DefinirFrequencia(ToolStripMenuItem botao) {
            foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems)
                if (i is ToolStripMenuItem)
                    ((ToolStripMenuItem)i).Checked = (i == botao);
            AjustarTimer(Convert.ToInt32(botao.Tag));
            toolStripDropDownButtonFrequencia.Text = $@"Frequência: {botao.Text}";
            if ((string)botao.Tag == "0")
                AtualizarGrafico(true);
        }

        private void AjustarTimer(int period) {
            period = period == 0 ? Timeout.Infinite : period * 1000;
            var dueTime = period == Timeout.Infinite ? Timeout.Infinite : 0;
            if (_updateTimer == null)
                _updateTimer = new System.Threading.Timer(AtualizarDados, null, dueTime, period);
            else
                _updateTimer.Change(dueTime, period);
        }

        private void AtivosButtonsClick(object sender, EventArgs e) {
            var senderButton = (ToolStripMenuItem)sender;
            foreach (ToolStripItem i in toolStripDropDownButtonAtivos.DropDownItems) {
                if (i is ToolStripMenuItem item) {
                    item.Checked = (i == senderButton);
                }
            }
            toolStripDropDownButtonAtivos.Text = senderButton.Text;
            _precisaCarregarListaDeAtivos = true;
        }

        private void dgvCotacoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var cell = dgvCotacoes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var forecolor = e.RowIndex % 2 == 0 ? dgvCotacoes.DefaultCellStyle.ForeColor : dgvCotacoes.AlternatingRowsDefaultCellStyle.ForeColor;
            if (e.ColumnIndex == 4) {
                var s = cell.Value as string;
                cell.Style.ForeColor = s == AtivoCotacao.TrendUp ? Color.LightGreen : (s == AtivoCotacao.TrendDown ? Color.OrangeRed : Color.Gray);
            }
            else if (e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 16)
                cell.Style.ForeColor = Convert.ToDecimal(cell.Value) < 0 ? Color.OrangeRed : forecolor;
        }

        private void dgvCotacoes_SelectionChanged(object sender, EventArgs e) {
            AtualizarGrafico(false);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void dgvTotal_SelectionChanged(object sender, EventArgs e) {
            dgvTotal.ClearSelection();
        }

        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = (Conta)((ToolStripComboBox)sender).SelectedItem;
            if (!YahooFinance.Initialize(conta.ContaId)) {
                PerguntarSobreFrequencia();
            }
            _precisaCarregarListaDeAtivos = true;
            CarregarDados();
        }

        private void dgvCotacoes_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            if (dgvTotal.ColumnCount > 0)
                dgvTotal.Columns[e.Column.Index].Width = e.Column.Width;
        }
    }
}
