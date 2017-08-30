using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DataLayer;
using GridAndChartStyleLibrary;

namespace SerieHistorica {
    public partial class frmSerieHistorica : Form {
        public frmSerieHistorica() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatGrid(dgvSerieHistorica);
            GridStyles.FormatColumns(dgvSerieHistorica, 1, 0, GridStyles.StyleCurrency, 60);
            dgvSerieHistorica.Columns[0].Width = 90;

            // 50 = vertical scroll bar width
            var w0 = 50 + dgvAtivos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w1 = 50 + dgvSerieHistorica.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            tableLayoutPanel1.ColumnStyles[0].Width = w0;
            tableLayoutPanel1.ColumnStyles[1].Width = w1;
            Width = toolStripContainer1.Width + 100;
        }

        private void dataGridViewWithButtonsAtivos_SelectionChanged(object sender, EventArgs e) {
            if (dgvAtivos.SelectedRows.Count == 0 || 
                dgvSerieHistorica.Rows.Count == 0) {
                chart1.Visible = false;
                return;
            }
            chart1.Visible = true;
            chart1.Series.Clear();
            double chartMax = 0;
            double chartMin = 1000;
            using (var ctx = new InvestimentosEntities()) {
                foreach(DataGridViewRow row in dgvAtivos.SelectedRows) {
                    var ativo = row.Cells[0].Value.ToString();
                    var serie = chart1.Series.Add(ativo);
                    serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    var sh = ctx.Ativos.Find(ativo).SeriesHistoricas;
                    foreach (var s in sh) {
                        serie.Points.AddXY(s.Data, s.PrecoUltimo);
                    }
                    chartMax = Math.Max(chartMax, (double)sh.Max(s => s.PrecoUltimo));
                    chartMin = Math.Min(chartMin, (double)sh.Min(s => s.PrecoUltimo));
                }
            }
            ChartMinMax.ChartSetYAxisMinMax(chart1, chartMin, chartMax, 0.05);
        }

        private void toolStripButtonLerSerie_Click(object sender, EventArgs e) {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.DefaultExt = @".txt";
            ofd.Filter = @"Text files|*.txt";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            backgroundWorker1.RunWorkerAsync(ofd.FileNames);
            entityDataSource1.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            var arquivos = e.Argument as string[];
            foreach (var arquivo in arquivos) {
                backgroundWorker1.ReportProgress(1, arquivo);
                DataLayer.SerieHistorica.LerArquivoParaDatabase(arquivo);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            toolStripLabel1.Text = string.Empty;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            toolStripLabel1.Text = @"Lendo " + (string)e.UserState;
        }
    }
}
