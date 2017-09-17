using GridAndChartStyleLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Investimentos {
    public partial class frmBalanco : Form {
        public int Conta { get; set; }
        public frmBalanco() {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvVendas, 9);
            dgvVendas.Columns[0].Width = 90;
            GridStyles.FormatColumn(dgvVendas.Columns[1], GridStyles.StyleDate, 90);
            GridStyles.FormatColumns(dgvVendas, 2, 3, GridStyles.StyleInteger, 80);
            GridStyles.FormatColumns(dgvVendas, 4, 6, GridStyles.StyleCurrency, 80);
            GridStyles.FormatColumns(dgvVendas, 7, 8, GridStyles.StyleCurrency, 90);

            GridStyles.FormatGridAsTotal(dgvTotal, dgvVendas);

            var row = (dgvTotal.Rows
                .Cast<DataGridViewRow>()
                .First(r => (int)r.Cells[0].Value == Conta)).Index;
            dgvTotal.CurrentCell = dgvTotal.Rows[row].Cells[1];

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
                row.Cells[6].Value = "TOTAL";
            }
        }
    }
}
