using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using System.Text.RegularExpressions;
using TestesWinForm.Properties;
using Tulpep.NotificationWindow;

namespace TestesWinForm {
    public partial class frmTestes : Form {
        public frmTestes() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            textBox2.LostFocus += TextBox2_LostFocus;
        }

        private void TextBox2_LostFocus(object sender, EventArgs e) {

        }

        private void frmTestes_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e) {
            TextBox tb = sender as TextBox;
            tb.Text = tb.Text.Trim();
            if (tb.TextLength > 20) {
                errorProvider1.SetError(tb, "Deve ser menor que 20 caracteres");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e) {
            TextBox tb = sender as TextBox;
            Regex regex = new Regex(@"[A-Z]{4}[0-9]$");
            Match match = regex.Match(tb.Text);
            if (!match.Success) {
                MessageBox.Show("Maiúsculas");
                e.Cancel = true;
            }
        }

        private void frmTestes_Validating(object sender, CancelEventArgs e) {
            MessageBox.Show("Form");
        }

        private void button1_Click(object sender, EventArgs e) {
            var x = "aaaa\nbbbbb" ;
            var popup = new PopupNotifier {
                ContentFont = new Font("Segoe UI", 14),
                TitleFont = new Font("Segoe UI Semibold", 18),
                Image = Resources.alert_icon,
                TitleText = "Alerta de Ações",
                ContentText = $"Ações a serem vendidas:\n\n{x}",
                ContentPadding = new Padding(10),
                TitlePadding = new Padding(10),
                Delay = 10000,
                Size = new Size(450, 200),
                HeaderColor = Color.Red,
                TitleColor = Color.Red                
            };
            popup.Popup();
           
        }
    }
}
