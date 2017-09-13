using System;
using System.Linq;
using System.Windows.Forms;
using DataLayer;


namespace Investimentos {
    public partial class frmAssociarCompraComVenda : Form {
        public int VendaId { get; set; }
        public int ContaId { get; set; }
        private Saida _opSaida;
        private readonly InvestimentosEntities _ctx; // Deve ser mantida global; se for aberta com using em CarregarLista dá erro.

        public frmAssociarCompraComVenda() {
            InitializeComponent();
            _ctx = new InvestimentosEntities();
        }
        
        private void AssociarCompraComVenda_Load(object sender, EventArgs e) {
            CarregarLista();
            labelData.Text = _opSaida.Data.ToString("dd/MM/yyyy");
            labelValor.Text = _opSaida.Valor.ToString("C2");
            labelVenda.Text = Math.Abs(_opSaida.QtdReal).ToString();
        }

        private void CarregarLista() {
            //_opSaida = _ctx.Saidas.FirstOrDefault(o => o.SaidaId == VendaId);
            //bindingSourceAssociadas.DataSource = null;
            //bindingSourceAssociadas.DataSource = _opSaida.Associacoes;
            //bindingSourceDisponiveis.DataSource = _ctx.GetComprasDisponiveisParaVenda(VendaId, ContaId);
            //labelAtivo.Text = _opSaida.Codigo;
            //labelAssociacoes.Text = _opSaida.QtdComprada.ToString();
            //labelPendente.Text = _opSaida.QtdPendente.ToString();
            //dgvDisponiveis.Enabled = _opSaida.QtdPendente > 0;
        }

        private void frmAssociarCompraComVenda_FormClosing(object sender, FormClosingEventArgs e) {
            _ctx.Dispose();
        }

        private void dataGridViewAssociadas_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            //var v = _opSaida.Venda.ElementAt(e.RowIndex);
            //if (e.ColumnIndex == 0) {
            //    panelEditarAssociada.Visible = true;
            //    numericUpDownQtdAssociada.Focus();
            //    dgvAssociadas.Enabled = false;
            //    dgvDisponiveis.Enabled = false;
            //    numericUpDownQtdAssociada.Maximum = v.QtdComprada;
            //    numericUpDownQtdAssociada.Value = v.QtdAssociada;
            //}
            //else {
            //    _ctx.Vendas.Remove(v);
            //    FinalizarEdicao(true, null);
            //}
        }

        private void buttonAssociadaEditOK_Click(object sender, EventArgs e) {
            //if (dgvAssociadas.CurrentRow == null) return;
            //var v = _opSaida.Venda.ElementAt(dgvAssociadas.CurrentRow.Index);
            //if (numericUpDownQtdAssociada.Value > 0)
            //    v.QtdAssociada = (int)numericUpDownQtdAssociada.Value;
            //else
            //    _ctx.Vendas.Remove(v);
            //FinalizarEdicao(true, dgvAssociadas);
        }

        private void buttonAssociadaEditCancel_Click(object sender, EventArgs e) {
            FinalizarEdicao(false, dgvAssociadas);
        }

        private void FinalizarEdicao(bool salvarAlteracoes, DataGridView dgv) {
            if (salvarAlteracoes) {
                _ctx.SaveChanges();
                CarregarLista();
            }
            dgvDisponiveis.Refresh();
            if (dgv == null) return;
            dgvAssociadas.Enabled = true;
            dgvDisponiveis.Enabled = true;
            dgv.Focus();
            panelEditarAssociada.Visible = false;
            panelAssociarDisponivel.Visible = false;
        }

        private void dataGridViewDisponiveis_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            //var compra = (CompraDisponivelParaVenda)bindingSourceDisponiveis[dgvDisponiveis.SelectedRows[0].Index];
            //if (e.ColumnIndex == 0) {
            //    AssociarCompraAVenda(compra, 0);
            //    FinalizarEdicao(true, dgvDisponiveis);
            //}
            //else {
            //    labelQtdVendida.Text = Math.Abs(_opSaida.Qtd).ToString();
            //    labelQtdComprada.Text = _opSaida.QtdComprada.ToString();
            //    panelAssociarDisponivel.Visible = true;
            //    numericUpDownQtdAAssociar.Focus();
            //    dgvAssociadas.Enabled = false;
            //    dgvDisponiveis.Enabled = false;
            //    var qtd = Math.Min(_opSaida.QtdPendente, compra.QtdDisponivel);
            //    numericUpDownQtdAAssociar.Maximum = qtd;
            //    numericUpDownQtdAAssociar.Value = qtd;
            //}
        }

        private void AssociarCompraAVenda(CompraDisponivelParaVenda compra, int qtd) {
            //var venda = _opSaida.Venda.FirstOrDefault(v => v.CompraId == compra.OperacaoId);
            //qtd = qtd == 0 ? Math.Min(Math.Abs(_opSaida.Qtd), compra.QtdDisponivel) : qtd;
            //if (venda == null) {
            //    venda = new Venda { CompraId = compra.OperacaoId, QtdAssociada = qtd };
            //    _opSaida.Venda.Add(venda);
            //}
            //else
            //    venda.QtdAssociada += qtd;
        }

        private void buttonAssociarOK_Click(object sender, EventArgs e) {
            var compra = (CompraDisponivelParaVenda)bindingSourceDisponiveis[dgvDisponiveis.SelectedRows[0].Index];
            AssociarCompraAVenda(compra, (int)numericUpDownQtdAAssociar.Value);
            FinalizarEdicao(true, dgvDisponiveis);
        }

        private void numericUpDownQtdAAssociar_ValueChanged(object sender, EventArgs e) {
            //labelSaldo.Text = (_opSaida.QtdPendente - numericUpDownQtdAAssociar.Value).ToString();
        }

        private void buttonAssociarCancel_Click(object sender, EventArgs e) {
            FinalizarEdicao(false, dgvDisponiveis);
        }
    }
}
