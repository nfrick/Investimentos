using System.Drawing;
using System.Linq;
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
            ForeColor = Color.White,
            BackColor = Color.Black,
            SelectionForeColor = Color.White,
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

        private static DataGridViewCellStyle _styleDateTimeShort = new DataGridViewCellStyle(_styleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yy HH:mm"
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

        public static DataGridViewCellStyle StyleNumber(int decimais) {
            return new DataGridViewCellStyle(_styleBase) {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = $"N{decimais}"
            };
        }

        public static DataGridViewCellStyle StyleDateTime => _styleDateTime;
        public static DataGridViewCellStyle StyleDateTimeShort => _styleDateTimeShort;
        public static DataGridViewCellStyle StyleDayAndTime => _styleDayAndTime;
        public static DataGridViewCellStyle StyleCurrency => _styleCurrency;
        public static DataGridViewCellStyle StyleInteger => _styleInteger;
        public static DataGridViewCellStyle StylePercent => _stylePercent;
        public static DataGridViewCellStyle StyleTrend => _styleTrend;
        public static DataGridViewCellStyle StyleTrendAlternate => _styleTrendAlternate;

        public static DataGridViewCellStyle StyleAsTotal(DataGridViewCellStyle style) {
            return new DataGridViewCellStyle(style) {
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10) //, FontStyle.Bold)
            };
        }

        public static void FormatGrid(DataGridView dgv, int cols = 0) {
            if (cols > 0) {
                // Remove extra columns that "magically" appear
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

        public static void FormatGridAsTotal(DataGridView dgvTotal, DataGridView dgvDetails) {
            // Remove extra columns that "magically" appear
            while (dgvTotal.ColumnCount > dgvDetails.ColumnCount) {
                dgvTotal.Columns.RemoveAt(dgvTotal.ColumnCount - 1);
            }
            dgvTotal.DefaultCellStyle = _styleBase;
            CloneGrid(dgvDetails, dgvTotal, true);
            dgvTotal.ColumnHeadersVisible = false;
            dgvTotal.EnableHeadersVisualStyles = false;
            dgvTotal.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTotal.RowHeadersDefaultCellStyle = _styleHeader;
            dgvTotal.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        public static void CloneGrid(DataGridView dgvMaster, DataGridView dgvClone, bool isTotal = false) {
            if (dgvMaster.ColumnCount != dgvClone.ColumnCount) return;
            for (var col = 0; col < dgvMaster.ColumnCount; col++) {
                dgvClone.Columns[col].DefaultCellStyle = isTotal ?
                    StyleAsTotal(dgvMaster.Columns[col].DefaultCellStyle) : dgvMaster.Columns[col].DefaultCellStyle;
                //dgvClone.Columns[col].Width = dgvMaster.Columns[col].Width;
                dgvClone.Columns[col].AutoSizeMode = dgvMaster.Columns[col].AutoSizeMode;
                dgvClone.Columns[col].Visible = dgvMaster.Columns[col].Visible;
            }
            dgvClone.BackgroundColor = dgvMaster.BackgroundColor;
            dgvClone.RowHeadersWidth = dgvMaster.RowHeadersWidth;
            dgvClone.GridColor = dgvMaster.GridColor;

        }

        public static void FormatColumn(DataGridViewColumn col, DataGridViewCellStyle style, int width) {
            col.DefaultCellStyle = style;
            col.Width = width;
        }

        public static void FormatColumns(DataGridView dgv, int colStart, int colEnd, DataGridViewCellStyle style, int width) {
            colEnd = colEnd == 0 ? dgv.ColumnCount - 1 : colEnd;
            for (var col = colStart; col <= colEnd; col++) {
                dgv.Columns[col].DefaultCellStyle = style;
                dgv.Columns[col].Width = width;
            }
        }

        public static void FormatColumns(DataGridView dgv, DataGridViewCellStyle style, int width = 0, params int[] cols) {
            foreach (var col in cols) {
                dgv.Columns[col].DefaultCellStyle = style;
                if (width != 0)
                    dgv.Columns[col].Width = width;
            }
        }

        public static int GridVisibleWidth(DataGridView dgv) {
            return dgv.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible).Sum(x => x.Width)
                + (dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0) + 3;
        }
    }
}