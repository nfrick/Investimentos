using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using DataLayer;

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
                nudQtdPrevista.Value = 1000;
                nudQtdReal.Value = 1000;
                Text = @"Nova Operação";
            }
            else {
                comboBoxOperacao.SelectedValue = Operacao.TipoId;
                dateTimePickerData.Value = Operacao.Data;
                nudQtdPrevista.Value = Operacao.QtdPrevista;
                nudQtdReal.Value = Operacao.QtdReal;
                nudValorPrevisto.Value = Operacao.Valor;
                nudValorReal.Value = Operacao.ValorReal;
                nudTaxas.Value = Operacao.Taxas;
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
            Operacao.QtdPrevista = (int)nudQtdPrevista.Value;
            Operacao.QtdReal = (int)nudQtdReal.Value;
            Operacao.Valor = nudValorPrevisto.Value;
            Operacao.ValorReal = nudValorReal.Value;
            Operacao.Taxas = nudTaxas.Value;
            Operacao.Impostos = nudImpostos.Value;
        }

        private void combos_ValueChanged(object sender, EventArgs e) {
            buttonOK.Enabled = (comboBoxAtivo.SelectedValue != null &&
                comboBoxOperacao.SelectedValue != null);
        }

        private void labelQtdReal_Click(object sender, EventArgs e) {
            nudQtdReal.Value = nudQtdPrevista.Value;
        }

        private void labelValorReal_Click(object sender, EventArgs e) {
            nudValorReal.Value = nudValorPrevisto.Value;
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
                    nudValorPrevisto.Value;
            }
            Totais();
        }

        private void nudPrevista_Validated(object sender, EventArgs e) {
            nudQtdReal.Value = nudQtdPrevista.Value;
            nudValorReal.Value = nudValorPrevisto.Value;
            Totais();
        }

        private void Totais() {
            groupBoxPrevisto.Text = $@"Previsto: {nudQtdPrevista.Value * nudValorPrevisto.Value:N2}";
            groupBoxReal.Text = $@"Real: {nudQtdReal.Value * nudValorReal.Value:N2}";
        }
    }
}
