using DataLayer;
using GridAndChartStyleLibrary;
using Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Investimentos {

    public enum posicao {
        Papel,
        Nada,
        Cotação,
        VarPercent,
        QtdComprada,
        Compra,
        Venda,
        QtdVendida,
        Max,
        Min,
        Fech
    }

    public partial class frmInvestimentos : Form {

        public frmInvestimentos() {
            InitializeComponent();
        }

        #region FORM --------------------------------------------
        private void frmInvestimentos_Load(object sender, EventArgs e) {

            // AÇÕES
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleInteger, 60, 1);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleCurrency, 70, 2);
            GridStyles.FormatColumns(dgvAtivos, GridStyles.StyleCurrency, 80, 3);

            GridStyles.FormatGrid(dgvOperacoes);
            dgvOperacoes.Columns[0].Visible = false;
            //dgvOperacoes.Columns[2].Width = 200;
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleDateTimeShort, 70, 1);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleInteger, 65, 3, 4);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleCurrency, 78, 5, 6, 8);
            GridStyles.FormatColumns(dgvOperacoes, GridStyles.StyleCurrency, 95, 7);

            GridStyles.FormatGrid(dgvVendas, 13);
            dgvVendas.Columns[0].Visible = false;
            dgvVendas.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleInteger, 75, 2, 3, 4, 6, 7);
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleCurrency, 80, 5, 8, 9, 10);
            GridStyles.FormatColumns(dgvVendas, GridStyles.StyleCurrency, 90, 11, 12);

            // FUNDOS
            GridStyles.FormatGrid(dgvFundos);
            GridStyles.FormatColumns(dgvFundos, GridStyles.StyleCurrency, 90, 1);
            GridStyles.FormatColumns(dgvFundos, GridStyles.StyleCurrency, 80, 2);

            GridStyles.FormatGrid(dgvFundosMeses);
            // 0mes, 1saldo, 2qtd cotas, 3valor cota, 4rend bruto, 5ir, 6iof, 7rendliquido, 8rend mes, rend ano, rend12 meses
            dgvFundosMeses.Columns[0].Width = 85;
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleCurrency, 85, 1, 4, 7);
            dgvFundosMeses.Columns[1].Width = 95;
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(6), 115, 2);
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(9), 115, 3);
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleCurrency, 70, 5, 6);
            GridStyles.FormatColumns(dgvFundosMeses, GridStyles.StyleNumber(4), 80, 8, 9, 10);

            //data, historico, valor, IR, IOF, Qtd Cotas, Valor Cota
            GridStyles.FormatGrid(dgvMovimentos);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleCurrency, 90, 2);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleCurrency, 70, 3, 4);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleNumber(4), 100, 5);
            GridStyles.FormatColumns(dgvMovimentos, GridStyles.StyleNumber(6), 100, 6);

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

            // IMPOSTO DE RENDA
            GridStyles.FormatGrid(dgvImpostoRenda);

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
                if (!ctx.Contas.ToList().Any()) {
                    OpenFrmConta(new Conta());
                }
            }
        }

        private void frmInvestimentos_FormClosing(object sender, FormClosingEventArgs e) {
            SettingsManager.SetSetting("Conta", toolStripComboBoxConta.SelectedIndex.ToString());
            var tracker = entityDataSource1.DbContext.ChangeTracker;
            if (!tracker.HasChanges()) {
                return;
            }

            var adds = tracker.Entries().Count(entry => entry.State == EntityState.Added);
            var dels = tracker.Entries().Count(entry => entry.State == EntityState.Deleted);
            var edits = tracker.Entries().Count(entry => entry.State == EntityState.Modified);
            var sb = new StringBuilder("Alterações pendentes:\n\n");
            if (adds > 0) {
                sb.Append($"\t* Adições: {adds}\n");
            }

            if (edits > 0) {
                sb.Append($"\t* Edições: {edits}\n");
            }

            if (dels > 0) {
                sb.Append($"\t* Deleções: {dels}\n");
            }

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
        #endregion FORM -----------------------------------------

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var tabLabel = tabControl1.SelectedTab.Text;
            foreach (ToolStripItem item in toolStrip1.Items) {
                if (item.Tag == null) {
                    continue;
                }
                var tag = item.Tag.ToString();
                item.Visible = tag == "all" || tag.Contains(tabLabel);
            }
        }

        #region DATAGRID GENÉRICAS ----------------------------
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView)sender;
            var col = Convert.ToInt32(dgv.Tag); // coluna com valor que controla a cor
            var row = dgv.Rows[e.RowIndex];
            if (Convert.ToDecimal(row.Cells[col].Value) <= 0) {
                row.DefaultCellStyle.ForeColor = Color.Orange;
            }
        }

        private static void OrderByDate(DataGridView dgv) {
            try {
                if (dgv.RowCount == 0) {
                    return;
                }

                dgv.Sort(dgv.Columns[0], ListSortDirection.Descending);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

        }

        private void ForceRowSelection(DataGridView dgv) {
            // Forces children grids to sort
            if (dgv.Rows.Count < 2) {
                return;
            }

            dgv.Rows[1].Selected = true;
            dgv.Rows[0].Selected = true;
        }

        #endregion DATAGRID GENÉRICAS -------------------------

        #region TAB FUNDOS --------------------------------------------
        private void dgvFundos_SelectionChanged(object sender, EventArgs e) {
            OrderByDate(dgvMovimentos);
            OrderByDate(dgvFundosMeses);
        }

        private void dgvOperacoes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            var op = (Operacao)dgvOperacoes.SelectedRows[0].DataBoundItem;
            var frm = GetFrmEditarOperacao(op);
            if (frm.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            RefreshDataAcoes();
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

        private void RefreshDataFundos() {
            dgvFundos.SaveCurrentRow();
            entityDataSource1.Refresh();
            dgvFundosMeses.Refresh();
            dgvMovimentos.Refresh();
            dgvFundos.RestoreCurrentRow(0);
            RefreshSalvar();
        }
        #endregion TAB FUNDOS -----------------------------------------

        #region TAB AÇÕES --------------------------------------------
        private void dgvAtivos_SelectionChanged(object sender, EventArgs e) {
            OrderByDate(dgvOperacoes);
            OrderByDate(dgvVendas);
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
        #endregion TAB AÇÕES -----------------------------------------

        #region TAB LCA --------------------------------------------
        private void dgvLCAs_SelectionChanged(object sender, EventArgs e) {
            OrderByDate(dgvLCAMeses);
            OrderByDate(dgvLCAMovimentos);
        }

        private void RefreshDataLCA() {
            dgvLCAs.SaveCurrentRow();
            entityDataSource1.Refresh();
            dgvLCAMeses.Refresh();
            dgvLCAMovimentos.Refresh();
            dgvLCAs.RestoreCurrentRow(0);
            RefreshSalvar();
        }

        #endregion TAB LCA -----------------------------------------

        #region TAB RESUMO --------------------------------------------
        private void dgvResumo_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            var dgv = ((DataGridView)sender).Name == "dgvResumoAcoes" ? dgvResumoFundos : dgvResumoAcoes;
            dgv.Columns[e.Column.Index].Width = e.Column.Width;
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
            foreach (var d in data.OrderBy(d => d.Valor)) {
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
            foreach (var d in data.Where(d => d.Valor > 0).OrderByDescending(d => d.Valor)) {
                var serie = chart.Series.Add(d.Item);
                serie.ChartType = SeriesChartType.StackedColumn100;
                serie.Font = new Font("Segoe UI", 7);
                serie.Label = $"{d.Valor / total:P0}";
                serie.Points.AddY((double)d.Valor);
                chart.ApplyPaletteColors();
                serie.LabelForeColor = ColorFunctions.ContrastColor(serie.Color);
            }
        }

        #endregion TAB RESUMO -----------------------------------------

        #region TAB IMPOSTO RENDA --------------------------------------------
        private void nupAno_ValueChanged(object sender, EventArgs e) {
            GetAcoesImpostoRenda();
        }

        private void GetAcoesImpostoRenda() {
            var conta = ((Conta)toolStripComboBoxConta.SelectedItem);
            var IR = conta.ImpostoRenda((int)nupAno.Value);

            dgvImpostoRenda.DataSource = IR;
            dgvImpostoRenda.Columns[0].Width = 70;
            GridStyles.FormatColumn(dgvImpostoRenda.Columns[1], GridStyles.StyleInteger, 60);
            GridStyles.FormatColumn(dgvImpostoRenda.Columns[2], GridStyles.StyleCurrency, 60);
            GridStyles.FormatColumn(dgvImpostoRenda.Columns[3], GridStyles.StyleCurrency, 90);
            labelIRTotal.Text = IR.Sum(t => t.Total).ToString("#,###.00");
        }
        #endregion TAB IMPOSTO RENDA -----------------------------------------

        #region TOOLSTRIP --------------------------------------
        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = ((Conta)toolStripComboBoxConta.SelectedItem);
            var row = (dgvContas.Rows
                .Cast<DataGridViewRow>()
                .First(r => (int)r.Cells[0].Value == conta.ContaId)).Index;
            dgvContas.CurrentCell = dgvContas.Rows[row].Cells[0];

            BindDataSourceAndPopulatePieChart(conta.AtivosNaoZerados, "Ações");
            BindDataSourceAndPopulatePieChart(conta.FundosNaoZerados, "Fundos");
            PopulateColumnChart(conta.PatrimonioTotal, chartResumoTotal);

            nupAno.Value = nupAno.Maximum = nupAno.Minimum = DateTime.Now.Year;
            using (var ctx = new InvestimentosEntities()) {
                var ops = ctx.Operacoes.Where(o => o.ContaId == conta.ContaId);
                nupAno.Minimum = ops.Any() ? ops.Min(o => o.Data.Year) + 1 : DateTime.Now.Year;
            }

            GetAcoesImpostoRenda();
            ForceRowSelection(dgvAtivos);
            ForceRowSelection(dgvFundos);
            ForceRowSelection(dgvLCAs);
        }

        private void ContaComboPopulate() {
            var cbx = toolStripComboBoxConta.ComboBox;
            var currentIndex = cbx.SelectedIndex;
            cbx.DataSource = entityDataSource1.CreateView(entityDataSource1.EntitySets["Contas"]);
            cbx.DisplayMember = "Nome";
            cbx.ValueMember = "ContaId";
            cbx.SelectedIndex = currentIndex == -1 ? 0 : currentIndex;
        }

        #region TOOLSTRIP AÇÕES --------------------------------------
        private void toolStripButtonNovaOperacao_Click(object sender, EventArgs e) {
            var ativo = (AtivoDaConta)dgvAtivos.SelectedRows[0].DataBoundItem;
            var conta = (Conta)dgvContas.CurrentRow.DataBoundItem;
            var op = new Operacao() { AtivoDaConta = ativo, ContaId = conta.ContaId };
            var frm = GetFrmEditarOperacao(op);
            if (frm.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            var row = dgvAtivos.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Codigo"].Value.ToString().Equals(op.Codigo));
            if (row != null) {
                dgvAtivos.Rows[row.Index].Selected = true;
            }

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
        #endregion TOOLSTRIP AÇÕES --------------------------------------

        #region TOOLSTRIP CONTA --------------------------------------
        private void toolStripButtonConta_Click(object sender, EventArgs e) {
            var btn = sender as ToolStripButton;
            OpenFrmConta(btn.Tag.ToString() == "new" ? new Conta() : (Conta)dgvContas.CurrentRow.DataBoundItem);
        }

        private void OpenFrmConta(Conta conta) {
            var frm = new frmConta {
                Conta = conta
            };
            if (frm.ShowDialog() != DialogResult.OK) {
                return;
            }

            if (conta.ContaId == 0) {
                entityDataSource1.DbContext.Set<Conta>().Add(conta);
            }

            RefreshSalvar();
            ContaComboPopulate();
        }
        #endregion TOOLSTRIP CONTA --------------------------------------

        #region TOOLSTRIP SALVAR --------------------------------------
        private void toolStripButtonSalvar_Click(object sender, EventArgs e) {
            entityDataSource1.SaveChanges();
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
        #endregion TOOLSTRIP SALVAR --------------------------------------

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
                OFD.Filter = @"Text files|*.txt|PDF files|*.pdf";
                OFD.Multiselect = true;
            }

            if (OFD.ShowDialog() == DialogResult.Cancel) {
                ToggleLeitura();
                return;
            }
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = OFD.FileNames.Length;

            Action<string> leitor;
            Action refresher = null;
            switch (tabLabel) {
                case "Ações":
                    leitor = LerExtratoAcoes;
                    break;
                case "Fundos":
                    leitor = LerExtratoFundos;
                    refresher = RefreshDataFundos;
                    break;
                case "LCA":
                    leitor = LerExtratoLCA;
                    refresher = RefreshDataLCA;
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

            refresher?.Invoke();
        }

        private void ToggleLeitura() {
            toolStripButtonLerExtrato.Visible = !toolStripButtonLerExtrato.Visible;
            toolStripLabelLendoExtrato.Visible = !toolStripLabelLendoExtrato.Visible;
            toolStripProgressBar1.Visible = !toolStripProgressBar1.Visible;
            toolStrip1.Refresh();
        }

        private void toolStripCopyToClipboard_Click(object sender, EventArgs e) {
            var sb = new StringBuilder();
            var source = (IEnumerable)dgvImpostoRenda.DataSource;
            foreach (sp_SituacaoImpostoRenda_Result item in source) {
                sb.AppendFormat("{0}\t{1}\t{2:#,###.00}\t{3:#,###.00}\n",
                    item.Codigo, item.Qtd, item.Preco, item.Total);
            }
            sb.AppendFormat("TOTAL\t\t{0}", labelIRTotal.Text);
            Clipboard.SetText(sb.ToString());
        }
        #endregion TOOLSTRIP -----------------------------------------------

        #region LEITURA DE EXTRATO --------------------------------------------
        private void LerExtratoAcoes(string filename) {
            var seps = new[] { "\r\n" };
            var readText = File.ReadAllText(filename);
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
        }

        private void LerExtratoFundos(string filename) {
            if (filename.EndsWith("txt")) {
                LerExtratoFundosBB(filename);
            }
            else {
                LerExtratoFundosCEF(filename);
            }
        }

        private bool SelecionaConta(string contacorrente, out Conta conta) {
            conta = toolStripComboBoxConta.Items
                .Cast<Conta>().FirstOrDefault(c => c.ContaCorrente == contacorrente);
            if (conta == null) {
                MessageBox.Show($"Conta {contacorrente} não encontrada.", "Extrato Fundos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            toolStripComboBoxConta.SelectedItem = contacorrente;
            return true;
        }

        private void LerExtratoFundosBB(string filename) {

            var extrato = new ExtratoBBeader(filename);

            if (!SelecionaConta(extrato.ContaCorrente, out Conta conta)) {
                return;
            }

            var fundosNoDatabase = entityDataSource1.DbContext.Set<Fundo>().Local;

            foreach (var fundoNoExtrato in extrato.FundosNoExtrato) {
                var fundo = fundosNoDatabase.FirstOrDefault(f => f.CNPJ == fundoNoExtrato.CNPJ) ??
                            fundoNoExtrato.CreateFundo();
                if (fundo.FundoId == 0) {
                    fundosNoDatabase.Add(fundo);
                }
                else if (fundo.Nome != fundoNoExtrato.Nome) {
                    fundo.Nome = fundoNoExtrato.Nome;
                }

                fundoNoExtrato.UpdateFundoMes(fundo);

                // Localiza a ContaFundo, criando se necessário
                var contaFundo = conta.Fundos.FirstOrDefault(f => f.FundoCNPJ == fundoNoExtrato.CNPJ) ??
                                 new ContaFundo() { Fundo = fundo };
                if (contaFundo.ContaFundoId == 0) {
                    conta.Fundos.Add(contaFundo);
                }

                fundoNoExtrato.UpdateContaMes(contaFundo);
            }
        }

        private void LerExtratoFundosCEF(string filename) {
            var extrato = new ExtratoCEFReader(filename);

            if (!SelecionaConta(extrato.ContaCorrente, out Conta conta)) {
                return;
            }

            var fundosNoDatabase = entityDataSource1.DbContext.Set<Fundo>().Local;

            var fundo = fundosNoDatabase.FirstOrDefault(f => f.CNPJ == extrato.CNPJ) ??
                        extrato.CreateFundo();
            if (fundo.FundoId == 0) {
                fundosNoDatabase.Add(fundo);
            }
            //else if (fundo.Nome != fundoNoExtrato.Nome) {
            //    fundo.Nome = fundoNoExtrato.Nome;
            //}

            extrato.UpdateFundoMes(fundo.Meses.FirstOrDefault(m => m.Mes == extrato.Mes));

            // Localiza a ContaFundo, criando se necessário
            var contaFundo = conta.Fundos.FirstOrDefault(f => f.FundoCNPJ == extrato.CNPJ) ??
                                 new ContaFundo() { Fundo = fundo };
            if (contaFundo.ContaFundoId == 0) {
                conta.Fundos.Add(contaFundo);
            }

            var contaMes = extrato.UpdateContaMes(contaFundo.ContasMeses
                .FirstOrDefault(c => c.Mes == extrato.Mes));
            if (contaMes.ContaMesId == 0) {
                contaFundo.ContasMeses.Add(contaMes);
            }
        }

        private void LerExtratoLCA(string filename) {
            ExtratoLCAReader.LerExtratoLCA(filename, (Conta)toolStripComboBoxConta.SelectedItem, entityDataSource1);
        }
        #endregion LEITURA DE EXTRATO -------------------------------
    }
}