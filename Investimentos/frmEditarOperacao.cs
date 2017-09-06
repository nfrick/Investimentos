using System;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmEditarOperacao : Form {
        public int OperacaoId { get; set; }
        public int Conta { get; set; }
        private Operacao _operacao;

        public frmEditarOperacao() {
            InitializeComponent();
        }

        private void EditarOperacao_Load(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                _operacao = OperacaoId == 0 ?
                    new Operacao() { ContaId = Conta }
                    : ctx.Operacoes.Find(OperacaoId);
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

                nudQtdPrevista.Value = OperacaoId == 0 ? 1000 : _operacao.QtdPrevista;
                nudQtdReal.Value = OperacaoId == 0 ? 1000 : _operacao.QtdReal;
                nudValor.Value = _operacao.Valor;
                nudValorReal.Value = _operacao.ValorReal;

                Totais();

                buttonOK.Enabled = OperacaoId != 0;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            _operacao.Codigo = (string)comboBoxAtivo.SelectedValue;
            _operacao.TipoId = (int)comboBoxOperacao.SelectedValue;
            _operacao.Data = dateTimePickerData.Value;
            _operacao.QtdPrevista = (int)nudQtdPrevista.Value;
            _operacao.QtdReal = (int)nudQtdReal.Value;
            _operacao.Valor = nudValor.Value;
            _operacao.ValorReal = nudValorReal.Value;
            using (var ctx = new InvestimentosEntities()) {
                if (_operacao.OperacaoId == 0)
                    ctx.Operacoes.Add(_operacao);
                ctx.SaveChanges();
            }
            Close();
        }

        private void combos_TextChanged(object sender, EventArgs e) {
            buttonOK.Enabled = (comboBoxAtivo.SelectedValue != null &&
                comboBoxOperacao.SelectedValue != null);
        }

        private void labelQtdReal_Click(object sender, EventArgs e) {
            nudQtdReal.Value = nudQtdPrevista.Value;
        }

        private void labelValorReal_Click(object sender, EventArgs e) {
            nudValorReal.Value = nudValor.Value;
        }

        private void numericUpDown_Enter(object sender, EventArgs e) {
            var nup = (NumericUpDown)sender;
            nup.Select(0, nup.Text.Length);
        }

        private void numericUpDownReal_Validated(object sender, EventArgs e) {
            var nud = (NumericUpDown)sender;
            if (nud.Value != 0 && nud.Text != "") return;
            nud.Value = nud.Name.Contains("Qtd") ?
                nudQtdPrevista.Value :
                nudValor.Value;
            Totais();
        }

        private void nudPrevista_Validated(object sender, EventArgs e) {
            Totais();
        }

        private void Totais() {
            var total = nudQtdPrevista.Value * nudValor.Value;
            labelPrevistoTotal.Text = $@"{total:N2}";
            total = nudQtdReal.Value * nudValorReal.Value;
            labelRealTotal.Text = $@"{total:N2}";

        }
    }
}
