using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace GridAndChartStyleLibrary {
    public static class ChartMinMax {
        public static void ChartSetYAxisMinMax(Chart chart, double min, double max) {
            var axisY = chart.ChartAreas[0].AxisY;
            if (min > axisY.Minimum && max < axisY.Maximum)
                return;
            var dif = max - min;
            double roundTo = dif > 0.05 ? 0.05 : 0.01;
            min = Math.Floor(min / roundTo) * roundTo;
            max = Math.Ceiling(max / roundTo) * roundTo;
            axisY.Minimum = min;
            axisY.Maximum = dif > 0.05 ? max : min + 0.05;
        }

        public static void ChartSetYAxisMinMax(Chart chart, double min, double max, double roundTo) {
            var axisY = chart.ChartAreas[0].AxisY;
            min = Math.Floor(min / roundTo) * roundTo;
            max = Math.Ceiling(max / roundTo) * roundTo;
            var gap = Math.Max(0.02, RoundToMultiple((max - min) / 5, roundTo));
            chart.ChartAreas[0].AxisY.Minimum = min;
            chart.ChartAreas[0].AxisY.Maximum = max - min > 0.05 ? max : min + 0.05;
        }

        private static double RoundToMultiple(double value, double roundTo) {
            return roundTo * Math.Round(value / roundTo, MidpointRounding.AwayFromZero);
        }
    }
}
