using GridAndChartStyleLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Investimentos {
    public partial class frmVendas : Form {
        public int Conta { get; set; }
        public frmVendas() {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvVendas, 11);
            dgvVendas.Columns[0].Visible = false;
            dgvVendas.Columns[1].Width = 45;
            GridStyles.FormatColumn(dgvVendas.Columns[2], GridStyles.StyleDate, 90);
            GridStyles.FormatColumns(dgvVendas, 3, 8, GridStyles.StyleCurrency, 80);
            GridStyles.FormatColumns(dgvVendas, 9, 10, GridStyles.StyleCurrency, 90);

            GridStyles.FormatGridAsTotal(dgvTotal, dgvVendas);

            var row = (dgvTotal.Rows
                .Cast<DataGridViewRow>()
                .First(r => (int)r.Cells[0].Value == Conta)).Index;
            dgvTotal.CurrentCell = dgvTotal.Rows[row].Cells[10];

            Width = 25 + GridStyles.GridVisibleWidth(dgvVendas);
            Height = dgvVendas.ColumnHeadersHeight +
                     (dgvVendas.Rows.Count * dgvVendas.RowTemplate.Height) +
                     (int)tableLayoutPanel1.RowStyles[1].Height + 48;
        }

        private void dgvVendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView)sender;
            var col = Convert.ToInt32(dgv.Tag);
            if (Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[col].Value) < 0)
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Orange;
        }

        private void dgvContas_SelectionChanged(object sender, EventArgs e) {
            dgvTotal.ClearSelection();
        }

        private void dgvContas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            for (var i = 0; i < e.RowCount; i++) {
                var row = dgvTotal.Rows[e.RowIndex + i];
                row.Cells[8].Value = "TOTAL";
            }
        }
    }
}
