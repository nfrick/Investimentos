using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GridAndChartStyleLibrary {
    public static class GridStyles {

        private static readonly DataGridViewCellStyle _styleFont = new DataGridViewCellStyle {
            Font = new Font("Segoe UI", 10)
        };

        public static DataGridViewCellStyle StyleHeader { get; } = new DataGridViewCellStyle(_styleFont) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            ForeColor = Color.WhiteSmoke,
            BackColor = Color.DimGray,
            WrapMode = DataGridViewTriState.True
        };

        public static DataGridViewCellStyle StyleBase { get; } = new DataGridViewCellStyle(_styleFont) {
            ForeColor = Color.LightBlue,
            BackColor = Color.Black,
            SelectionForeColor = Color.Black,
            SelectionBackColor = Color.FromArgb(255, 192, 255, 255)
        };

        public static DataGridViewCellStyle StyleTotal { get; } = new DataGridViewCellStyle(_styleFont) {
            ForeColor = Color.White,
            BackColor = Color.Black,
            SelectionForeColor = Color.White,
            SelectionBackColor = Color.Black,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };

        public static DataGridViewCellStyle StyleAlternate { get; } = new DataGridViewCellStyle() {
            ForeColor = Color.LightGreen,
            BackColor = Color.FromArgb(255, 30, 30, 30)
        };

        public static DataGridViewCellStyle StyleNegative { get; } = new DataGridViewCellStyle {
            ForeColor = Color.Red
        };

        public static DataGridViewCellStyle StyleDate { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yyyy"
        };

        public static DataGridViewCellStyle StyleDateShort { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yy"
        };

        public static DataGridViewCellStyle StyleNumber(int decimais) {
            return new DataGridViewCellStyle(StyleBase) {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = $"N{decimais}"
            };
        }

        public static DataGridViewCellStyle StyleDateTime { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yyyy HH:mm"
        };

        public static DataGridViewCellStyle StyleDateTimeShort { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM/yy HH:mm"
        };

        public static DataGridViewCellStyle StyleDayAndTime { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Format = "dd/MM HH:mm"
        };

        public static DataGridViewCellStyle StyleCurrency { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N2"
        };

        public static DataGridViewCellStyle StyleInteger { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N0"
        };

        public static DataGridViewCellStyle StylePercent { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = @"0.00%"
        };

        public static DataGridViewCellStyle StyleTrend { get; } = new DataGridViewCellStyle(StyleBase) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            Font = new Font("Wingdings", 10)
        };

        public static DataGridViewCellStyle StyleTrendAlternate { get; } = new DataGridViewCellStyle(StyleAlternate) {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            Font = new Font("Wingdings", 10)
        };

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
            dgv.AlternatingRowsDefaultCellStyle = StyleAlternate;
            dgv.BackgroundColor = Color.Black;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle = StyleHeader;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(255, 64, 64, 64);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle = StyleHeader;
            dgv.RowHeadersWidth = 20;
            dgv.DefaultCellStyle = StyleBase;
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
            dgvTotal.DefaultCellStyle = StyleBase;
            CloneGrid(dgvDetails, dgvTotal, true);
            dgvTotal.ColumnHeadersVisible = false;
            dgvTotal.EnableHeadersVisualStyles = false;
            dgvTotal.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTotal.RowHeadersDefaultCellStyle = StyleHeader;
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