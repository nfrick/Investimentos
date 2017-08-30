using GridAndChartStyleLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Investimentos {
    public partial class frmVendas : Form {
        public frmVendas() {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvVendas);

            dgvVendas.Columns[0].Visible = false;
            dgvVendas.Columns[1].Width = 45;
            dgvVendas.Columns[2].DefaultCellStyle = GridStyles.StyleDate;

            GridStyles.FormatColumns(dgvVendas, 3, 0, GridStyles.StyleCurrency, 60);

            // 50 = vertical scroll bar width
            tableLayoutPanel1.ColumnStyles[2].Width = dgvVendas.Columns[9].Width;
            tableLayoutPanel1.ColumnStyles[3].Width = dgvVendas.Columns[10].Width;
            var w0 = 30 + dgvVendas.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            Width = w0;
        }

        private void dataGridViewVendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView)sender;
            var col = Convert.ToInt32(dgv.Tag);
            dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor =
                (Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[col].Value) < 0) ? Color.LightYellow : Color.LightSkyBlue;
        }

        private void dgvVendas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            double sumLucro = 0;
            double sumLucroReal = 0;
            foreach (DataGridViewRow row in dgvVendas.Rows) {
                sumLucro += Convert.ToDouble(row.Cells[9].Value);
                sumLucroReal += Convert.ToDouble(row.Cells[10].Value);
            }
            labelTotal.Text = sumLucro.ToString("N2");
            labelTotal.ForeColor = sumLucro > 0 ? Color.Blue : Color.Red;
            labelTotalReal.Text = sumLucro.ToString("N2");
            labelTotalReal.ForeColor = sumLucroReal > 0 ? Color.Blue : Color.Red;
        }
    }
}
