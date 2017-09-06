using System;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmEditarOperacao : Form {
        public int OperacaoId { get; set; }
        public int Conta { get; set; }

        public frmEditarOperacao() {
            InitializeComponent();
        }

        private void EditarOperacao_Load(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                var operacao = OperacaoId == 0 ?
                    new Operacao() { ContaId = Conta } :
                    ctx.Operacoes.Find(OperacaoId);

                comboBoxAtivo.DataSource = ctx.Ativos.ToList();
                comboBoxAtivo.DisplayMember = "Codigo";
                comboBoxAtivo.ValueMember = "Codigo";
                comboBoxAtivo.SelectedValue = operacao.Codigo ?? string.Empty;

                comboBoxOperacao.DataSource = ctx.OperacoesTipos.ToList();
                comboBoxOperacao.DisplayMember = "Tipo";
                comboBoxOperacao.ValueMember = "TipoId";
                comboBoxOperacao.SelectedValue = operacao.TipoId;

                if (OperacaoId == 0) {
                    dateTimePickerData.Value = DateTime.Now;
                    nudQtdPrevista.Value = 1000;
                    nudQtdReal.Value = 1000;
                }
                else {
                    dateTimePickerData.Value = operacao.Data;
                    nudQtdPrevista.Value = operacao.QtdPrevista;
                    nudQtdReal.Value = operacao.QtdReal;
                    nudValor.Value = operacao.Valor;
                    nudValorReal.Value = operacao.ValorReal;
                }
                Totais();
                buttonOK.Enabled = OperacaoId != 0;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                var operacao = OperacaoId == 0 ?
                    new Operacao() { ContaId = Conta } :
                    ctx.Operacoes.Find(OperacaoId);
                operacao.Codigo = (string)comboBoxAtivo.SelectedValue;
                operacao.TipoId = (int)comboBoxOperacao.SelectedValue;
                operacao.Data = dateTimePickerData.Value;
                operacao.QtdPrevista = (int)nudQtdPrevista.Value;
                operacao.QtdReal = (int)nudQtdReal.Value;
                operacao.Valor = nudValor.Value;
                operacao.ValorReal = nudValorReal.Value;

                if (OperacaoId == 0)
                    ctx.Operacoes.Add(operacao);

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
            if (nud.Value == 0 || nud.Text == string.Empty) {
                nud.Value = nud.Name.Contains("Qtd") ?
                    nudQtdPrevista.Value :
                    nudValor.Value;
            }
            Totais();
        }

        private void nudPrevista_Validated(object sender, EventArgs e) {
            Totais();
        }

        private void Totais() {
            groupBoxPrevisto.Text = $@"Previsto: {nudQtdPrevista.Value * nudValor.Value:N2}";
            groupBoxReal.Text = $@"Real: {nudQtdReal.Value * nudValorReal.Value:N2}";
        }
    }
}
