using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Investimentos {
    public partial class frmInvestimentos : Form {
        public frmInvestimentos() {
            InitializeComponent();
        }

        private void frmInvestimentos_Load(object sender, EventArgs e) {
            dgvOperacoes.Columns[0].Visible = false;
            dgvVendas.Columns[0].Visible = false;
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatColumn(dgvAtivos.Columns[1], GridStyles.StyleInteger, 60);
            GridStyles.FormatColumn(dgvAtivos.Columns[2], GridStyles.StyleCurrency, 70);
            GridStyles.FormatColumn(dgvAtivos.Columns[3], GridStyles.StyleCurrency, 80);
            //GridStyles.FormatColumns(dgvAtivos, 2, 0, GridStyles.StyleCurrency, 70);

            GridStyles.FormatGrid(dgvOperacoes);
            dgvOperacoes.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvOperacoes, 3, 4, GridStyles.StyleInteger, 70);
            GridStyles.FormatColumns(dgvOperacoes, 5, 6, GridStyles.StyleCurrency, 70);

            GridStyles.FormatGrid(dgvVendas, 14);
            dgvVendas.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvVendas, new[] { 2, 3, 4, 6, 7 }, GridStyles.StyleInteger, 69);
            GridStyles.FormatColumns(dgvVendas, new[] { 5, 8, 9, 10 }, GridStyles.StyleCurrency, 70);
            GridStyles.FormatColumns(dgvVendas, new[] { 11, 12 }, GridStyles.StyleCurrency, 85);

            GridStyles.FormatGrid(dgvFundos);
            GridStyles.FormatColumn(dgvFundos.Columns[1], GridStyles.StyleCurrency, 90);

            GridStyles.FormatGrid(dgvResultados);
            dgvResultados.Columns[0].Width = 75;
            GridStyles.FormatColumn(dgvResultados.Columns[2], GridStyles.StyleNumber(6), 110);
            GridStyles.FormatColumn(dgvResultados.Columns[3], GridStyles.StyleNumber(9), 110);
            GridStyles.FormatColumns(dgvResultados, new[] { 1, 4, 5, 6 }, GridStyles.StyleCurrency, 80);
            dgvResultados.Columns[1].Width = 90;
            GridStyles.FormatColumns(dgvResultados, new[] { 7, 8, 9 }, GridStyles.StyleNumber(4), 75);

            GridStyles.FormatGrid(dgvMovimentos);
            GridStyles.FormatColumns(dgvMovimentos, new[] { 2, 3 }, GridStyles.StyleCurrency, 80);
            GridStyles.FormatColumn(dgvMovimentos.Columns[4], GridStyles.StyleCurrency, 90);
            GridStyles.FormatColumn(dgvMovimentos.Columns[5], GridStyles.StyleNumber(6), 100);

            GridStyles.FormatGrid(dgvResumoAcoes);
            GridStyles.FormatGrid(dgvResumoFundos);
            dgvResumoAcoes.Columns[0].Width = 130;
            GridStyles.FormatColumn(dgvResumoAcoes.Columns[1], GridStyles.StyleCurrency, 90);
            GridStyles.FormatColumn(dgvResumoFundos.Columns[1], GridStyles.StyleCurrency, 90);
            dgvResumoAcoes.SelectionMode = 
            dgvResumoFundos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 50 = vertical scroll bar width
            var w0 = 50 + dgvAtivos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w1 = 50 + dgvOperacoes.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w2 = 50 + dgvVendas.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            tableLayoutPanelAcoes.ColumnStyles[0].Width = w0;
            tableLayoutPanelAcoes.ColumnStyles[1].Width = w1;
            Width = 10 + Math.Max(w0 + w1, w2);

            tableLayoutPanelAcoes.RowStyles[0].Height =
                8 + dgvAtivos.ColumnHeadersHeight + 11 * dgvAtivos.RowTemplate.Height;

            //----------------
            ContaComboPopulate();
            using (var ctx = new InvestimentosEntities()) {
                if (!ctx.Contas.ToList().Any())
                    OpenFrmConta(new Conta());
            }
        }

        private void RefreshDataAcoes() {
            dgvAtivos.SaveCurrentRow();
            dgvOperacoes.SaveCurrentRow();
            dgvVendas.SaveCurrentRow();
            entityDataSource1.Refresh();
            dgvAtivos.RestoreCurrentRow(0);
            dgvOperacoes.RestoreCurrentRow(1);
            dgvVendas.RestoreCurrentRow(1);
            RefreshSalvar();
        }

        private void RefreshDataFundos() {
            dgvFundos.SaveCurrentRow();
            entityDataSource1.Refresh();
            dgvResultados.Refresh();
            dgvMovimentos.Refresh();
            dgvFundos.RestoreCurrentRow(0);
            RefreshSalvar();
        }

        private void RefreshSalvar() {
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            toolStripButtonSalvar.Visible = tracker.HasChanges();
            toolStripSeparatorSalvar.Visible = tracker.HasChanges();

            var alts = tracker.Entries().Count(entry => entry.State == EntityState.Added ||
                                                        entry.State == EntityState.Deleted ||
                                                        entry.State == EntityState.Modified);

            toolStripButtonSalvar.Text = $" Salvar {alts} alteraç" + (alts == 1 ? "ão" : "ões");
        }

        private void dataGridViewOperacoes_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var op = (Operacao)dgvOperacoes.SelectedRows[0].DataBoundItem;
            var frm = GetFrmEditarOperacao(op);
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            RefreshDataAcoes();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView)sender;
            var col = Convert.ToInt32(dgv.Tag); // coluna com valor que controla a cor
            var row = dgv.Rows[e.RowIndex];
            if (Convert.ToDecimal(row.Cells[col].Value) <= 0)
                row.DefaultCellStyle.ForeColor = Color.Orange;
        }

        private void dataGridViewVendas_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var frm = new frmAssociarCompraComVenda {
                Saida = (Saida)dgvVendas.SelectedRows[0].DataBoundItem,
                eds = entityDataSource1
            };
            frm.ShowDialog();
            RefreshDataAcoes();
        }

        private frmEditarOperacao GetFrmEditarOperacao(Operacao op) {
            var ativos = entityDataSource1.CreateView(entityDataSource1.EntitySets["Ativos"]);
            var tipos = entityDataSource1.CreateView(entityDataSource1.EntitySets["OperacoesTipos"]);
            var frm = new frmEditarOperacao { Operacao = op, AtivosLista = ativos, TiposLista = tipos };
            return frm;
        }

        #region toolstrip
        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = ((Conta)toolStripComboBoxConta.SelectedItem);
            var row = (dgvContas.Rows
                .Cast<DataGridViewRow>()
                .First(r => (int)r.Cells[0].Value == conta.ContaId)).Index;
            dgvContas.CurrentCell = dgvContas.Rows[row].Cells[0];

            BindDataSourceAndPopulatePieChart(conta.AtivosNaoZerados, "Ações");
            BindDataSourceAndPopulatePieChart(conta.FundosNaoZerados, "Fundos");
            PopulateColumnChart(conta.PatrimonioTotal, chartResumoTotal);
        }

        private void BindDataSourceAndPopulatePieChart(IEnumerable<Patrimonio> data,
            string fonte) {
            var bs = fonte == "Ações" ? bindingSourceAcoes : bindingSourceFundos;
            var dgv = fonte == "Ações" ? dgvResumoAcoes : dgvResumoFundos;
            var chart = fonte == "Ações" ? chartResumoAcoes : chartResumoFundos;
            if (!data.Any()) {
                dgv.Visible = chart.Visible = false;
                return;
            }
            bs.DataSource = data;
            dgv.Visible = chart.Visible = true;
            chart.Series.Clear();
            var total = data.Sum(d => d.Valor);
            chart.Titles[0].Text = $"{fonte}: {total:N2}";
            var serie = chart.Series.Add("AAA");
            serie.ChartType = SeriesChartType.Pie;
            serie.Font = new Font("Segoe UI", 7);
            foreach (var d in data) {
                var dp = serie.Points.Add((double)d.Valor);
                dp.LegendText = d.Item;
                dp.AxisLabel = $"{d.Valor / total:P0}";
                chart.ApplyPaletteColors();
                dp.LabelForeColor = ColorFunctions.ContrastColor(dp.Color);
            }
        }

        private void PopulateColumnChart(IEnumerable<Patrimonio> data, Chart chart) {
            chart.Series.Clear();
            if (!data.Any()) {
                chart.Visible = false;
                return;
            }
            chart.Visible = true;
            var total = data.Sum(d => d.Valor);
            chart.Titles[0].Text = $"Total: {total:N2}";
            foreach (var d in data) {
                var serie = chart.Series.Add(d.Item);
                serie.ChartType = SeriesChartType.StackedColumn100;
                serie.Font = new Font("Segoe UI", 7);
                serie.Label = $"{d.Valor / total:P0}";
                serie.Points.AddY((double)d.Valor);
                chart.ApplyPaletteColors();
                serie.LabelForeColor = ColorFunctions.ContrastColor(serie.Color);
            }
        }

        private void ContaComboPopulate() {
            var cbx = toolStripComboBoxConta.ComboBox;
            var currentIndex = cbx.SelectedIndex;
            cbx.DataSource = entityDataSource1.CreateView(entityDataSource1.EntitySets["Contas"]);
            cbx.DisplayMember = "Nome";
            cbx.ValueMember = "ContaId";
            cbx.SelectedIndex = currentIndex == -1 ? 0 : currentIndex;
        }

        private void toolStripButtonNovaOperacao_Click(object sender, EventArgs e) {
            var ativo = (AtivoDaConta)dgvAtivos.SelectedRows[0].DataBoundItem;
            var conta = (Conta)dgvContas.CurrentRow.DataBoundItem;
            var op = new Operacao() { AtivoDaConta = ativo, ContaId = conta.ContaId };
            var frm = GetFrmEditarOperacao(op);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            var row = dgvAtivos.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Codigo"].Value.ToString().Equals(op.Codigo));
            if (row != null)
                dgvAtivos.Rows[row.Index].Selected = true;

            var tipo = (OperacaoTipo)frm.comboBoxOperacao.SelectedItem;
            var operacoes = entityDataSource1.DbContext.Set<Operacao>();
            if (tipo.IsEntrada) {
                operacoes.Add(op.ToEntrada);
            }
            else {
                operacoes.Add(op.ToSaida);
            }
            RefreshDataAcoes();
        }

        private void toolStripButtonResumoVendas_Click(object sender, EventArgs e) {
            var frm = new frmBalanco() { Conta = ((Conta)dgvContas.CurrentRow.DataBoundItem).ContaId };
            frm.ShowDialog();
        }

        private void toolStripButtonConta_Click(object sender, EventArgs e) {
            var btn = sender as ToolStripButton;
            OpenFrmConta(btn.Tag.ToString() == "new" ? new Conta() : (Conta)dgvContas.CurrentRow.DataBoundItem);
        }

        private void OpenFrmConta(Conta conta) {
            var frm = new frmConta {
                Conta = conta
            };
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (conta.ContaId == 0)
                entityDataSource1.DbContext.Set<Conta>().Add(conta);

            RefreshSalvar();
            ContaComboPopulate();
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            entityDataSource1.SaveChanges();
            RefreshSalvar();
        }

        #endregion

        private void frmInvestimentos_FormClosing(object sender, FormClosingEventArgs e) {
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            if (!tracker.HasChanges()) return;
            var adds = tracker.Entries().Count(entry => entry.State == EntityState.Added);
            var dels = tracker.Entries().Count(entry => entry.State == EntityState.Deleted);
            var edits = tracker.Entries().Count(entry => entry.State == EntityState.Modified);
            var sb = new StringBuilder("Alterações pendentes:\n\n");
            if (adds > 0) sb.Append($"\t* Adições: {adds}\n");
            if (edits > 0) sb.Append($"\t* Edições: {edits}\n");
            if (dels > 0) sb.Append($"\t* Deleções: {dels}\n");
            sb.Append("\nDeseja salvar antes de sair?");
            switch (MessageBox.Show(sb.ToString(), @"Investimentos", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    entityDataSource1.SaveChanges();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    break; // do nothing
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var tabLabel = tabControl1.SelectedTab.Text;
            foreach (ToolStripItem item in toolStrip1.Items) {
                if (item.Tag == null) continue;
                var tag = item.Tag.ToString();
                if (tag == "Fundos" || tag == "Ações")
                    item.Visible = (tag == tabLabel);
            }
        }

        private void toolStripButtonLerExtrato_Click(object sender, EventArgs e) {
            toolStripButtonLerExtrato.Visible = false;
            toolStripLabelLendoExtrato.Visible = true;
            if (OFD.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (var file in OFD.FileNames) {
                toolStripLabelLendoExtrato.Text = $"Lendo extrato: {Path.GetFileName(file)}";
                LerExtrato(file);
            }
            toolStripButtonLerExtrato.Visible = true;
            toolStripLabelLendoExtrato.Visible = false;
        }

        private void LerExtrato(string fileName) {
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var fundos = entityDataSource1.DbContext.Set<Fundo>();

            IFormatProvider format = new CultureInfo("pt-BR");
            const int bufferSize = 128;

            using (var fileStream = File.OpenRead(fileName)) {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, bufferSize)) {
                    do {
                        string line;
                        do {
                            // Ler até achar o inicio dos dados do Fundo ou achar o fim do arquivo
                            line = streamReader.ReadLine();
                            if (line != null) continue;
                            RefreshDataFundos();
                            return;
                        } while (!line.Trim().StartsWith("BB"));
                        var fundoNome = line.Substring(0, 35).Trim();

                        // Localiza o Fundo, criando se necessário
                        var fundo = fundos.Local.FirstOrDefault(f => f.Nome == fundoNome);
                        if (fundo == null) {
                            fundo = new Fundo() { Nome = fundoNome, CNPJ = line.Substring(68, 18).Replace(".", "").Replace("/", "").Replace("-", "") };
                            fundos.Add(fundo);
                        }

                        // Localiza a ContaFundo, criando se necessário
                        var contaFundo = conta.Fundos.FirstOrDefault(f => f.FundoNome == fundoNome) ??
                            new ContaFundo() { Fundo = fundo };
                        if (contaFundo.ContaFundoId == 0)
                            conta.Fundos.Add(contaFundo);

                        // Mover até inicio dos Movimentos
                        do {
                            // nothing
                        } while (!(line = GetNextLine(streamReader)).Contains("SALDO ANTERIOR"));

                        // Cria o Fundo-Mes
                        var fundoMes = new FundoMes() { Fundo = fundo };
                        fundo.Meses.Add(fundoMes);

                        // Cria o Conta-Mes
                        var contaMes = new ContaMes() { ContaFundo = contaFundo, FundoMes = fundoMes };

                        // Ler movimentos
                        DateTime data;
                        do {
                            //if (string.IsNullOrEmpty(line)) continue;
                            if (!DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal,
                                out data)) continue;
                            contaMes.Movimentos.Add(CreateMovimento(line, format));
                        } while (!(line = GetNextLine(streamReader)).Contains("SALDO ATUAL"));
                        // Adiciona o saldo atual (última linha)
                        contaMes.Movimentos.Add(CreateMovimento(line, format));
                        contaMes.CotaQtd = contaMes.Movimentos.Last().CotaQtd;

                        // Preenche o mês no Fundo-Mes
                        var mes = DateTime.Parse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal);
                        fundoMes.Mes = mes.AddDays(1 - mes.Day);

                        // Ler até achar o valor anterior da cota
                        do {
                            line = GetNextLine(streamReader);
                        } while (!DateTime.TryParse(line.Substring(0, 10), format,
                                     DateTimeStyles.AssumeLocal, out data));

                        // Ler até achar o valor atual da cota
                        do {
                            line = GetNextLine(streamReader);
                        } while (!DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal, out data));
                        fundoMes.CotaValor = GetValor(line);

                        // Mover até inicio dos rendimentos
                        do {
                        } while (!(line = GetNextLine(streamReader)).StartsWith("No mês:"));

                        fundoMes.RendimentoMes = GetValor(line);
                        fundoMes.RendimentoAno = GetValor(streamReader);
                        fundoMes.Rendimento12Meses = GetValor(streamReader);

                        // Mover até o rendimento bruto
                        do {
                        } while (!(line = GetNextLine(streamReader)).StartsWith("RENDIMENTO BRUTO"));
                        contaMes.RendimentoBruto = GetValor(line);

                        contaFundo.ContasMeses.Add(contaMes);

                    } while (true);
                }
            }
        }

        private static string GetNextLine(TextReader s) {
            string line;
            do {
                line = s.ReadLine().Trim();
            } while (line == string.Empty);
            return line;
        }

        private static Movimento CreateMovimento(string line, IFormatProvider format) {
            return new Movimento() {
                Data = DateTime.Parse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal),
                Historico = line.Substring(11, 20).Trim().ToLower(),
                Valor = ToDecimal(line, 38, 11),
                ImpostoRenda = ToDecimal(line, 50, 16),
                CotaQtd = ToDecimal(line, 95, 18),
                CotaValor = ToDecimalNull(line, 117, 20)
            };
        }

        private static decimal ToDecimal(string line, int start, int length) {
            return ToDecimalNull(line, start, length) ?? 0.0m;
        }

        private static decimal? ToDecimalNull(string line, int start, int length) {
            if (start > line.Length || start + length > line.Length) return null;
            var text = line.Substring(start, length).Trim();
            return decimal.TryParse(text, out decimal valor) ? (decimal?)valor : null;
        }

        private static decimal GetValor(TextReader stream) {
            string linha;
            while ((linha = stream.ReadLine().Trim()) == "") ;
            return GetValor(linha);
        }

        private static decimal GetValor(string linha) {
            var valores = linha.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return decimal.Parse(valores[valores.Length - 1]);
        }

        private void dgvResumo_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            var dgv = ((DataGridView)sender).Name == "dgvResumoAcoes" ? dgvResumoFundos : dgvResumoAcoes;
            dgv.Columns[e.Column.Index].Width = e.Column.Width;
        }
    }
}
