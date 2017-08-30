using System;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmEditarOperacao : Form {
        public int OperacaoId { get; set; }
        private Operacao _operacao;

        public frmEditarOperacao() {
            InitializeComponent();
        }

        private void EditarOperacao_Load(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                _operacao = OperacaoId == 0 ? new Operacao() : ctx.Operacoes.Find(OperacaoId);
                comboBoxAtivo.DataSource = ctx.Ativos.ToList();
                comboBoxAtivo.DisplayMember = "Codigo";
                comboBoxAtivo.ValueMember = "Codigo";
                comboBoxAtivo.SelectedValue = _operacao.Codigo ?? string.Empty;

                comboBoxOperacao.DataSource = ctx.OperacoesTipos.ToList();
                comboBoxOperacao.DisplayMember = "Tipo";
                comboBoxOperacao.ValueMember = "TipoId";
                comboBoxOperacao.SelectedValue = _operacao.TipoId;

                dateTimePickerData.Value = OperacaoId == 0 ?
                    DateTime.Now : _operacao.Data;

                numericUpDownQtdPrevista.Value = OperacaoId == 0 ? 100 : _operacao.QtdPrevista;
                numericUpDownQtdReal.Value = OperacaoId == 0 ? 100 : _operacao.QtdReal;
                numericUpDownValor.Value = _operacao.Valor;
                numericUpDownValorReal.Value = _operacao.ValorReal;

                buttonOK.Enabled = OperacaoId != 0;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            _operacao.Codigo = (string)comboBoxAtivo.SelectedValue;
            _operacao.TipoId = (int)comboBoxOperacao.SelectedValue;
            _operacao.Data = dateTimePickerData.Value;
            _operacao.QtdPrevista = (int)numericUpDownQtdPrevista.Value;
            _operacao.QtdReal = (int)numericUpDownQtdReal.Value;
            _operacao.Valor = numericUpDownValor.Value;
            _operacao.ValorReal = numericUpDownValorReal.Value;
            using (var ctx = new InvestimentosEntities()) {
                ctx.SaveChanges();
            }
            Close();
        }

        private void combos_TextChanged(object sender, EventArgs e) {
            buttonOK.Enabled = (comboBoxAtivo.SelectedValue != null &&
                comboBoxOperacao.SelectedValue != null);
        }

        private void labelQtdReal_Click(object sender, EventArgs e) {
            numericUpDownQtdReal.Value = numericUpDownQtdPrevista.Value;
        }

        private void labelValorReal_Click(object sender, EventArgs e) {
            numericUpDownValorReal.Value = numericUpDownValor.Value;
        }
    }
}
