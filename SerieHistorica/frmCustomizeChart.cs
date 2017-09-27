using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerieHistorica {
    public partial class frmCustomizeChart : Form {

        public Chart chart { get; set; }
        private bool _refreshSerie;
        public frmCustomizeChart() {
            InitializeComponent();
        }

        private void frmCustomizeChart_Load(object sender, EventArgs e) {
            colorPickerBackground.Color = chart.BackColor;
            colorPickerAxes.Color = chart.ChartAreas[0].Axes[0].LineColor;
            colorPickerAxesLabels.Color = chart.ChartAreas[0].Axes[0].LabelStyle.ForeColor;
            colorPickerGrids.Color = chart.ChartAreas[0].Axes[0].MajorGrid.LineColor;
            colorPickerLegends.Color = chart.Legends[0].ForeColor;
            comboBoxSeries.Items.AddRange(chart.Series.ToArray());
            comboBoxSeries.DisplayMember = "Name";
            comboBoxSeries.SelectedIndex = 0;

            foreach (var s in Enum.GetNames(typeof(ChartColorPalette))) {
                comboBoxPallete.Items.Add(s);
            }
            comboBoxPallete.SelectedItem = chart.Palette.ToString();
        }

        private void comboBoxSeries_SelectedIndexChanged(object sender, EventArgs e) {
            chart.ApplyPaletteColors();
            _refreshSerie = false;
            colorPickerSerie.Color = ((Series)comboBoxSeries.SelectedItem).Color;
        }

        private void colorPickerBackground_ColorChanged(object sender, EventArgs e) {
            chart.BackColor = colorPickerBackground.Color;
        }

        private void colorPickerAxes_ColorChanged(object sender, EventArgs e) {
            foreach (var axis in chart.ChartAreas[0].Axes)
                axis.LineColor = colorPickerAxes.Color;
        }

        private void colorPickerAxesLabels_ColorChanged(object sender, EventArgs e) {
            foreach (var axis in chart.ChartAreas[0].Axes)
                axis.LabelStyle.ForeColor = colorPickerAxesLabels.Color;
        }

        private void colorPickerGrids_ColorChanged(object sender, EventArgs e) {
            foreach (var axis in chart.ChartAreas[0].Axes)
                axis.MajorGrid.LineColor = colorPickerGrids.Color;
        }

        private void colorPickerLegends_ColorChanged(object sender, EventArgs e) {
            chart.Legends[0].ForeColor = colorPickerLegends.Color;
        }

        private void colorPickerSerie_ColorChanged(object sender, EventArgs e) {
            if (_refreshSerie) {
                var serie = (Series)comboBoxSeries.SelectedItem;
                serie.Color = colorPickerSerie.Color;
            }
            _refreshSerie = true;
        }

        private void buttonInvert_Click(object sender, EventArgs e) {
            colorPickerBackground.Color = InvertColor(colorPickerBackground.Color);
            colorPickerAxes.Color = InvertColor(colorPickerAxes.Color);
            colorPickerAxesLabels.Color = InvertColor(colorPickerAxesLabels.Color);
            colorPickerGrids.Color = InvertColor(colorPickerGrids.Color);
            colorPickerLegends.Color = InvertColor(colorPickerLegends.Color);
        }

        private Color InvertColor(Color cor) {
            return Color.FromArgb(cor.ToArgb() ^ 0xffffff);
        }

        private void comboBoxPallete_SelectedIndexChanged(object sender, EventArgs e) {
            var val = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), comboBoxPallete.SelectedItem.ToString());
            chart.Palette = val;
            var pos = comboBoxSeries.SelectedIndex;
            comboBoxSeries_SelectedIndexChanged(sender, e);
        }
    }
}
