using DataLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Investimentos {
    public partial class frmConta : Form {
        public Conta Conta { get; set; }
        public frmConta() {
            InitializeComponent();
        }

        private void frmConta_Load(object sender, EventArgs e) {
            if (Conta.ContaId == 0) {
                return;
            }

            textBoxNome.Text = Conta.Nome;
            textBoxAgencia.Text = Conta.Agencia;
            textBoxContaCorrente.Text = Conta.ContaCorrente;
            textBoxOperacao.Text = Conta.Operacao;
            textBoxSenha.Text = Conta.Senha;
            textBoxInfo.Text = Conta.Info;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            Conta.Nome = textBoxNome.Text;
            Conta.Agencia = textBoxAgencia.Text;
            Conta.ContaCorrente = textBoxContaCorrente.Text;
            Conta.Operacao = textBoxOperacao.Text;
            Conta.Senha = textBoxSenha.Text;
            Conta.Info = textBoxInfo.Text;
        }

        private void textBoxNome_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            TrimInput(sender);
            e.Cancel = ValidateIsEmpty(sender) || ValidateLargerThan(sender, 10);
            if(!e.Cancel) errorProvider1.Clear();
            EnableOKButton(e.Cancel);
        }

        private void textBoxAgencia_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            TrimInput(sender);
            e.Cancel = ValidateIsEmpty(sender) || 
                ValidateContainsNonDigits(sender) || 
                ValidateLargerThan(sender, 10);
            EnableOKButton(e.Cancel);
        }

        private void textBoxConta_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            TrimInput(sender);
            e.Cancel = ValidateIsEmpty(sender) ||
                       ValidateContainsNonDigits(sender) ||
                       ValidateLargerThan(sender, 15);
            EnableOKButton(e.Cancel);
        }

        private void textBoxOperacao_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            TrimInput(sender);
            e.Cancel = ValidateContainsNonDigits(sender) ||
                       ValidateLargerThan(sender, 3);
            EnableOKButton(e.Cancel);
        }

        private void textBoxSenha_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            TrimInput(sender);
            e.Cancel = ValidateIsEmpty(sender) || 
                       ValidateContainsNonDigits(sender) ||
                       ValidateLargerThan(sender, 8);
            EnableOKButton(e.Cancel);
        }

        private static void TrimInput(object sender) {
            var tb = sender as TextBox;
            tb.Text = tb.Text.Trim();
        }

        private bool ValidateIsEmpty(object sender) {
            var tb = sender as TextBox;

            if (!string.IsNullOrEmpty(tb.Text)) {
                return false;
            }

            errorProvider1.SetError(tb, $"Não pode ficar em branco.");
            return true;
        }

        private bool ValidateLargerThan(object sender, int size) {
            var tb = sender as TextBox;
            if (tb.TextLength <= size) {
                return false;
            }

            errorProvider1.SetError(tb, $"Deve ser menor que {size} caracteres.");
            return true;
        }

        private bool ValidateContainsNonDigits(object sender) {
            var tb = sender as TextBox;
            if (!tb.Text.Any(c => !char.IsDigit(c))) {
                return false;
            }

            errorProvider1.SetError(tb, $"Deve conter apenas dígitos.");
            return true;
        }

        private void EnableOKButton(bool disable) {
            buttonOK.Enabled = !disable;
            if(!disable) errorProvider1.Clear();
        }
    }
}