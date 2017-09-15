using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmConta : Form {
        public Conta Conta { get; set; }
        public frmConta() {
            InitializeComponent();
        }

        private void frmConta_Load(object sender, EventArgs e) {
            if (Conta.ContaId == 0) return;
            textBoxNome.Text = Conta.Nome;
            maskedTextBoxAgencia.Text = Conta.Agencia;
            maskedTextBoxContaCorrente.Text = Conta.ContaCorrente;
            textBoxSenha.Text = Conta.Senha;
            textBoxInfo.Text = Conta.Info;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            Conta.Nome = textBoxNome.Text;
            Conta.Agencia = maskedTextBoxAgencia.Text;
            Conta.ContaCorrente = maskedTextBoxContaCorrente.Text;
            Conta.Senha = textBoxSenha.Text;
            Conta.Info = textBoxInfo.Text;
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            buttonOK.Enabled = !(string.IsNullOrEmpty(textBoxNome.Text) ||
                string.IsNullOrEmpty(maskedTextBoxAgencia.Text) ||
                string.IsNullOrEmpty(maskedTextBoxContaCorrente.Text) ||
                string.IsNullOrEmpty(textBoxSenha.Text));
        }
    }
}
