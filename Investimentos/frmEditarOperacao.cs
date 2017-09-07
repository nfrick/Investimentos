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

                comboBoxAtivo.DataSource = ctx.Ativos.ToList();
                comboBoxAtivo.DisplayMember = "Codigo";
                comboBoxAtivo.ValueMember = "Codigo";

                comboBoxOperacao.DataSource = ctx.OperacoesTipos.ToList();
                comboBoxOperacao.DisplayMember = "Tipo";
                comboBoxOperacao.ValueMember = "TipoId";

                if (OperacaoId == 0) {
                    dateTimePickerData.Value = DateTime.Now;
                    nudQtdPrevista.Value = 1000;
                    nudQtdReal.Value = 1000;
                }
                else {
                    var operacao = ctx.Operacoes.Find(OperacaoId);
                    comboBoxAtivo.SelectedValue = operacao.Codigo;
                    comboBoxOperacao.SelectedValue = operacao.TipoId;
                    dateTimePickerData.Value = operacao.Data;
                    nudQtdPrevista.Value = operacao.QtdPrevista;
                    nudQtdReal.Value = operacao.QtdReal;
                    nudValor.Value = operacao.Valor;
                    nudValorReal.Value = operacao.ValorReal;
                }
                buttonOK.Enabled = OperacaoId != 0;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                var operacao = OperacaoId == 0 ?
                    new Operacao() : ctx.Operacoes.Find(OperacaoId);
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
    }
}
