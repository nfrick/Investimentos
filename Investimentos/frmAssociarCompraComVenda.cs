using System;
using System.Linq;
using System.Windows.Forms;
using DataLayer;


namespace Investimentos {
    public partial class frmAssociarCompraComVenda : Form {
        public int VendaId { get; set; }
        private OperacaoDeSaida _opSaida;
        private readonly InvestimentosEntities _ctx; // Deve ser mantida global; se for aberta com using em CarregarLista dá erro.

        public frmAssociarCompraComVenda() {
            InitializeComponent();
            _ctx = new InvestimentosEntities();
        }

        private void CarregarLista() {
            _opSaida = _ctx.OperacoesDeSaida.Find(VendaId);
            if (_opSaida == null) return;
            bindingSourceAssociadas.DataSource = _opSaida.Venda;
            bindingSourceDisponiveis.DataSource = _ctx.GetComprasDisponiveisParaVenda(VendaId);
            labelAtivo.Text = _opSaida.Codigo;
            labelData.Text = _opSaida.Data.ToString("dd/MM/yyyy");
            labelValor.Text = _opSaida.Valor.ToString("C2");
            labelVenda.Text = Math.Abs(_opSaida.Qtd).ToString();
            labelAssociacoes.Text = _opSaida.QtdComprada.ToString();
            labelPendente.Text = _opSaida.QtdPendente.ToString();
            dataGridViewDisponiveis.Enabled = _opSaida.QtdPendente > 0;
        }

        private void AssociarCompraComVenda_Load(object sender, EventArgs e) {
            CarregarLista();
        }

        private void frmAssociarCompraComVenda_FormClosing(object sender, FormClosingEventArgs e) {
            _ctx.Dispose();
        }

        private void dataGridViewAssociadas_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var v = _opSaida.Venda.ElementAt(e.RowIndex);
            if (e.ColumnIndex == 0) {
                panelEditarAssociada.Visible = true;
                numericUpDownQtdAssociada.Focus();
                dataGridViewAssociadas.Enabled = false;
                dataGridViewDisponiveis.Enabled = false;
                numericUpDownQtdAssociada.Maximum = v.QtdComprada;
                numericUpDownQtdAssociada.Value = v.QtdAssociada;
            }
            else {
                _ctx.Vendas.Remove(v);
                FinalizarEdicao(true, null);
            }
        }

        private void buttonAssociadaEditOK_Click(object sender, EventArgs e) {
            if (dataGridViewAssociadas.CurrentRow == null) return;
            var v = _opSaida.Venda.ElementAt(dataGridViewAssociadas.CurrentRow.Index);
            if (numericUpDownQtdAssociada.Value > 0)
                v.QtdAssociada = (int)numericUpDownQtdAssociada.Value;
            else
                _ctx.Vendas.Remove(v);
            FinalizarEdicao(true, dataGridViewAssociadas);
        }

        private void buttonAssociadaEditCancel_Click(object sender, EventArgs e) {
            FinalizarEdicao(false, dataGridViewAssociadas);
        }

        private void FinalizarEdicao(bool salvarAlteracoes, DataGridView dgv) {
            if (salvarAlteracoes) {
                _ctx.SaveChanges();
                CarregarLista();
            }
            if (dgv == null) return;
            dataGridViewAssociadas.Enabled = true;
            dataGridViewDisponiveis.Enabled = true;
            dgv.Focus();
            panelEditarAssociada.Visible = false;
            panelAssociarDisponivel.Visible = false;
        }

        private void dataGridViewDisponiveis_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var compra = (CompraDisponivelParaVenda)bindingSourceDisponiveis[dataGridViewDisponiveis.SelectedRows[0].Index];
            if (e.ColumnIndex == 0) {
                AssociarCompraAVenda(compra, 0);
                FinalizarEdicao(true, dataGridViewDisponiveis);
            }
            else {
                labelQtdVendida.Text = Math.Abs(_opSaida.Qtd).ToString();
                labelQtdComprada.Text = _opSaida.QtdComprada.ToString();
                panelAssociarDisponivel.Visible = true;
                numericUpDownQtdAAssociar.Focus();
                dataGridViewAssociadas.Enabled = false;
                dataGridViewDisponiveis.Enabled = false;
                var qtd = Math.Min(_opSaida.QtdPendente, compra.QtdDisponivel);
                numericUpDownQtdAAssociar.Maximum = qtd;
                numericUpDownQtdAAssociar.Value = qtd;
            }
        }

        private void AssociarCompraAVenda(CompraDisponivelParaVenda compra, int qtd) {
            var venda = _opSaida.Venda.FirstOrDefault(v => v.CompraId == compra.OperacaoId);
            qtd = qtd == 0 ? Math.Min(Math.Abs(_opSaida.Qtd), compra.QtdDisponivel) : qtd;
            if (venda == null) {
                venda = new Venda { CompraId = compra.OperacaoId };
                _opSaida.Venda.Add(venda);
            }
            venda.QtdAssociada += qtd;
        }

        private void buttonAssociarOK_Click(object sender, EventArgs e) {
            var compra = (CompraDisponivelParaVenda)bindingSourceDisponiveis[dataGridViewDisponiveis.SelectedRows[0].Index];
            AssociarCompraAVenda(compra, (int)numericUpDownQtdAAssociar.Value);
            FinalizarEdicao(true, dataGridViewDisponiveis);
        }

        private void numericUpDownQtdAAssociar_ValueChanged(object sender, EventArgs e) {
            labelSaldo.Text = (_opSaida.QtdPendente - numericUpDownQtdAAssociar.Value).ToString();
        }

        private void buttonAssociarCancel_Click(object sender, EventArgs e) {
            FinalizarEdicao(false, dataGridViewDisponiveis);
        }
    }
}
