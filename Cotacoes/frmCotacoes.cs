using Cotacoes.Properties;
using DataLayer;
using GridAndChartStyleLibrary;
using Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tulpep.NotificationWindow;

namespace Cotacoes {
    public partial class frmCotacoes : Form {
        private System.Threading.Timer _updateTimer;

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        #region FORM
        public frmCotacoes() {
            InitializeComponent();

            var cbx = toolStripComboBoxConta.ComboBox;
            using (var ctx = new InvestimentosEntities()) {
                cbx.Items.AddRange(ctx.Contas.OrderBy(c => c.Nome).ToArray());
            }
            cbx.DisplayMember = "Nome";
            cbx.ValueMember = "ContaId";
            var conta = SettingsManager.GetSetting("Conta");
            cbx.SelectedIndex = conta == null ? 0 : int.Parse(conta);
        }

        private void frmCotacoes_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvCotacoes);
            dgvCotacoes.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            //0    Ativo
            //1    Data
            //2    seta
            //3    Last Trade
            //4    prev Close
            //5    Change %
            //6    Open
            //7    Day Low
            //8    Day High
            //9    Qtd Total
            //10   Patrimonio*
            //11   VM Compra
            //12   Lucro real*
            //13   Qtd vendavel
            //14   Lucro imediato*

            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StyleDayAndTime, 100, 1);
            dgvCotacoes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StyleTrend, 20, 2);
            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StylePercent, 65, 5);
            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StyleInteger, 65, 9, 13);
            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StyleCurrency, 80, 3, 4, 6, 7, 8, 11);
            GridStyles.FormatColumns(dgvCotacoes, GridStyles.StyleCurrency, 85, 10, 12, 14);

            GridStyles.FormatGridAsTotal(dgvTotal, dgvCotacoes);

            foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems) {
                i.Click += FrequenciaButtonsClick;
            }

            foreach (ToolStripItem i in toolStripDropDownButtonAtivos.DropDownItems) {
                i.Click += AtivosButtonsClick;
            }

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor =
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = dgvCotacoes.GridColor;
            Width = 25 + GridStyles.GridVisibleWidth(dgvCotacoes);
        }

        private void frmCotacoes_Resize(object sender, EventArgs e) {
            if (WindowState != FormWindowState.Minimized) {
                return;
            }

            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);
            ShowInTaskbar = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void frmCotacoes_FormClosing(object sender, FormClosingEventArgs e) {
            SettingsManager.SetSetting("Conta", toolStripComboBoxConta.SelectedIndex.ToString());
        }
        #endregion FORM

        #region TIMER
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (DesignMode) {
                return;
            }

            var agora = DateTime.Now;
            if (toolStripMenuItemDesligado.Checked ||
                     agora.Hour < 10 || agora.Hour > 17 ||
                     agora.DayOfWeek == DayOfWeek.Saturday ||
                     agora.DayOfWeek == DayOfWeek.Sunday) {
                DefinirFrequencia(toolStripMenuItemDesligado);
                CarregarDados(true);
            }
            else {
                DefinirFrequencia(toolStripMenuItem5minutos);
            }
        }

        private void AtualizarDados(object state) {
            // do your stuff here
            try {
                var ativos = (List<AtivoCotacao>)bindingSourceCotacoes.DataSource;
                Parallel.ForEach(ativos, (ativo) => {
                    ativo.AtualizarCotacao();
                });
                ResultadoAtualizacao = true;
            }
            catch (Exception) {
                ResultadoAtualizacao = false;
            }
            // do not access control directly, use BeginInvoke!
        }

        public int Erros { get; set; }

        private bool ResultadoAtualizacao {
            set {
                if (InvokeRequired) {
                    BeginInvoke(new Action(() => {
                        CarregarDados();
                        if (!value) {
                            Erros++;
                        }
                        else if (DateTime.Now.Hour >= 17 && DateTime.Now.Minute >= 12) {
                            DefinirFrequencia(toolStripMenuItemDesligado);
                        }
                    }));
                }
            }
        }

        private void PerguntarSobreFrequencia() {
            AjustarTimer(0);
            if (MessageBox.Show(@"Erro ao atualizar cotações. Suspender acesso?",
                @"Cotações", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No) {
                DefinirFrequencia();
            }
            else {
                DefinirFrequencia(toolStripMenuItemDesligado);
            }
        }

        /// <summary>
        /// Acerta a frequencia para o valor do botão indicado
        /// </summary>
        /// <param name="botao">Botão a ser selecionado</param>
        private void DefinirFrequencia(ToolStripMenuItem botao = null) {
            if (botao == null) {
                foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems) {
                    if (i is ToolStripMenuItem && ((ToolStripMenuItem)i).Checked) {
                        botao = (ToolStripMenuItem)i;
                    }
                }
            }

            foreach (ToolStripItem i in toolStripDropDownButtonFrequencia.DropDownItems) {
                if (i is ToolStripMenuItem) {
                    ((ToolStripMenuItem)i).Checked = (i == botao);
                }
            }

            AjustarTimer(Convert.ToInt32(botao.Tag));
            toolStripDropDownButtonFrequencia.Text = $@"Frequência: {botao.Text}";
            if ((string)botao.Tag == "0") {
                AtualizarGrafico();
            }
        }

        private void AjustarTimer(int period) {
            period = period == 0 ? Timeout.Infinite : period * 60 * 1000;
            var dueTime = period == Timeout.Infinite ? Timeout.Infinite : 0;
            if (_updateTimer == null) {
                _updateTimer = new System.Threading.Timer(AtualizarDados, null, dueTime, period);
            }
            else {
                _updateTimer.Change(dueTime, period);
            }
        }

        #endregion TIMER

        #region DADOS E ATUALIZAÇÕES
        private void CarregarDados(bool recarregarListaDeAtivos = false) {
            if (recarregarListaDeAtivos) {
                bindingSourceCotacoes.DataSource = AtivosEmExibicao();
            }
            else {
                dgvCotacoes.Refresh();
            }

            AtualizarGrafico();

            var total = AtivoCotacaoTotal.New((List<AtivoCotacao>)bindingSourceCotacoes.DataSource);
            bindingSourceTotal.DataSource = total;

            toolStripStatusLabelAtualizadoEm.Text = $@"Atualizado em: {DateTime.Now}";
            toolStripStatusLabelErros.Text = $@"Erros: {Erros}";

            // Resize if number of Ativos changes
            var oldHeight = (int)tableLayoutPanel1.RowStyles[0].Height;
            var newHeight = dgvCotacoes.ColumnHeadersHeight +
                (dgvCotacoes.RowTemplate.Height + 2) *
                Math.Min(10, bindingSourceCotacoes.Count);

            var y = AtivosEmExibicao();
            if (y.Any(a => a.AlertaVenda >= 1.00m && a.AlertaVenda < 1.004m)) {
                var x = y.Where(a => a.AlertaVenda > 1.00m && a.AlertaVenda < 1.004m)
                    .Select(a => $"{a.Codigo} - Compra: {a.ValorMedioCompra:c2} - Atual: {a.LastTrade:c2}");
                var popup = new PopupNotifier {
                    Size = new Size(450, 75 * x.Count()),
                    Delay = 10000,
                    Image = Resources.alert_icon,
                    HeaderColor = Color.Red,
                    TitleColor = Color.Red,
                    TitleFont = new Font("Segoe UI Semibold", 18),
                    TitlePadding = new Padding(10),
                    TitleText = "Alerta de Venda de Ações",
                    ContentFont = new Font("Segoe UI", 14),
                    ContentText = x.Aggregate((current, next) => current + "\n" + next),
                    ContentPadding = new Padding(10)
                };
                popup.Popup();
            }

            if (oldHeight == newHeight) {
                return;
            }

            tableLayoutPanel1.RowStyles[0].Height = newHeight;
            Height = Height - oldHeight + newHeight;
        }

        private List<AtivoCotacao> AtivosEmExibicao() {
            var opcao = AtivosTipos.Correntes;
            foreach (ToolStripItem i in toolStripDropDownButtonAtivos.DropDownItems) {
                if (!(i is ToolStripMenuItem item) || !item.Checked) {
                    continue;
                }

                opcao = (AtivosTipos)int.Parse((string)i.Tag);
                break;
            }
            return FinanceData.AtivosParaExibicao(opcao);
        }

        private void AtualizarGrafico() {
            chart1.Series.Clear();
            //if (dgvCotacoes.SelectedRows.Count == 0)
            //    return;

            double chartMax = 0;
            double chartMin = 1000;

            if (dgvCotacoes.SelectedRows.Count == 0) {
                foreach (DataGridViewCell cell in dgvCotacoes.SelectedCells) {
                    AtualizarGraficoAcao(cell.OwningRow, ref chartMin, ref chartMax);
                }
            }
            else {
                foreach (DataGridViewRow row in dgvCotacoes.SelectedRows) {
                    AtualizarGraficoAcao(row, ref chartMin, ref chartMax);
                }
            }

            ChartMinMax.ChartSetYAxisMinMax(chart1, chartMin, chartMax);
        }

        private void AtualizarGraficoAcao(DataGridViewRow row, ref double chartMin, ref double chartMax) {
            var codigo = row.Cells[0].Value.ToString();
            var ativo = FinanceData.AtivoPorCodigo(codigo);
            if (!ativo.HasTrades) {
                ativo.AtualizarCotacao();
            }

            var serie = chart1.Series.Add(codigo);
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            foreach (var trade in ativo.Cotacoes) {
                serie.Points.AddXY(trade.Key, trade.Value.close);
            }
            chartMax = Math.Max(chartMax, ativo.DayHigh);
            chartMin = Math.Min(chartMin, ativo.DayLow);
        }

        private void FrequenciaButtonsClick(object sender, EventArgs e) {
            DefinirFrequencia((ToolStripMenuItem)sender);
        }
        #endregion DADOS E ATUALIZAÇÕES

        #region TOOLBAR
        private void AtivosButtonsClick(object sender, EventArgs e) {
            var senderButton = (ToolStripMenuItem)sender;
            foreach (ToolStripItem i in toolStripDropDownButtonAtivos.DropDownItems) {
                if (i is ToolStripMenuItem item) {
                    item.Checked = (i == senderButton);
                }
            }
            toolStripDropDownButtonAtivos.Text = senderButton.Text;
            CarregarDados(true);
        }

        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = (Conta)((ToolStripComboBox)sender).SelectedItem;
            if (!FinanceData.Initialize(conta.ContaId)) {
                PerguntarSobreFrequencia();
            }
            CarregarDados(true);
        }

        private void toolStripButtonAtualizar_Click(object sender, EventArgs e) {
            List<AtivoCotacao> ativos;
            var botao = (ToolStripButton)sender;
            botao.Enabled = false;

            if (botao.Name.Contains("Todos")) {
                ativos = (List<AtivoCotacao>)bindingSourceCotacoes.DataSource;
            }
            else {
                ativos = new List<AtivoCotacao>();
                ativos.AddRange(from DataGridViewRow row in dgvCotacoes.SelectedRows
                                select FinanceData.AtivoPorCodigo((string)row.Cells[0].Value));
            }
            Parallel.ForEach(ativos, (ativo) => {
                ativo.AtualizarCotacao();
            });
            CarregarDados();
            botao.Enabled = true;
        }

        private void toolStripButtonLerExtrato_Click(object sender, EventArgs e) {
            OFD.DefaultExt = "csv";
            OFD.Filter = @"CSV iles|*.csv";
            OFD.Multiselect = true;
            if (OFD.ShowDialog() != DialogResult.OK) {
                return;
            }

            foreach (var fileName in OFD.FileNames) {
                FinanceData.AtualizarPorExtrato(fileName);
            }
        }

        #endregion TOOLBAR

        #region DATAGRIDVIEW
        private void dgvCotacoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var acao = (AtivoCotacao)dgvCotacoes.Rows[e.RowIndex].DataBoundItem;
            var cell = dgvCotacoes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var forecolor = e.RowIndex % 2 == 0 ? dgvCotacoes.DefaultCellStyle.ForeColor : dgvCotacoes.AlternatingRowsDefaultCellStyle.ForeColor;
            switch (e.ColumnIndex) {
                case 2: // Trend
                    var s = cell.Value as string;
                    cell.Style.ForeColor = s == AtivoCotacao.TrendUp ? Color.LightGreen : (s == AtivoCotacao.TrendDown ? Color.OrangeRed : Color.Gray);
                    break;
                case 3 when acao.AlertaVenda < 1.004m: // Last Trade
                    cell.Style.ForeColor = Color.White;
                    cell.Style.BackColor = acao.AlertaVenda < 1.002m ? Color.Tomato : Color.Goldenrod;
                    break;
                case 5: // Change %
                case 12: // Lucro Real
                    cell.Style.ForeColor = Convert.ToDecimal(cell.Value) < 0 ? Color.OrangeRed : forecolor;
                    break;
            }
        }

        private void dgvCotacoes_SelectionChanged(object sender, EventArgs e) {
            AtualizarGrafico();
        }

        private void dgvTotal_SelectionChanged(object sender, EventArgs e) {
            dgvTotal.ClearSelection();
        }

        private void dgvCotacoes_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            if (dgvTotal.ColumnCount > 0) {
                dgvTotal.Columns[e.Column.Index].Width = e.Column.Width;
            }
        }

        private void dgvCotacoes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            AtualizarGrafico();
        }

        #endregion DATAGRIDVIEW

        private void chart1_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;

            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                ChartElementType.DataPoint);  //.PlottingArea);
            foreach (var result in results) {
                if (result.ChartElementType != ChartElementType.DataPoint) continue;
                var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                var hora = (new DateTime(1899, 12, 31)).AddDays(xVal).ToString("hh:mm");

                tooltip.Show($"{hora} - {yVal:C2}", this.chart1, pos.X, pos.Y - 15);
            }
        }
    }
}
