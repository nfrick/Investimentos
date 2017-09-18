namespace SerieHistorica {
    partial class frmSerieHistorica {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerieHistorica));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSerieHistorica = new System.Windows.Forms.DataGridView();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.dgvAtivos = new DataGridViewWithButtons.VBControls.DataGridViewWithButtons();
            this.codigoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLerSerie = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxInicio = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxTermino = new System.Windows.Forms.ToolStripComboBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoAberturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMaximoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMedioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoUltimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSerieHistorica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtivos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.InvestimentosEntities);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1072, 681);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1072, 709);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1072, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.LabelStyle.Format = "MM-yyyy";
            chartArea1.AxisX.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LabelStyle.Format = "N2";
            chartArea1.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Viner Hand ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chart1, 2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 343);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BackSecondaryColor = System.Drawing.Color.Silver;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBorderColor = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "Data";
            series1.YValueMembers = "PrecoUltimo";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1066, 335);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.dgvSerieHistorica, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvAtivos, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1066, 334);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvSerieHistorica
            // 
            this.dgvSerieHistorica.AllowUserToAddRows = false;
            this.dgvSerieHistorica.AllowUserToDeleteRows = false;
            this.dgvSerieHistorica.AutoGenerateColumns = false;
            this.dgvSerieHistorica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSerieHistorica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSerieHistorica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSerieHistorica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataDataGridViewTextBoxColumn,
            this.precoAberturaDataGridViewTextBoxColumn,
            this.precoMaximoDataGridViewTextBoxColumn,
            this.precoMinimoDataGridViewTextBoxColumn,
            this.precoMedioDataGridViewTextBoxColumn,
            this.precoUltimoDataGridViewTextBoxColumn,
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn,
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn});
            this.dgvSerieHistorica.DataMember = "Ativos.CotacoesDiarias";
            this.dgvSerieHistorica.DataSource = this.entityDataSource1;
            this.dgvSerieHistorica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSerieHistorica.EnableHeadersVisualStyles = false;
            this.dgvSerieHistorica.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSerieHistorica.Location = new System.Drawing.Point(403, 3);
            this.dgvSerieHistorica.Name = "dgvSerieHistorica";
            this.dgvSerieHistorica.ReadOnly = true;
            this.dgvSerieHistorica.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSerieHistorica.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSerieHistorica.RowHeadersWidth = 20;
            this.dgvSerieHistorica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSerieHistorica.Size = new System.Drawing.Size(660, 328);
            this.dgvSerieHistorica.TabIndex = 5;
            // 
            // dgvAtivos
            // 
            this.dgvAtivos.AllowUserToAddRows = false;
            this.dgvAtivos.AllowUserToDeleteRows = false;
            this.dgvAtivos.AutoGenerateColumns = false;
            this.dgvAtivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAtivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAtivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn2,
            this.nomeDataGridViewTextBoxColumn});
            this.dgvAtivos.DataMember = "Ativos";
            this.dgvAtivos.DataSource = this.entityDataSource1;
            this.dgvAtivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAtivos.EnableHeadersVisualStyles = false;
            this.dgvAtivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvAtivos.Location = new System.Drawing.Point(3, 3);
            this.dgvAtivos.Name = "dgvAtivos";
            this.dgvAtivos.ReadOnly = true;
            this.dgvAtivos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAtivos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAtivos.RowHeadersWidth = 20;
            this.dgvAtivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtivos.Size = new System.Drawing.Size(394, 328);
            this.dgvAtivos.TabIndex = 4;
            this.dgvAtivos.SelectionChanged += new System.EventHandler(this.dgvAtivos_SelectionChanged);
            // 
            // codigoDataGridViewTextBoxColumn2
            // 
            this.codigoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigoDataGridViewTextBoxColumn2.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn2.HeaderText = "Ativo";
            this.codigoDataGridViewTextBoxColumn2.Name = "codigoDataGridViewTextBoxColumn2";
            this.codigoDataGridViewTextBoxColumn2.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn2.Width = 77;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLerSerie,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripComboBoxInicio,
            this.toolStripLabel3,
            this.toolStripComboBoxTermino});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(759, 28);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonLerSerie
            // 
            this.toolStripButtonLerSerie.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonLerSerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLerSerie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonLerSerie.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLerSerie.Image")));
            this.toolStripButtonLerSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLerSerie.Name = "toolStripButtonLerSerie";
            this.toolStripButtonLerSerie.Size = new System.Drawing.Size(70, 25);
            this.toolStripButtonLerSerie.Text = "Ler Série";
            this.toolStripButtonLerSerie.Click += new System.EventHandler(this.toolStripButtonLerSerie_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(400, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 25);
            this.toolStripLabel2.Tag = "";
            this.toolStripLabel2.Text = "Gráfico: de";
            // 
            // toolStripComboBoxInicio
            // 
            this.toolStripComboBoxInicio.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripComboBoxInicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripComboBoxInicio.Name = "toolStripComboBoxInicio";
            this.toolStripComboBoxInicio.Size = new System.Drawing.Size(75, 28);
            this.toolStripComboBoxInicio.Tag = "";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 25);
            this.toolStripLabel3.Tag = "";
            this.toolStripLabel3.Text = "até";
            // 
            // toolStripComboBoxTermino
            // 
            this.toolStripComboBoxTermino.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripComboBoxTermino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripComboBoxTermino.Name = "toolStripComboBoxTermino";
            this.toolStripComboBoxTermino.Size = new System.Drawing.Size(75, 28);
            this.toolStripComboBoxTermino.Tag = "";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoAberturaDataGridViewTextBoxColumn
            // 
            this.precoAberturaDataGridViewTextBoxColumn.DataPropertyName = "PrecoAbertura";
            this.precoAberturaDataGridViewTextBoxColumn.HeaderText = "Abertura";
            this.precoAberturaDataGridViewTextBoxColumn.Name = "precoAberturaDataGridViewTextBoxColumn";
            this.precoAberturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMaximoDataGridViewTextBoxColumn
            // 
            this.precoMaximoDataGridViewTextBoxColumn.DataPropertyName = "PrecoMaximo";
            this.precoMaximoDataGridViewTextBoxColumn.HeaderText = "Máximo";
            this.precoMaximoDataGridViewTextBoxColumn.Name = "precoMaximoDataGridViewTextBoxColumn";
            this.precoMaximoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMinimoDataGridViewTextBoxColumn
            // 
            this.precoMinimoDataGridViewTextBoxColumn.DataPropertyName = "PrecoMinimo";
            this.precoMinimoDataGridViewTextBoxColumn.HeaderText = "Mínimo";
            this.precoMinimoDataGridViewTextBoxColumn.Name = "precoMinimoDataGridViewTextBoxColumn";
            this.precoMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMedioDataGridViewTextBoxColumn
            // 
            this.precoMedioDataGridViewTextBoxColumn.DataPropertyName = "PrecoMedio";
            this.precoMedioDataGridViewTextBoxColumn.HeaderText = "Médio";
            this.precoMedioDataGridViewTextBoxColumn.Name = "precoMedioDataGridViewTextBoxColumn";
            this.precoMedioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoUltimoDataGridViewTextBoxColumn
            // 
            this.precoUltimoDataGridViewTextBoxColumn.DataPropertyName = "PrecoUltimo";
            this.precoUltimoDataGridViewTextBoxColumn.HeaderText = "Último";
            this.precoUltimoDataGridViewTextBoxColumn.Name = "precoUltimoDataGridViewTextBoxColumn";
            this.precoUltimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMelhorOfertaCompraDataGridViewTextBoxColumn
            // 
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.DataPropertyName = "PrecoMelhorOfertaCompra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.HeaderText = "M.O. Compra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.Name = "precoMelhorOfertaCompraDataGridViewTextBoxColumn";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMelhorOfertaVendaDataGridViewTextBoxColumn
            // 
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.DataPropertyName = "PrecoMelhorOfertaVenda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.HeaderText = "M.O. Venda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.Name = "precoMelhorOfertaVendaDataGridViewTextBoxColumn";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmSerieHistorica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 709);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmSerieHistorica";
            this.Text = "Série Histórica de Cotações";
            this.Load += new System.EventHandler(this.frmSerieHistorica_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSerieHistorica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtivos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EFWinforms.EntityDataSource entityDataSource1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridViewWithButtons.VBControls.DataGridViewWithButtons dgvAtivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvSerieHistorica;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoAberturaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMaximoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMinimoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMedioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoUltimoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaCompraDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaVendaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLerSerie;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxInicio;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTermino;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoAberturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMaximoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMedioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoUltimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaVendaDataGridViewTextBoxColumn;
    }
}