using DataLayer;
using GridAndChartStyleLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerieHistorica {
    public partial class frmSerieHistorica : Form {

        private Point? _prevPosition = null;
        private readonly ToolTip _tooltip = new ToolTip();

        public frmSerieHistorica() {
            InitializeComponent();

            // Must setup year range selection before loading form
            var datas = EDS.EntitySets["CotacoesDiarias"].Cast<CotacaoDiaria>().Select(c=>c.Data).Distinct();
            var anos = datas.Select(d => d.Year.ToString()).Distinct().OrderBy(a => a).ToArray();
            toolStripComboBoxInicio.Items.AddRange(anos);
            toolStripComboBoxInicio.SelectedIndex = 0;
            toolStripComboBoxTermino.Items.AddRange(anos);
            toolStripComboBoxTermino.SelectedIndex = anos.Length - 1;
            toolStripComboBoxInicio.SelectedIndexChanged += toolStripComboBoxAnos_SelectedIndexChanged;
            toolStripComboBoxTermino.SelectedIndexChanged += toolStripComboBoxAnos_SelectedIndexChanged;

            monthCalendarDatas.MinDate = datas.Min();
            monthCalendarDatas.MaxDate = datas.Max();
        }

        private void frmSerieHistorica_Load(object sender, EventArgs e) {
            dgvAtivos.SetFont(12);
            dgvSerieHistorica.SetFont(12);
            dgvSerieHistorica.Columns[0].Visible = false;
            dgvSerieHistorica.FormatColumn("Data", dgvSerieHistorica.StyleDateLong, 120);
            dgvSerieHistorica.FormatColumn("Abertura", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("Máximo", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("Mínimo", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("Médio", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("Último", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("M.O. Compra", dgvSerieHistorica.StyleCurrency, 70);
            dgvSerieHistorica.FormatColumn("M.O. Venda", dgvSerieHistorica.StyleCurrency, 70);

            dgvSelection.CopyFormatFrom(dgvSerieHistorica);
            for (var col = 0; col < dgvSerieHistorica.Columns.Count; col++) {
                dgvSelection.Columns[col].DataPropertyName = dgvSerieHistorica.Columns[col].DataPropertyName;
            }
            dgvSelection.Columns[0].Visible = true;

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
            GerarGrafico(this.chart1);
        }

        private void dgvAtivos_SelectionChanged(object sender, EventArgs e) {
            GerarGrafico(this.chart1);
            dgvSerieHistorica.Sort(dgvSerieHistorica.Columns[1], ListSortDirection.Descending);
            PopulateDGV();
        }


        private static bool InYearRange(DateTime data, int anoMin, int anoMax) {
            return data.Year >= anoMin && data.Year <= anoMax;
        }

        #region Ler Arquivos

        private void toolStripButtonLerSerie_Click(object sender, EventArgs e) {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = @"Arquivos|*.zip;*.txt";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            bgWorker.RunWorkerAsync(ofd.FileNames);
            // entityDataSource1.Refresh();
            if (MessageBox.Show(@"Deletar arquivo(s)?", @"Ler Série", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No) {
                return;
            }

            foreach (var arquivo in ofd.FileNames) {
                File.Delete(arquivo);
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
            var arquivos = e.Argument as string[];
            var linhas = new List<string>();
            foreach (var arquivo in arquivos) {
                bgWorker.ReportProgress(1, arquivo);
                if (arquivo.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    linhas.AddRange(File.ReadLines(arquivo));
                }
                else {
                    using (var archive = ZipFile.OpenRead(arquivo)) {
                        foreach (var entry in archive.Entries) {
                            linhas.AddRange(InternalReadAllLines(entry));
                        }
                    }
                }
            }
            LerArquivoParaDatabase(linhas);
        }

        private void LerArquivoParaDatabase(IEnumerable<string> linhas) {
            var ativos = EDS.DbContext.Set<Ativo>().ToList();
            var serie = from linha in linhas
                        join ativo in ativos
                        on linha.Substring(12, 12).Trim() equals ativo.Codigo
                        where linha.StartsWith("01")
                              && linha.Substring(24, 3) == "010"
                        select new CotacaoDiaria(linha);
            EDS.DbContext.Set<CotacaoDiaria>().AddRange(serie);
            EDS.SaveChanges();
        }

        //https://stackoverflow.com/questions/23989677/file-readalllines-or-stream-reader
        private static IEnumerable<string> InternalReadAllLines(ZipArchiveEntry entry) {
            var lines = new List<string>();
            using (var stream = entry.Open()) {
                using (var sr = new StreamReader(stream)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            toolStripLabel1.Text = string.Empty;
            EDS.Refresh();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var arquivo = Path.GetFileName((string)e.UserState);
            toolStripLabel1.Text = $@"Lendo {arquivo}";
        }
        #endregion

        #region CHART
        private void GerarGrafico(Chart chart) {
            if (dgvAtivos.SelectedRows.Count == 0 ||
                dgvSerieHistorica.Rows.Count == 0) {
                chart.Visible = false;
                return;
            }
            var anoInicio = 0;
            var anoTermino = 0;

            if (toolStripComboBoxInicio.SelectedItem != null) {
                anoInicio = int.Parse(toolStripComboBoxInicio.SelectedItem.ToString());
                anoTermino = int.Parse(toolStripComboBoxTermino.SelectedItem.ToString());
            }
            chart.Visible = true;
            chart.Series.Clear();
            double chartMax = 0;
            double chartMin = 1000;
            using (var ctx = new InvestimentosEntities()) {
                var sortedRows =
                (from DataGridViewRow row in dgvAtivos.SelectedRows
                 where !row.IsNewRow
                 orderby row.Index
                 select row).ToList<DataGridViewRow>();

                foreach (DataGridViewRow row in sortedRows) {
                    var ativo = row.Cells[0].Value.ToString();
                    if (!ctx.Ativos.Find(ativo).CotacoesDiarias
                        .Any(s => InYearRange(s.Data, anoInicio, anoTermino))) {
                        continue;
                    }

                    {
                        var serie = chart.Series.Add(ativo);
                        serie.ChartType = SeriesChartType.Line;
                        var items = anoInicio == 0 ? ctx.Ativos.Find(ativo).CotacoesDiarias :
                            ctx.Ativos.Find(ativo).CotacoesDiarias.Where(s => InYearRange(s.Data, anoInicio, anoTermino));
                        foreach (var s in items) {
                            serie.Points.AddXY(s.Data, s.PrecoUltimo);
                            chartMax = Math.Max(chartMax, (double)s.PrecoUltimo);
                            chartMin = Math.Min(chartMin, (double)s.PrecoUltimo);
                        }
                    }
                }
            }
            ChartMinMax.ChartSetYAxisMinMax(chart, chartMin, chartMax, 0.05);
        }

        private void chart1_DoubleClick(object sender, EventArgs e) {
            var frm = new frmGrafico();
            GerarGrafico(frm.chart1);
            frm.Show();
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (_prevPosition.HasValue && pos == _prevPosition.Value) {
                return;
            }

            _tooltip.RemoveAll();
            _prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                ChartElementType.DataPoint);  //.PlottingArea);
            foreach (var result in results) {
                if (result.ChartElementType != ChartElementType.DataPoint) {
                    continue;
                }

                var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                var dia = (new DateTime(1899, 12, 31)).AddDays(xVal).ToString("dd/MM/yy");

                _tooltip.Show($"{dia} - {yVal:C2}", this.chart1, pos.X, pos.Y - 15);
            }
        }
        #endregion

        #region DATAS SELECIONADAS ----------------
        private void monthCalendarDatas_MouseDown(object sender, MouseEventArgs e) {
            MonthCalendar.HitTestInfo info = monthCalendarDatas.HitTest(e.Location);
            if (info.HitArea != MonthCalendar.HitArea.Date) {
                return;
            }

            if (monthCalendarDatas.BoldedDates.Contains(info.Time)) {
                monthCalendarDatas.RemoveBoldedDate(info.Time);
            }
            else {
                monthCalendarDatas.AddBoldedDate(info.Time);
            }

            monthCalendarDatas.UpdateBoldedDates();
            PopulateDGV();
        }

        private void buttonDatesClear_Click(object sender, EventArgs e) {
            monthCalendarDatas.RemoveAllBoldedDates();
            PopulateDGV();
        }

        private void PopulateDGV() {
            var datas = monthCalendarDatas.BoldedDates.ToArray();
            if (!datas.Any()) {
                bindingSource1.DataSource = null;
                return;
            }

            var q = new List<CotacaoDiaria>();
            foreach (var row in dgvAtivos.SelectedRows.Cast<DataGridViewRow>()) {
                var acao = (Ativo) row.DataBoundItem;
                q.AddRange(acao.CotacoesDiarias.Where(c => datas.Contains(c.Data)));
            }

            var bindingList = EDS.CreateView(q);
            bindingSource1.DataSource = bindingList;
        }

        #endregion DATAS SELECIONADAS ----------------
    }
}
