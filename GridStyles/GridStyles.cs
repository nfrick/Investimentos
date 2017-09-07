using System.Drawing;
using System.Windows.Forms;

namespace GridAndChartStyleLibrary {
    public static class GridStyles {

        private static DataGridViewCellStyle _styleFont = new DataGridViewCellStyle {
            Font = new Font("Segoe UI", 10)
        };

        private static DataGridViewCellStyle _styleHeader = new DataGridViewCellStyle(_styleFont) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            ForeColor = Color.WhiteSmoke,
            BackColor = Color.DimGray,
            WrapMode = DataGridViewTriState.True
        };


        private static DataGridViewCellStyle _styleBase = new DataGridViewCellStyle(_styleFont) {
            ForeColor = Color.LightBlue,
            BackColor = Color.Black,
            SelectionForeColor = Color.Black,
            SelectionBackColor = Color.FromArgb(255, 192, 255, 255)
        };

        private static DataGridViewCellStyle _styleTotal = new DataGridViewCellStyle(_styleFont) {
            ForeColor = Color.LightBlue,
            BackColor = Color.Black,
            SelectionForeColor = Color.LightBlue,
            SelectionBackColor = Color.Black,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };

        private static DataGridViewCellStyle _styleAlternate = new DataGridViewCellStyle() {
            ForeColor = Color.LightGreen,
            BackColor = Color.FromArgb(255, 30, 30, 30)
        };

        private static DataGridViewCellStyle _styleNegative = new DataGridViewCellStyle {
            ForeColor = Color.Red
        };

        private static DataGridViewCellStyle _styleDate = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yyyy"
        };

        private static DataGridViewCellStyle _styleDateTime = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yyyy HH:mm"
        };

        private static DataGridViewCellStyle _styleDayAndTime = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM HH:mm"
        };

        private static DataGridViewCellStyle _styleCurrency = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N2"
        };

        private static DataGridViewCellStyle _styleInteger = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N0"
        };

        private static DataGridViewCellStyle _stylePercent = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = @"0.00%"
        };

        private static DataGridViewCellStyle _styleTrend = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            Font = new Font("Wingdings", 10)
        };

        private static DataGridViewCellStyle _styleTrendAlternate = new DataGridViewCellStyle(_styleAlternate) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            Font = new Font("Wingdings", 10)
        };
        public static DataGridViewCellStyle StyleHeader => _styleHeader;
        public static DataGridViewCellStyle StyleBase => _styleBase;
        public static DataGridViewCellStyle StyleTotal => _styleTotal;
        public static DataGridViewCellStyle StyleAlternate => _styleAlternate;
        public static DataGridViewCellStyle StyleNegative => _styleNegative;
        public static DataGridViewCellStyle StyleDate => _styleDate;
        public static DataGridViewCellStyle StyleDateTime => _styleDateTime;
        public static DataGridViewCellStyle StyleDayAndTime => _styleDayAndTime;
        public static DataGridViewCellStyle StyleCurrency => _styleCurrency;
        public static DataGridViewCellStyle StyleInteger => _styleInteger;
        public static DataGridViewCellStyle StylePercent => _stylePercent;
        public static DataGridViewCellStyle StyleTrend => _styleTrend;
        public static DataGridViewCellStyle StyleTrendAlternate => _styleTrendAlternate;

        public static void FormatGrid(DataGridView dgv, int cols = 0) {
            if (cols > 0) {
                // Remove extra columns that "magically" appears in dgvVendas
                while (dgv.ColumnCount > cols) {
                    dgv.Columns.RemoveAt(dgv.ColumnCount - 1);
                }
            }
            dgv.AlternatingRowsDefaultCellStyle = _styleAlternate;
            dgv.BackgroundColor = Color.Black;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle = _styleHeader;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(255, 64, 64, 64);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle = _styleHeader;
            dgv.RowHeadersWidth = 20;
            dgv.DefaultCellStyle = _styleBase;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn col in dgv.Columns) {
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            }
        }

        public static void FormatColumn(DataGridViewColumn col, DataGridViewCellStyle style, int width) {
            col.DefaultCellStyle = style;
            col.Width = width;
        }

        public static void FormatColumns(DataGridView dgv, int[] cols, DataGridViewCellStyle style) {
            foreach (var col in cols) {
                dgv.Columns[col].DefaultCellStyle = style;
            }
        }

        public static void FormatColumns(DataGridView dgv, int colStart, int colEnd, DataGridViewCellStyle style, int width) {
            colEnd = colEnd == 0 ? dgv.ColumnCount - 1 : colEnd;
            for (int col = colStart; col <= colEnd; col++) {
                FormatColumn(dgv.Columns[col], style, width);
            }
        }

        public static void FormatColumns(DataGridView dgv, int[] cols, DataGridViewCellStyle style, int width) {
            foreach (var col in cols) {
                dgv.Columns[col].DefaultCellStyle = style;
                dgv.Columns[col].Width = width;
            }
        }

        public static void CloneGrid(DataGridView dgv1, DataGridView dgv2) {
            if (dgv1.ColumnCount != dgv2.ColumnCount) return;
            for (var col = 0; col < dgv1.ColumnCount; col++) {
                dgv2.Columns[col].DefaultCellStyle = dgv1.Columns[col].DefaultCellStyle;
                dgv2.Columns[col].Width = dgv1.Columns[col].Width;
                dgv2.Columns[col].AutoSizeMode = dgv1.Columns[col].AutoSizeMode;
                dgv2.Columns[col].Visible = dgv1.Columns[col].Visible;
            }
            dgv2.RowHeadersWidth = dgv1.RowHeadersWidth;
            dgv2.GridColor = dgv1.GridColor;
        }
    }
}
