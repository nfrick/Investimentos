using DataLayer;
using GridAndChartStyleLibrary;
using Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Investimentos {

    public enum posicao {
        Papel, Nada, Cotação, VarPercent, QtdComprada, Compra, Venda, QtdVendida, Max, Min, Fech
    }

    public partial class frmInvestimentos : Form {
        private static readonly IFormatProvider FormatPT_BR = new CultureInfo("pt-BR");

        public frmInvestimentos() {
            InitializeComponent();
        }

        private void frmInvestimentos_Load(object sender, EventArgs e) {

            // AÇÕES
            dgvOperacoes.Columns[0].Visible = false;
            dgvVendas.Columns[0].Visible = false;
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleInteger, 60, 1);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleCurrency, 70, 2);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleCurrency, 80, 3);

            GridStyles.FormatGrid(dgvOperacoes);
            dgvOperacoes.Columns[2].Width = 150;
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleDateTimeShort, 75, 1);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleInteger, 60, 3, 4);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleCurrency, 70, 5, 6, 8);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleCurrency, 85, 7);

            GridStyles.FormatGrid(dgvVendas, 13);
            dgvVendas.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleInteger, 75, 2, 3, 4, 6, 7);
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleCurrency, 80, 5, 8, 9, 10);
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleCurrency, 90, 11, 12);

            // FUNDOS
            GridStyles.FormatGrid(dgvFundos);
            GridStyles.FormatColumns(dgvFundos, GridStyles.StyleCurrency, 90, 1);
            GridStyles.FormatColumns(dgvFundos, GridStyles.StyleCurrency, 80, 2);

            GridStyles.FormatGrid(dgvFundosMeses);
            dgvFundosMeses.Columns[0].Width = 85;
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(6), 115, 2);
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(9), 115, 3);
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleCurrency, 85, 1, 4, 5, 6);
            dgvFundosMeses.Columns[1].Width = 95;
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(4), 80, 7, 8, 9);

            GridStyles.FormatGrid(dgvMovimentos);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleCurrency, 90, 2, 3);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleCurrency, 95, 4);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleNumber(6), 105, 5);

            // LCA
            GridStyles.FormatGrid(dgvLCAs);
            dgvLCAs.Columns[0].Width = 70;
            GridStyles.FormatColumns(dgvLCAs, 1, 2, GridStyles.StyleDateShort, 70);
            GridStyles.FormatColumn(dgvLCAs.Columns[3], GridStyles.StyleCurrency, 50);
            GridStyles.FormatColumns(dgvLCAs, GridStyles.StyleCurrency, 80, 4, 6);
            GridStyles.FormatColumn(dgvLCAs.Columns[5], GridStyles.StyleCurrency, 80);
            GridStyles.FormatColumns(dgvLCAs, GridStyles.StylePercent, 60, 7, 8);
            GridStyles.FormatGrid(dgvLCAMeses);
            dgvLCAMeses.Columns[0].Width = 90;
            GridStyles.FormatColumns(dgvLCAMeses, 1, 7, GridStyles.StyleCurrency, 90);
            GridStyles.FormatColumn(dgvLCAMeses.Columns[8], GridStyles.StylePercent, 70);
            GridStyles.FormatGrid(dgvLCAMovimentos);
            GridStyles.FormatColumns(dgvLCAMovimentos, 2, 4, GridStyles.StyleCurrency, 60);
            dgvLCAMovimentos.Columns[1].Width = 100;
            GridStyles.FormatColumn(dgvLCAMovimentos.Columns[5], GridStyles.StyleCurrency, 90);

            // RESUMO
            GridStyles.FormatGrid(dgvResumoAcoes);
            GridStyles.FormatGrid(dgvResumoFundos);
            dgvResumoAcoes.Columns[0].Width = dgvResumoFundos.Columns[0].Width = 130;
            GridStyles.FormatColumns(dgvResumoAcoes, GridStyles.StyleCurrency, 90, 1);
            GridStyles.FormatColumns(dgvResumoFundos, GridStyles.StyleCurrency, 90, 1);
            dgvResumoAcoes.SelectionMode =
            dgvResumoFundos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 50 = vertical scroll bar width
            var w0 = 50 + dgvAtivos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w1 = 50 + dgvOperacoes.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w2 = 50 + dgvVendas.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            tlpAcoes.ColumnStyles[0].Width = w0;
            tlpAcoes.ColumnStyles[1].Width = w1;
            Width = 40 + Math.Max(w0 + w1, w2);
            dgvAtivos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOperacoes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVendas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFundos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFundosMeses.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tlpAcoes.RowStyles[0].Height =
                8 + dgvAtivos.ColumnHeadersHeight + 11 * dgvAtivos.RowTemplate.Height;

            //----------------
            ContaComboPopulate();
            var conta = SettingsManager.GetSetting("Conta");
            toolStripComboBoxConta.SelectedIndex = conta == null ? 0 : int.Parse(conta);
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
            dgvFundosMeses.Refresh();
            dgvMovimentos.Refresh();
            dgvFundos.RestoreCurrentRow(0);
            RefreshSalvar();
        }

        private void RefreshDataLCA() {
            dgvLCAs.SaveCurrentRow();
            entityDataSource1.Refresh();
            dgvLCAMeses.Refresh();
            dgvLCAMovimentos.Refresh();
            dgvLCAs.RestoreCurrentRow(0);
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

        private void dgvOperacoes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
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

        private void dgvVendas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
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
            SettingsManager.SetSetting("Conta", toolStripComboBoxConta.SelectedIndex.ToString());
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
                item.Visible = (tag.Contains(tabLabel));
            }
        }

        private void toolStripButtonLerExtrato_Click(object sender, EventArgs e) {
            ToggleLeitura();
            var tabLabel = tabControl1.SelectedTab.Text;
            if (tabLabel == "Ações") {
                OFD.DefaultExt = "csv";
                OFD.Filter = @"CSV iles|*.csv";
                OFD.Multiselect = false;
            }
            else {
                OFD.DefaultExt = "txt";
                OFD.Filter = @"Text files|*.txt";
                OFD.Multiselect = true;
            }

            if (OFD.ShowDialog() == DialogResult.Cancel) {
                ToggleLeitura();
                return;
            }
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = OFD.FileNames.Length;

            Func<string, int> leitor;
            switch (tabLabel) {
                case "Ações":
                    leitor = LerExtratoAcoes;
                    break;
                case "Fundos":
                    leitor = LerExtratoFundos;
                    break;
                case "LCA":
                    leitor = LerExtratoLCA;
                    break;
                default:
                    ToggleLeitura();
                    return;
            }

            foreach (var file in OFD.FileNames) {
                toolStripProgressBar1.Value += 1;
                toolStripLabelLendoExtrato.Text = $"Lendo extrato: {Path.GetFileName(file)}";
                leitor(file);
            }
            ToggleLeitura();
        }

        private void ToggleLeitura() {
            toolStripButtonLerExtrato.Visible = !toolStripButtonLerExtrato.Visible;
            toolStripLabelLendoExtrato.Visible = !toolStripLabelLendoExtrato.Visible;
            toolStripProgressBar1.Visible = !toolStripProgressBar1.Visible;
            toolStrip1.Refresh();
        }

        private int LerExtratoAcoes(string fileName) {
            var seps = new[] { "\r\n" };
            var readText = File.ReadAllText(fileName);
            var lines = readText.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var ativos = conta.AtivosDaConta;

            foreach (var line in lines) {
                var cotacao = line.Split(';');
                var papel = cotacao[(int)posicao.Papel];
                var ativo = ativos.FirstOrDefault(a => a.Ativo.Codigo == papel);
                if (ativo != null) {
                    ativo.CotacaoAtual = decimal.Parse(cotacao[(int)posicao.Cotação]);
                }
            }
            dgvAtivos.Refresh();
            return 0;
        }

        private static string GetCNPJ(string input) {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        private int LerExtratoFundos(string fileName) {
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var fundos = entityDataSource1.DbContext.Set<Fundo>();

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
                            return 0;
                        } while (!line.Trim().StartsWith("BB"));
                        var fundoCNPJ = GetCNPJ(line.Substring(68, 18).Trim());
                        var fundoNome = line.Substring(0, 40).Trim();

                        // Localiza o Fundo, criando ou atualizando o nome caso necessário
                        var fundo = fundos.Local.FirstOrDefault(f => f.CNPJ == fundoCNPJ);
                        if (fundo == null) {
                            fundo = new Fundo() { Nome = fundoNome, CNPJ = fundoCNPJ };
                            fundos.Add(fundo);
                        }
                        else if (fundo.Nome != fundoNome) {
                            fundo.Nome = fundoNome;
                        }

                        // Localiza a ContaFundo, criando se necessário
                        var contaFundo = conta.Fundos.FirstOrDefault(f => f.FundoCNPJ == fundoCNPJ) ??
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
                            if (!DateTime.TryParse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal,
                                out data)) continue;
                            contaMes.Movimentos.Add(CreateMovimento(line));
                        } while (!(line = GetNextLine(streamReader)).Contains("SALDO ATUAL"));
                        // Adiciona o saldo atual (última linha)
                        contaMes.Movimentos.Add(CreateMovimento(line));
                        contaMes.CotaQtd = contaMes.Movimentos.Last().CotaQtd;

                        // Preenche o mês no Fundo-Mes
                        var mes = DateTime.Parse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal);
                        fundoMes.Mes = mes.AddDays(1 - mes.Day);

                        // Ler até achar o valor anterior da cota
                        do {
                            line = GetNextLine(streamReader);
                        } while (!DateTime.TryParse(line.Substring(0, 10), FormatPT_BR,
                                     DateTimeStyles.AssumeLocal, out data));

                        // Ler até achar o valor atual da cota
                        do {
                            line = GetNextLine(streamReader);
                        } while (!DateTime.TryParse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal, out data));
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

        private int LerExtratoLCA(string fileName) {
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var LCAs = entityDataSource1.DbContext.Set<LCA>();

            const int bufferSize = 128;

            using (var fileStream = File.OpenRead(fileName)) {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, bufferSize)) {

                    string line;
                    // Ler até achar o inicio dos dados
                    line = ReadUntil(streamReader, "NÚMERO");
                    var lcaNumero = line.Substring(18).Trim();

                    // Localiza a LCA, criando se necessário
                    var lca = LCAs.Local.FirstOrDefault(l => l.Numero == lcaNumero);
                    if (lca == null) {
                        lca = new LCA { Numero = lcaNumero, Conta = conta };
                        lca.Aplicacao = DateTime.Parse(GetNextLine(streamReader).Substring(18).Trim(), FormatPT_BR);
                        lca.ValorEmissao = decimal.Parse(GetNextLine(streamReader).Substring(18).Trim(), FormatPT_BR);
                        var saldo = GetNextLine(streamReader);  // skip that line
                        lca.Taxa = decimal.Parse(GetNextLine(streamReader).Substring(18).Trim(), FormatPT_BR);
                        lca.Vencimento = DateTime.Parse(GetNextLine(streamReader).Substring(18).Trim(), FormatPT_BR);
                        LCAs.Add(lca);
                    }

                    // Localiza o mês
                    line = ReadUntil(streamReader, "EXTRATO REF AO MÊS");

                    // Cria o Mes
                    var lcaMes = new LCAMes { LCA = lca, Mes = DateTime.Parse($"01/{line.Substring(18).Trim()}") };
                    lca.LCAMeses.Add(lcaMes);

                    // Ler movimentos
                    do {
                        if (string.IsNullOrEmpty(line)) continue;
                        if (!DateTime.TryParse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal,
                            out DateTime data)) continue;
                        lcaMes.LCAMovimentos.Add(CreateLCAMovimento(line));
                    } while (!(line = GetNextLine(streamReader)).Contains("Saldo Atual"));
                    // Adiciona o saldo atual (última linha)
                    lcaMes.LCAMovimentos.Add(CreateLCAMovimento(line));

                    // Localiza o mês
                    line = ReadUntil(streamReader, "SALDO ANTERIOR");
                    lcaMes.SaldoAnterior = GetValor(line);
                    lcaMes.Aplicacoes = GetValor(streamReader);
                    lcaMes.Resgates = GetValor(streamReader);
                    lcaMes.RendimentoBruto = GetValor(streamReader);
                    lcaMes.ImpostoRenda = GetValor(streamReader);
                    lcaMes.IOF = GetValor(streamReader);
                    lcaMes.RendimentoLiquido = GetValor(streamReader);
                    lcaMes.SaldoAtual = GetValor(streamReader);
                    RefreshDataLCA();
                }
            }
            return 0;
        }

        private static string GetNextLine(TextReader stream) {
            string linha;
            while ((linha = stream.ReadLine().Trim()) == "") ;
            return linha;
        }

        private static string ReadUntil(TextReader stream, string text) {
            string linha;
            while (!(linha = stream.ReadLine().Trim()).Contains(text)) ;
            return linha;
        }

        private static decimal GetValor(TextReader stream) =>
            GetValor(GetNextLine(stream));

        private static decimal GetValor(string linha) {
            var valores = linha.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return decimal.Parse(valores[valores.Length - 1]);
        }

        private static Movimento CreateMovimento(string line) {
            return new Movimento() {
                Data = DateTime.Parse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal),
                Historico = line.Substring(11, 22).Trim().ToLower(),
                Valor = ToDecimal(line, 38, 12),
                ImpostoRenda = ToDecimal(line, 50, 16),
                CotaQtd = ToDecimal(line, 95, 19),
                CotaValor = ToDecimalNull(line, 117, 20)
            };
        }

        private static LCAMovimento CreateLCAMovimento(string line) {
            return new LCAMovimento() {
                Data = DateTime.Parse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal),
                Historico = line.Substring(11, 20).Trim().ToLower(),
                ValorCapital = ToDecimal(line, 38, 11),
                ImpostoRenda = ToDecimal(line, 48, 12),
                IOF = ToDecimal(line, 60, 12),
                Rendimentos = ToDecimal(line, 72, 15),
                ValorMovimento = ToDecimal(line, 88, 16),
                ValorAtual = int.Parse(line.Substring(103, 13)) / 100.0m
            };
        }

        private static decimal ToDecimal(string line, int start, int length) {
            return ToDecimalNull(line, start, length) ?? 0.0m;
        }

        private static decimal? ToDecimalNull(string line, int start, int length) {
            if (start > line.Length) return null;
            if (start + length > line.Length) length = line.Length - start;
            var text = line.Substring(start, length).Trim();
            return decimal.TryParse(text, out decimal valor) ? (decimal?)valor : null;
        }

        private void dgvResumo_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            var dgv = ((DataGridView)sender).Name == "dgvResumoAcoes" ? dgvResumoFundos : dgvResumoAcoes;
            dgv.Columns[e.Column.Index].Width = e.Column.Width;
        }
    }
}
