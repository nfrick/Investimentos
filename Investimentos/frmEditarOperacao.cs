using DataLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Investimentos {
    public partial class frmEditarOperacao : Form {
        public Operacao Operacao { get; set; }
        public IBindingList AtivosLista { get; set; }
        public IBindingList TiposLista { get; set; }


        public frmEditarOperacao() {
            InitializeComponent();
        }

        private void EditarOperacao_Load(object sender, EventArgs e) {
            comboBoxAtivo.DataSource = AtivosLista;
            comboBoxAtivo.DisplayMember = "Codigo";
            comboBoxAtivo.ValueMember = "Codigo";

            comboBoxOperacao.DataSource = TiposLista;
            comboBoxOperacao.DisplayMember = "Tipo";
            comboBoxOperacao.ValueMember = "TipoId";

            if (Operacao.OperacaoId == 0) {
                comboBoxOperacao.SelectedIndex = -1;
                buttonOK.Enabled = false;
                Operacao.Codigo = Operacao.AtivoDaConta.Codigo;
                dateTimePickerData.Value = DateTime.Now;
                nudQtd.Value = 1000;
                Text = @"Nova Operação";
            }
            else {
                comboBoxOperacao.SelectedValue = Operacao.TipoId;
                dateTimePickerData.Value = Operacao.Data;
                nudQtd.Value = Operacao.Qtd;
                nudValorNominal.Value = Operacao.Valor;
                nudValorReal.Value = Operacao.ValorReal;
                nudImpostos.Value = Operacao.Impostos;
                Text = @"Editar Operação";
            }
            comboBoxAtivo.SelectedValue = Operacao.Codigo;
            Totais();
            buttonOK.Enabled = Operacao.OperacaoId != 0;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            Operacao.Codigo = (string)comboBoxAtivo.SelectedValue;
            Operacao.OperacaoTipo = (OperacaoTipo)comboBoxOperacao.SelectedItem;
            Operacao.TipoId = (int)comboBoxOperacao.SelectedValue;
            Operacao.Data = dateTimePickerData.Value;
            Operacao.Qtd = (int)nudQtd.Value;
            Operacao.Valor = nudValorNominal.Value;
            Operacao.ValorReal = nudValorReal.Value;
            Operacao.Impostos = nudImpostos.Value;
        }

        private void combos_ValueChanged(object sender, EventArgs e) {
            buttonOK.Enabled = (comboBoxAtivo.SelectedValue != null &&
                comboBoxOperacao.SelectedValue != null);
        }

        private void numericUpDown_Enter(object sender, EventArgs e) {
            var nup = (NumericUpDown)sender;
            nup.Select(0, nup.Text.Length);
        }

        private void nudValor_Validated(object sender, EventArgs e) {
            var nud = (NumericUpDown)sender;
            if (nud.Value == 0 || nud.Text == string.Empty) {
                nud.Value = nudValorNominal.Value;
            }
            Totais();
        }

        private void Totais() {
            textBoxTotalNominal.Text = $@"{nudQtd.Value * nudValorNominal.Value:N2}";
            textBoxTotalReal.Text = $@"{nudQtd.Value * nudValorReal.Value:N2}";
        }
    }
}
