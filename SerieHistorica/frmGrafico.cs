using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerieHistorica {
    public partial class frmGrafico : Form {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public frmGrafico() {
            InitializeComponent();
        }

        private void frmGrafico_Load(object sender, EventArgs e) {
            foreach (var serie in chart1.Series) {
                var ctl = new ToolStripMenuItem($"Change {serie.Name}") {Tag = serie};
                ctl.Click += changeColorToolStripMenuItem_Click;
                contextMenu.Items.Add(ctl);
            }
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = (ToolStripMenuItem) sender;
            var serie = (Series)item.Tag;
            ColorDialog.Color = serie.Color;
            if(ColorDialog.ShowDialog() == DialogResult.OK)
                serie.Color = ColorDialog.Color;
        }

        private void invertBackgroundToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (var axis in chart1.ChartAreas[0].Axes) {
                axis.LineColor = InvertColor(axis.LineColor);
                axis.MajorGrid.LineColor = InvertColor(axis.LineColor);
                axis.MinorGrid.LineColor = InvertColor(axis.LineColor);
                axis.LabelStyle.ForeColor = InvertColor(axis.LabelStyle.ForeColor);
            }
            foreach (var legend in chart1.Legends) {
                legend.ForeColor = InvertColor(legend.ForeColor);
            }
            chart1.BackColor = InvertColor(chart1.BackColor);
        }

        private Color InvertColor(Color cor) {
            return Color.FromArgb(cor.ToArgb() ^ 0xffffff);
        }

        private void saveAsPNGToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveDialog.DefaultExt = "png";
            SaveDialog.Filter = @"PNG Files|*.png";
            SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (SaveDialog.ShowDialog() == DialogResult.OK)
                chart1.SaveImage(SaveDialog.FileName, ChartImageFormat.Png);
        }

        private void toolStripMenuItemCustomize_Click(object sender, EventArgs e) {
            var frm = new frmCustomizeChart() {
                chart = chart1
            };
            frm.Location = new Point(Location.X + Width - 10, Location.Y + Height - frm.Height);
            frm.ShowDialog();
            
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;

            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                ChartElementType.DataPoint);  //.PlottingArea);
            foreach (var result in results) {
                if (result.ChartElementType != ChartElementType.DataPoint) continue;
                var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                var hora = (new DateTime(1899, 12, 31)).AddDays(xVal).ToString("dd/MM/yy");

                tooltip.Show($"{hora} - {yVal:C2}", this.chart1, pos.X, pos.Y - 15);
            }
        }
    }
}
