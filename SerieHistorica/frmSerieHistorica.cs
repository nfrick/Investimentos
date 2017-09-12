using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataLayer;
using GridAndChartStyleLibrary;

namespace SerieHistorica {
    public partial class frmSerieHistorica : Form {
        public frmSerieHistorica() {
            InitializeComponent();

            // Must setup year range selection before loading form
            using (var ctx = new InvestimentosEntities()) {
                var anos = ctx.SeriesHistoricas.Select(s => s.Data.Year.ToString()).Distinct().OrderBy(a => a).ToArray();
                toolStripComboBoxInicio.Items.AddRange(anos);
                toolStripComboBoxInicio.SelectedIndex = 0;
                toolStripComboBoxTermino.Items.AddRange(anos);
                toolStripComboBoxTermino.SelectedIndex = anos.Length - 1;
                toolStripComboBoxInicio.SelectedIndexChanged += toolStripComboBoxAnos_SelectedIndexChanged;
                toolStripComboBoxTermino.SelectedIndexChanged += toolStripComboBoxAnos_SelectedIndexChanged;
            }
        }

        private void frmSerieHistorica_Load(object sender, EventArgs e) {
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatGrid(dgvSerieHistorica);
            GridStyles.FormatColumns(dgvSerieHistorica, 1, 0, GridStyles.StyleCurrency, 60);
            dgvSerieHistorica.Columns[0].Width = 90;

            // 55 = vertical scroll bar width
            Width = 55 + dgvAtivos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) +
                55 + dgvSerieHistorica.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
        }

        private void toolStripComboBoxAnos_SelectedIndexChanged(object sender, EventArgs e) {
            if (toolStripComboBoxInicio.SelectedIndex > toolStripComboBoxTermino.SelectedIndex) {
                var temp = toolStripComboBoxInicio.SelectedIndex;
                toolStripComboBoxInicio.SelectedIndex = toolStripComboBoxTermino.SelectedIndex;
                toolStripComboBoxTermino.SelectedIndex = temp;
            }
            GerarGrafico();
        }

        private void dgvAtivos_SelectionChanged(object sender, EventArgs e) {
            GerarGrafico();
        }

        private void GerarGrafico() {
            if (dgvAtivos.SelectedRows.Count == 0 ||
                dgvSerieHistorica.Rows.Count == 0) {
                chart1.Visible = false;
                return;
            }
            var anoInicio = 0;
            var anoTermino = 0;

            if (toolStripComboBoxInicio.SelectedItem != null) {
                anoInicio = int.Parse(toolStripComboBoxInicio.SelectedItem.ToString());
                anoTermino = int.Parse(toolStripComboBoxTermino.SelectedItem.ToString());
            }
            chart1.Visible = true;
            chart1.Series.Clear();
            double chartMax = 0;
            double chartMin = 1000;
            using (var ctx = new InvestimentosEntities()) {
                foreach (DataGridViewRow row in dgvAtivos.SelectedRows) {
                    var ativo = row.Cells[0].Value.ToString();
                    if (!ctx.Ativos.Find(ativo).SeriesHistoricas
                        .Any(s => InYearRange(s.Data, anoInicio, anoTermino))) continue;
                    {
                        var serie = chart1.Series.Add(ativo);
                        serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        var items = anoInicio == 0 ? ctx.Ativos.Find(ativo).SeriesHistoricas :
                            ctx.Ativos.Find(ativo).SeriesHistoricas.Where(s => InYearRange(s.Data, anoInicio, anoTermino));
                        foreach (var s in items) {
                            serie.Points.AddXY(s.Data, s.PrecoUltimo);
                            chartMax = Math.Max(chartMax, (double)s.PrecoUltimo);
                            chartMin = Math.Min(chartMin, (double)s.PrecoUltimo);
                        }
                    }
                }
            }
            ChartMinMax.ChartSetYAxisMinMax(chart1, chartMin, chartMax, 0.05);
        }

        private static bool InYearRange(DateTime data, int anoMin, int anoMax) {
            return data.Year >= anoMin && data.Year <= anoMax;
        }

        #region Ler Arquivos
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
            var arquivo = Path.GetFileName((string)e.UserState);
            toolStripLabel1.Text = $@"Lendo {arquivo}";
        }
        #endregion
    }
}
