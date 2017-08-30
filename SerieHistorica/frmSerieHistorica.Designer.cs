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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.dgvAtivos = new DataGridViewWithButtons.VBControls.DataGridViewWithButtons();
            this.codigoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.dgvSerieHistorica = new System.Windows.Forms.DataGridView();
            this.dataDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoAberturaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMaximoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMinimoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMedioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoUltimoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLerSerie = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoAberturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMaximoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMedioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoUltimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSerieHistorica)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(733, 470);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(733, 497);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Black;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 505F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvAtivos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSerieHistorica, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 470);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.InvestimentosEntities);
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
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 238);
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
            this.chart1.Size = new System.Drawing.Size(749, 229);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // dgvAtivos
            // 
            this.dgvAtivos.AllowUserToAddRows = false;
            this.dgvAtivos.AllowUserToDeleteRows = false;
            this.dgvAtivos.AutoGenerateColumns = false;
            this.dgvAtivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAtivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAtivos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAtivos.RowHeadersWidth = 20;
            this.dgvAtivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtivos.Size = new System.Drawing.Size(244, 229);
            this.dgvAtivos.TabIndex = 3;
            this.dgvAtivos.SelectionChanged += new System.EventHandler(this.dataGridViewWithButtonsAtivos_SelectionChanged);
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
            // dgvSerieHistorica
            // 
            this.dgvSerieHistorica.AllowUserToAddRows = false;
            this.dgvSerieHistorica.AllowUserToDeleteRows = false;
            this.dgvSerieHistorica.AutoGenerateColumns = false;
            this.dgvSerieHistorica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSerieHistorica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSerieHistorica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSerieHistorica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataDataGridViewTextBoxColumn1,
            this.precoAberturaDataGridViewTextBoxColumn1,
            this.precoMaximoDataGridViewTextBoxColumn1,
            this.precoMinimoDataGridViewTextBoxColumn1,
            this.precoMedioDataGridViewTextBoxColumn1,
            this.precoUltimoDataGridViewTextBoxColumn1,
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1,
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1});
            this.dgvSerieHistorica.DataMember = "Ativos.SeriesHistoricas";
            this.dgvSerieHistorica.DataSource = this.entityDataSource1;
            this.dgvSerieHistorica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSerieHistorica.EnableHeadersVisualStyles = false;
            this.dgvSerieHistorica.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSerieHistorica.Location = new System.Drawing.Point(253, 3);
            this.dgvSerieHistorica.Name = "dgvSerieHistorica";
            this.dgvSerieHistorica.ReadOnly = true;
            this.dgvSerieHistorica.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSerieHistorica.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSerieHistorica.RowHeadersWidth = 20;
            this.dgvSerieHistorica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSerieHistorica.Size = new System.Drawing.Size(499, 229);
            this.dgvSerieHistorica.TabIndex = 4;
            // 
            // dataDataGridViewTextBoxColumn1
            // 
            this.dataDataGridViewTextBoxColumn1.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn1.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn1.Name = "dataDataGridViewTextBoxColumn1";
            this.dataDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoAberturaDataGridViewTextBoxColumn1
            // 
            this.precoAberturaDataGridViewTextBoxColumn1.DataPropertyName = "PrecoAbertura";
            this.precoAberturaDataGridViewTextBoxColumn1.HeaderText = "Abertura";
            this.precoAberturaDataGridViewTextBoxColumn1.Name = "precoAberturaDataGridViewTextBoxColumn1";
            this.precoAberturaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoMaximoDataGridViewTextBoxColumn1
            // 
            this.precoMaximoDataGridViewTextBoxColumn1.DataPropertyName = "PrecoMaximo";
            this.precoMaximoDataGridViewTextBoxColumn1.HeaderText = "Máximo";
            this.precoMaximoDataGridViewTextBoxColumn1.Name = "precoMaximoDataGridViewTextBoxColumn1";
            this.precoMaximoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoMinimoDataGridViewTextBoxColumn1
            // 
            this.precoMinimoDataGridViewTextBoxColumn1.DataPropertyName = "PrecoMinimo";
            this.precoMinimoDataGridViewTextBoxColumn1.HeaderText = "Mínimo";
            this.precoMinimoDataGridViewTextBoxColumn1.Name = "precoMinimoDataGridViewTextBoxColumn1";
            this.precoMinimoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoMedioDataGridViewTextBoxColumn1
            // 
            this.precoMedioDataGridViewTextBoxColumn1.DataPropertyName = "PrecoMedio";
            this.precoMedioDataGridViewTextBoxColumn1.HeaderText = "Médio";
            this.precoMedioDataGridViewTextBoxColumn1.Name = "precoMedioDataGridViewTextBoxColumn1";
            this.precoMedioDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoUltimoDataGridViewTextBoxColumn1
            // 
            this.precoUltimoDataGridViewTextBoxColumn1.DataPropertyName = "PrecoUltimo";
            this.precoUltimoDataGridViewTextBoxColumn1.HeaderText = "Último";
            this.precoUltimoDataGridViewTextBoxColumn1.Name = "precoUltimoDataGridViewTextBoxColumn1";
            this.precoUltimoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precoMelhorOfertaCompraDataGridViewTextBoxColumn1
            // 
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1.DataPropertyName = "PrecoMelhorOfertaCompra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1.HeaderText = "M.O. Compra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1.Name = "precoMelhorOfertaCompraDataGridViewTextBoxColumn1";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1.ReadOnly = true;
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn1.ToolTipText = "Melhor Oferta de Compra";
            // 
            // precoMelhorOfertaVendaDataGridViewTextBoxColumn1
            // 
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1.DataPropertyName = "PrecoMelhorOfertaVenda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1.HeaderText = "M.O. Venda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1.Name = "precoMelhorOfertaVendaDataGridViewTextBoxColumn1";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn1.ToolTipText = "Melhor Oferta de Venda";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLerSerie,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(82, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonLerSerie
            // 
            this.toolStripButtonLerSerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLerSerie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripButtonLerSerie.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLerSerie.Image")));
            this.toolStripButtonLerSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLerSerie.Name = "toolStripButtonLerSerie";
            this.toolStripButtonLerSerie.Size = new System.Drawing.Size(70, 24);
            this.toolStripButtonLerSerie.Text = "Ler Série";
            this.toolStripButtonLerSerie.Click += new System.EventHandler(this.toolStripButtonLerSerie_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Yellow;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDataGridViewTextBoxColumn1
            // 
            this.codigoDataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn1.Name = "codigoDataGridViewTextBoxColumn1";
            this.codigoDataGridViewTextBoxColumn1.ReadOnly = true;
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
            this.precoAberturaDataGridViewTextBoxColumn.HeaderText = "PrecoAbertura";
            this.precoAberturaDataGridViewTextBoxColumn.Name = "precoAberturaDataGridViewTextBoxColumn";
            this.precoAberturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMaximoDataGridViewTextBoxColumn
            // 
            this.precoMaximoDataGridViewTextBoxColumn.DataPropertyName = "PrecoMaximo";
            this.precoMaximoDataGridViewTextBoxColumn.HeaderText = "PrecoMaximo";
            this.precoMaximoDataGridViewTextBoxColumn.Name = "precoMaximoDataGridViewTextBoxColumn";
            this.precoMaximoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMinimoDataGridViewTextBoxColumn
            // 
            this.precoMinimoDataGridViewTextBoxColumn.DataPropertyName = "PrecoMinimo";
            this.precoMinimoDataGridViewTextBoxColumn.HeaderText = "PrecoMinimo";
            this.precoMinimoDataGridViewTextBoxColumn.Name = "precoMinimoDataGridViewTextBoxColumn";
            this.precoMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMedioDataGridViewTextBoxColumn
            // 
            this.precoMedioDataGridViewTextBoxColumn.DataPropertyName = "PrecoMedio";
            this.precoMedioDataGridViewTextBoxColumn.HeaderText = "PrecoMedio";
            this.precoMedioDataGridViewTextBoxColumn.Name = "precoMedioDataGridViewTextBoxColumn";
            this.precoMedioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoUltimoDataGridViewTextBoxColumn
            // 
            this.precoUltimoDataGridViewTextBoxColumn.DataPropertyName = "PrecoUltimo";
            this.precoUltimoDataGridViewTextBoxColumn.HeaderText = "PrecoUltimo";
            this.precoUltimoDataGridViewTextBoxColumn.Name = "precoUltimoDataGridViewTextBoxColumn";
            this.precoUltimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMelhorOfertaCompraDataGridViewTextBoxColumn
            // 
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.DataPropertyName = "PrecoMelhorOfertaCompra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.HeaderText = "PrecoMelhorOfertaCompra";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.Name = "precoMelhorOfertaCompraDataGridViewTextBoxColumn";
            this.precoMelhorOfertaCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoMelhorOfertaVendaDataGridViewTextBoxColumn
            // 
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.DataPropertyName = "PrecoMelhorOfertaVenda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.HeaderText = "PrecoMelhorOfertaVenda";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.Name = "precoMelhorOfertaVendaDataGridViewTextBoxColumn";
            this.precoMelhorOfertaVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ativoDataGridViewTextBoxColumn
            // 
            this.ativoDataGridViewTextBoxColumn.DataPropertyName = "Ativo";
            this.ativoDataGridViewTextBoxColumn.HeaderText = "Ativo";
            this.ativoDataGridViewTextBoxColumn.Name = "ativoDataGridViewTextBoxColumn";
            this.ativoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmSerieHistorica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(733, 497);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSerieHistorica";
            this.Text = "Série Histórica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSerieHistorica)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoAberturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMaximoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMedioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoUltimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoMelhorOfertaVendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
        private EFWinforms.EntityDataSource entityDataSource1;
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
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLerSerie;
    }
}

