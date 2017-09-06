using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmConta : Form {
        public int ContaId { get; set; }
        public frmConta() {
            InitializeComponent();
        }

        private void frmConta_Load(object sender, EventArgs e) {
            if (ContaId == 0) return;
            using (var ctx = new InvestimentosEntities()) {
                var conta = ctx.Contas.Find(ContaId);
                textBoxNome.Text = conta.Nome;
                maskedTextBoxAgencia.Text = conta.Agencia;
                maskedTextBoxContaCorrente.Text = conta.ContaCorrente;
                textBoxSenha.Text = conta.Senha;
                textBoxInfo.Text = conta.Info;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            using (var ctx = new InvestimentosEntities()) {
                var conta = ContaId == 0 ? new Conta() : ctx.Contas.Find(ContaId);
                conta.Nome = textBoxNome.Text;
                conta.Agencia = maskedTextBoxAgencia.Text;
                conta.ContaCorrente = maskedTextBoxContaCorrente.Text;
                conta.Senha = textBoxSenha.Text;
                conta.Info = textBoxInfo.Text;
                if (ContaId == 0)
                    ctx.Contas.Add(conta);
                ctx.SaveChanges();
            }
            Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            buttonOK.Enabled = !(string.IsNullOrEmpty(textBoxNome.Text) ||
                string.IsNullOrEmpty(maskedTextBoxAgencia.Text) ||
                string.IsNullOrEmpty(maskedTextBoxContaCorrente.Text) ||
                string.IsNullOrEmpty(textBoxSenha.Text));
        }
    }
}
