using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using EFWinforms;

namespace Investimentos {
    public partial class frmInvestimentos : Form {
        public frmInvestimentos() {
            InitializeComponent();
        }

        private void frmInvestimentos_Load(object sender, EventArgs e) {
            dgvOperacoes.Columns[0].Visible = false;
            dgvVendas.Columns[0].Visible = false;
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatColumn(dgvAtivos.Columns[1], GridStyles.StyleInteger, 70);
            GridStyles.FormatColumns(dgvAtivos, 2, 0, GridStyles.StyleCurrency, 70);

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
            GridStyles.FormatGrid(dgvResultados);

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
            //var ctx = entityDataSource1.DbContext.Set<Associacao>();
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

        private void toolStripButtonNovoFundo_Click(object sender, EventArgs e) {
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var fundos = entityDataSource1.DbContext.Set<Fundo>().ToList();
            var disponiveis = fundos.Where(f => conta.ContasFundos.All(cf => cf.FundoId != f.FundoId));
            toolStripComboBoxFundos.ComboBox.DataSource = disponiveis.ToList();
            toolStripComboBoxFundos.ComboBox.DisplayMember = "Nome";
            toolStripComboBoxFundos.ComboBox.ValueMember = "FundoId";
            NovoFundoEnable(true);
            toolStripComboBoxFundos.Focus();
        }

        private void toolStripButtonFundoSalvarCancelar_Click(object sender, EventArgs e) {
            NovoFundoEnable(false);
            if (((ToolStripButton)sender).Name == "toolStripButtonFundoCancelar")
                return;
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var novoFundo = new ContaFundo() { Fundo = (Fundo)toolStripComboBoxFundos.SelectedItem };
            conta.ContasFundos.Add(novoFundo);
            RefreshDataFundos();
        }

        private void NovoFundoEnable(bool enable) {
            toolStripLabelNovoFundo.Visible = enable;
            toolStripComboBoxFundos.Visible = enable;
            toolStripButtonFundoSalvar.Visible = enable;
            toolStripButtonFundoCancelar.Visible = enable;
            tabControl1.Enabled = !enable;
            toolStripButtonNovoFundo.Visible = !enable;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var tab = tabControl1.SelectedTab.Text;
            foreach (ToolStripItem item in toolStrip1.Items) {
                if (item.Tag == null) continue;
                item.Visible = (item.Tag.ToString() == tab);
            }
        }

        private void toolStripButtonLerExtrato_Click(object sender, EventArgs e) {
            var conta = (Conta)toolStripComboBoxConta.SelectedItem;
            var fundos = entityDataSource1.DbContext.Set<Fundo>().ToList();

            IFormatProvider format = new CultureInfo("pt-BR");
            const string fileName = @"D:\investimentos.txt";
            const int bufferSize = 128;

            using (var fileStream = File.OpenRead(fileName)) {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, bufferSize)) {
                    do {
                        string line;
                        do {
                            // Ler até achar o inicio dos dados do Fundo
                            line = streamReader.ReadLine();
                            if (line != null) continue;
                            RefreshDataFundos();
                            return;
                        } while (!line.Trim().StartsWith("BB"));
                        var fundoNome = line.Substring(0, 30).Trim();

                        var fundo = fundos.FirstOrDefault(f => f.Nome == fundoNome) ?? new Fundo() { Nome = fundoNome, CNPJ = line.Substring(68, 18).Replace(".", "").Replace("/", "").Replace("-", "") };
                        if(fundo.FundoId == 0)
                            fundos.Add(fundo);

                        var contaFundo = conta.ContasFundos.FirstOrDefault(c => c.Fundo.Nome == fundoNome) ??
                            new ContaFundo() { Conta = conta, Fundo = fundo };
                        if (contaFundo.ContaFundoId == 0)
                            conta.ContasFundos.Add(contaFundo);

                        var resultado = new Resultado() { ContaFundo = contaFundo };

                        // Mover até inicio dos Movimentos
                        do {
                            // nothing
                        } while (!(line = streamReader.ReadLine().Trim()).Contains("SALDO ANTERIOR"));

                        // Ler movimentos
                        DateTime data;
                        while (!(line = streamReader.ReadLine().Trim()).Contains("SALDO ATUAL")) {
                            if (string.IsNullOrEmpty(line)) continue;
                            if (!DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal,
                                out data)) continue;
                            var mov = line.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            var size = mov.Length;
                            var movimento = new Movimento() {
                                Data = data,
                                Historico = mov[1],
                                Valor = decimal.Parse(mov[2]),
                                ImpostoRenda = decimal.Parse(mov[size - 3]),
                                CotaQtd = decimal.Parse(mov[size - 2]),
                                CotaValor = decimal.Parse(mov[size - 1])
                            };
                            resultado.Movimentos.Add(movimento);
                        }
                        resultado.Mes = DateTime.Parse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal);
                        resultado.Mes = resultado.Mes.AddDays(-1 * resultado.Mes.Day + 1);

                        // Ler até achar o novo anterior da cota
                        do {
                            line = streamReader.ReadLine().Trim();
                        } while (string.IsNullOrEmpty(line) || !DateTime.TryParse(line.Substring(0, 10), format,
                                     DateTimeStyles.AssumeLocal, out data));

                        // Ler até achar o novo atual da cota
                        do {
                            line = streamReader.ReadLine().Trim();
                            if (string.IsNullOrEmpty(line)) continue;
                        } while (string.IsNullOrEmpty(line) || !DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal, out data));

                        resultado.CotaValor = GetValor(line);

                        // Mover até inicio dos rendimentos
                        do {
                            line = streamReader.ReadLine().Trim();
                        } while (line == string.Empty || !line.StartsWith("No mês:"));

                        resultado.RendimentoMes = GetValor(line);
                        resultado.RendimentoAno = GetValor(streamReader);
                        resultado.Rendimento12Meses = GetValor(streamReader);

                        contaFundo.Resultados.Add(resultado);

                    } while (true);
                }
            }
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
    }
}
