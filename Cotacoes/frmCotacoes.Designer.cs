namespace Cotacoes {
    partial class frmCotacoes {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotacoes));
            this.dgvCotacoes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastTradeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastTradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousCloseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changePercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayLowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayHighDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patrimonioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMedioCompraReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LucroReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdVendavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LucroImediato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCotacoes = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelAtualizadoEm = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelErros = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTotal = new System.Windows.Forms.DataGridView();
            this.col0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col11DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col12DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col14DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceTotal = new System.Windows.Forms.BindingSource(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxConta = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripDropDownButtonAtivos = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemCorrentes = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJaNegociados = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonFrequencia = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1minuto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5minutos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10minutos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15minutos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDesligado = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonAtualizarSelecionados = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAtualizarTodos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLerExtrato = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCotacoes)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCotacoes
            // 
            this.dgvCotacoes.AllowUserToAddRows = false;
            this.dgvCotacoes.AllowUserToDeleteRows = false;
            this.dgvCotacoes.AutoGenerateColumns = false;
            this.dgvCotacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.lastTradeDateDataGridViewTextBoxColumn,
            this.trendDataGridViewTextBoxColumn,
            this.lastTradeDataGridViewTextBoxColumn,
            this.previousCloseDataGridViewTextBoxColumn,
            this.changePercentDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.dayLowDataGridViewTextBoxColumn,
            this.dayHighDataGridViewTextBoxColumn,
            this.qtdTotalDataGridViewTextBoxColumn,
            this.patrimonioDataGridViewTextBoxColumn,
            this.ValorMedioCompraReal,
            this.LucroReal,
            this.QtdVendavel,
            this.LucroImediato});
            this.dgvCotacoes.DataSource = this.bindingSourceCotacoes;
            this.dgvCotacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCotacoes.Location = new System.Drawing.Point(4, 4);
            this.dgvCotacoes.Name = "dgvCotacoes";
            this.dgvCotacoes.ReadOnly = true;
            this.dgvCotacoes.RowTemplate.Height = 24;
            this.dgvCotacoes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCotacoes.Size = new System.Drawing.Size(1275, 294);
            this.dgvCotacoes.TabIndex = 0;
            this.dgvCotacoes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCotacoes_CellFormatting);
            this.dgvCotacoes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCotacoes_CellMouseClick);
            this.dgvCotacoes.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvCotacoes_ColumnWidthChanged);
            this.dgvCotacoes.SelectionChanged += new System.EventHandler(this.dgvCotacoes_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ativo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // lastTradeDateDataGridViewTextBoxColumn
            // 
            this.lastTradeDateDataGridViewTextBoxColumn.DataPropertyName = "LastTradeDate";
            this.lastTradeDateDataGridViewTextBoxColumn.HeaderText = "Last Trade Date";
            this.lastTradeDateDataGridViewTextBoxColumn.Name = "lastTradeDateDataGridViewTextBoxColumn";
            this.lastTradeDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastTradeDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // trendDataGridViewTextBoxColumn
            // 
            this.trendDataGridViewTextBoxColumn.DataPropertyName = "Trend";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Wingdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.trendDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.trendDataGridViewTextBoxColumn.HeaderText = "";
            this.trendDataGridViewTextBoxColumn.Name = "trendDataGridViewTextBoxColumn";
            this.trendDataGridViewTextBoxColumn.ReadOnly = true;
            this.trendDataGridViewTextBoxColumn.Width = 5;
            // 
            // lastTradeDataGridViewTextBoxColumn
            // 
            this.lastTradeDataGridViewTextBoxColumn.DataPropertyName = "LastTrade";
            this.lastTradeDataGridViewTextBoxColumn.HeaderText = "Last Trade";
            this.lastTradeDataGridViewTextBoxColumn.Name = "lastTradeDataGridViewTextBoxColumn";
            this.lastTradeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastTradeDataGridViewTextBoxColumn.Width = 70;
            // 
            // previousCloseDataGridViewTextBoxColumn
            // 
            this.previousCloseDataGridViewTextBoxColumn.DataPropertyName = "PreviousClose";
            this.previousCloseDataGridViewTextBoxColumn.HeaderText = "Previous Close";
            this.previousCloseDataGridViewTextBoxColumn.Name = "previousCloseDataGridViewTextBoxColumn";
            this.previousCloseDataGridViewTextBoxColumn.ReadOnly = true;
            this.previousCloseDataGridViewTextBoxColumn.Width = 70;
            // 
            // changePercentDataGridViewTextBoxColumn
            // 
            this.changePercentDataGridViewTextBoxColumn.DataPropertyName = "ChangePercent";
            this.changePercentDataGridViewTextBoxColumn.HeaderText = "Change %";
            this.changePercentDataGridViewTextBoxColumn.Name = "changePercentDataGridViewTextBoxColumn";
            this.changePercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.changePercentDataGridViewTextBoxColumn.Width = 70;
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "Open";
            this.openDataGridViewTextBoxColumn.HeaderText = "Open";
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            this.openDataGridViewTextBoxColumn.ReadOnly = true;
            this.openDataGridViewTextBoxColumn.Width = 70;
            // 
            // dayLowDataGridViewTextBoxColumn
            // 
            this.dayLowDataGridViewTextBoxColumn.DataPropertyName = "DayLow";
            this.dayLowDataGridViewTextBoxColumn.HeaderText = "Day Low";
            this.dayLowDataGridViewTextBoxColumn.Name = "dayLowDataGridViewTextBoxColumn";
            this.dayLowDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayLowDataGridViewTextBoxColumn.Width = 70;
            // 
            // dayHighDataGridViewTextBoxColumn
            // 
            this.dayHighDataGridViewTextBoxColumn.DataPropertyName = "DayHigh";
            this.dayHighDataGridViewTextBoxColumn.HeaderText = "Day High";
            this.dayHighDataGridViewTextBoxColumn.Name = "dayHighDataGridViewTextBoxColumn";
            this.dayHighDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayHighDataGridViewTextBoxColumn.Width = 70;
            // 
            // qtdTotalDataGridViewTextBoxColumn
            // 
            this.qtdTotalDataGridViewTextBoxColumn.DataPropertyName = "QtdTotal";
            this.qtdTotalDataGridViewTextBoxColumn.HeaderText = "Qtd Ações";
            this.qtdTotalDataGridViewTextBoxColumn.Name = "qtdTotalDataGridViewTextBoxColumn";
            this.qtdTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdTotalDataGridViewTextBoxColumn.Width = 70;
            // 
            // patrimonioDataGridViewTextBoxColumn
            // 
            this.patrimonioDataGridViewTextBoxColumn.DataPropertyName = "Patrimonio";
            this.patrimonioDataGridViewTextBoxColumn.HeaderText = "Patrimônio";
            this.patrimonioDataGridViewTextBoxColumn.Name = "patrimonioDataGridViewTextBoxColumn";
            this.patrimonioDataGridViewTextBoxColumn.ReadOnly = true;
            this.patrimonioDataGridViewTextBoxColumn.Width = 70;
            // 
            // ValorMedioCompraReal
            // 
            this.ValorMedioCompraReal.DataPropertyName = "ValorMedioCompraReal";
            this.ValorMedioCompraReal.HeaderText = "Valor Médio Compra";
            this.ValorMedioCompraReal.Name = "ValorMedioCompraReal";
            this.ValorMedioCompraReal.ReadOnly = true;
            this.ValorMedioCompraReal.Width = 70;
            // 
            // LucroReal
            // 
            this.LucroReal.DataPropertyName = "LucroReal";
            this.LucroReal.HeaderText = "Lucro Real";
            this.LucroReal.Name = "LucroReal";
            this.LucroReal.ReadOnly = true;
            this.LucroReal.Width = 70;
            // 
            // QtdVendavel
            // 
            this.QtdVendavel.DataPropertyName = "QtdVendavel";
            this.QtdVendavel.HeaderText = "Qtd Vendável";
            this.QtdVendavel.Name = "QtdVendavel";
            this.QtdVendavel.ReadOnly = true;
            this.QtdVendavel.Width = 70;
            // 
            // LucroImediato
            // 
            this.LucroImediato.DataPropertyName = "LucroImediato";
            this.LucroImediato.HeaderText = "Lucro Imediato";
            this.LucroImediato.Name = "LucroImediato";
            this.LucroImediato.ReadOnly = true;
            this.LucroImediato.Width = 70;
            // 
            // bindingSourceCotacoes
            // 
            this.bindingSourceCotacoes.AllowNew = false;
            this.bindingSourceCotacoes.DataSource = typeof(DataLayer.AtivoCotacao);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelAtualizadoEm,
            this.toolStripStatusLabelErros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1283, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelAtualizadoEm
            // 
            this.toolStripStatusLabelAtualizadoEm.Name = "toolStripStatusLabelAtualizadoEm";
            this.toolStripStatusLabelAtualizadoEm.Size = new System.Drawing.Size(109, 20);
            this.toolStripStatusLabelAtualizadoEm.Text = "Atualizado em:";
            // 
            // toolStripStatusLabelErros
            // 
            this.toolStripStatusLabelErros.Name = "toolStripStatusLabelErros";
            this.toolStripStatusLabelErros.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabelErros.Text = "Erros: 0";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1283, 748);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1283, 801);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTotal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvCotacoes, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1283, 748);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvTotal
            // 
            this.dgvTotal.AllowUserToAddRows = false;
            this.dgvTotal.AllowUserToDeleteRows = false;
            this.dgvTotal.AutoGenerateColumns = false;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotal.ColumnHeadersVisible = false;
            this.dgvTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0DataGridViewTextBoxColumn,
            this.col1DataGridViewTextBoxColumn,
            this.col2DataGridViewTextBoxColumn,
            this.col3DataGridViewTextBoxColumn,
            this.col4DataGridViewTextBoxColumn,
            this.col5DataGridViewTextBoxColumn,
            this.col6DataGridViewTextBoxColumn,
            this.col7DataGridViewTextBoxColumn,
            this.col8DataGridViewTextBoxColumn,
            this.col9DataGridViewTextBoxColumn,
            this.col10DataGridViewTextBoxColumn,
            this.col11DataGridViewTextBoxColumn,
            this.col12DataGridViewTextBoxColumn,
            this.col13DataGridViewTextBoxColumn,
            this.col14DataGridViewTextBoxColumn});
            this.dgvTotal.DataSource = this.bindingSourceTotal;
            this.dgvTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotal.Location = new System.Drawing.Point(4, 305);
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.RowHeadersWidth = 25;
            this.dgvTotal.RowTemplate.Height = 24;
            this.dgvTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTotal.Size = new System.Drawing.Size(1275, 25);
            this.dgvTotal.TabIndex = 2;
            this.dgvTotal.SelectionChanged += new System.EventHandler(this.dgvTotal_SelectionChanged);
            // 
            // col0DataGridViewTextBoxColumn
            // 
            this.col0DataGridViewTextBoxColumn.DataPropertyName = "Col0";
            this.col0DataGridViewTextBoxColumn.HeaderText = "Col0";
            this.col0DataGridViewTextBoxColumn.Name = "col0DataGridViewTextBoxColumn";
            this.col0DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col1DataGridViewTextBoxColumn
            // 
            this.col1DataGridViewTextBoxColumn.DataPropertyName = "Col1";
            this.col1DataGridViewTextBoxColumn.HeaderText = "Col1";
            this.col1DataGridViewTextBoxColumn.Name = "col1DataGridViewTextBoxColumn";
            this.col1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col2DataGridViewTextBoxColumn
            // 
            this.col2DataGridViewTextBoxColumn.DataPropertyName = "Col2";
            this.col2DataGridViewTextBoxColumn.HeaderText = "Col2";
            this.col2DataGridViewTextBoxColumn.Name = "col2DataGridViewTextBoxColumn";
            this.col2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col3DataGridViewTextBoxColumn
            // 
            this.col3DataGridViewTextBoxColumn.DataPropertyName = "Col3";
            this.col3DataGridViewTextBoxColumn.HeaderText = "Col3";
            this.col3DataGridViewTextBoxColumn.Name = "col3DataGridViewTextBoxColumn";
            this.col3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col4DataGridViewTextBoxColumn
            // 
            this.col4DataGridViewTextBoxColumn.DataPropertyName = "Col4";
            this.col4DataGridViewTextBoxColumn.HeaderText = "Col4";
            this.col4DataGridViewTextBoxColumn.Name = "col4DataGridViewTextBoxColumn";
            this.col4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col5DataGridViewTextBoxColumn
            // 
            this.col5DataGridViewTextBoxColumn.DataPropertyName = "Col5";
            this.col5DataGridViewTextBoxColumn.HeaderText = "Col5";
            this.col5DataGridViewTextBoxColumn.Name = "col5DataGridViewTextBoxColumn";
            this.col5DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col6DataGridViewTextBoxColumn
            // 
            this.col6DataGridViewTextBoxColumn.DataPropertyName = "Col6";
            this.col6DataGridViewTextBoxColumn.HeaderText = "Col6";
            this.col6DataGridViewTextBoxColumn.Name = "col6DataGridViewTextBoxColumn";
            this.col6DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col7DataGridViewTextBoxColumn
            // 
            this.col7DataGridViewTextBoxColumn.DataPropertyName = "Col7";
            this.col7DataGridViewTextBoxColumn.HeaderText = "Col7";
            this.col7DataGridViewTextBoxColumn.Name = "col7DataGridViewTextBoxColumn";
            this.col7DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col8DataGridViewTextBoxColumn
            // 
            this.col8DataGridViewTextBoxColumn.DataPropertyName = "Col8";
            this.col8DataGridViewTextBoxColumn.HeaderText = "Col8";
            this.col8DataGridViewTextBoxColumn.Name = "col8DataGridViewTextBoxColumn";
            this.col8DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col9DataGridViewTextBoxColumn
            // 
            this.col9DataGridViewTextBoxColumn.DataPropertyName = "Col9";
            this.col9DataGridViewTextBoxColumn.HeaderText = "Col9";
            this.col9DataGridViewTextBoxColumn.Name = "col9DataGridViewTextBoxColumn";
            this.col9DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col10DataGridViewTextBoxColumn
            // 
            this.col10DataGridViewTextBoxColumn.DataPropertyName = "Col10";
            this.col10DataGridViewTextBoxColumn.HeaderText = "Col10";
            this.col10DataGridViewTextBoxColumn.Name = "col10DataGridViewTextBoxColumn";
            this.col10DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col11DataGridViewTextBoxColumn
            // 
            this.col11DataGridViewTextBoxColumn.DataPropertyName = "Col11";
            this.col11DataGridViewTextBoxColumn.HeaderText = "Col11";
            this.col11DataGridViewTextBoxColumn.Name = "col11DataGridViewTextBoxColumn";
            this.col11DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col12DataGridViewTextBoxColumn
            // 
            this.col12DataGridViewTextBoxColumn.DataPropertyName = "Col12";
            this.col12DataGridViewTextBoxColumn.HeaderText = "Col12";
            this.col12DataGridViewTextBoxColumn.Name = "col12DataGridViewTextBoxColumn";
            this.col12DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col13DataGridViewTextBoxColumn
            // 
            this.col13DataGridViewTextBoxColumn.DataPropertyName = "Col13";
            this.col13DataGridViewTextBoxColumn.HeaderText = "Col13";
            this.col13DataGridViewTextBoxColumn.Name = "col13DataGridViewTextBoxColumn";
            this.col13DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col14DataGridViewTextBoxColumn
            // 
            this.col14DataGridViewTextBoxColumn.DataPropertyName = "Col14";
            this.col14DataGridViewTextBoxColumn.HeaderText = "Col14";
            this.col14DataGridViewTextBoxColumn.Name = "col14DataGridViewTextBoxColumn";
            this.col14DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceTotal
            // 
            this.bindingSourceTotal.DataSource = typeof(DataLayer.AtivoCotacaoTotal);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chart1.BorderSkin.BackImageTransparentColor = System.Drawing.Color.Black;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm";
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.Format = "N2";
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 337);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.Black;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1275, 407);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxConta,
            this.toolStripDropDownButtonAtivos,
            this.toolStripDropDownButtonFrequencia,
            this.toolStripButtonAtualizarSelecionados,
            this.toolStripButtonAtualizarTodos,
            this.toolStripButtonLerExtrato});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 28);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 25);
            this.toolStripLabel1.Text = "Conta:";
            // 
            // toolStripComboBoxConta
            // 
            this.toolStripComboBoxConta.AutoSize = false;
            this.toolStripComboBoxConta.Name = "toolStripComboBoxConta";
            this.toolStripComboBoxConta.Size = new System.Drawing.Size(90, 28);
            this.toolStripComboBoxConta.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxConta_SelectedIndexChanged);
            // 
            // toolStripDropDownButtonAtivos
            // 
            this.toolStripDropDownButtonAtivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripDropDownButtonAtivos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonAtivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCorrentes,
            this.ToolStripMenuItemJaNegociados,
            this.toolStripMenuItemTodos});
            this.toolStripDropDownButtonAtivos.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonAtivos.Image")));
            this.toolStripDropDownButtonAtivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAtivos.Name = "toolStripDropDownButtonAtivos";
            this.toolStripDropDownButtonAtivos.Size = new System.Drawing.Size(131, 25);
            this.toolStripDropDownButtonAtivos.Text = "Ativos Correntes";
            // 
            // toolStripMenuItemCorrentes
            // 
            this.toolStripMenuItemCorrentes.Checked = true;
            this.toolStripMenuItemCorrentes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemCorrentes.Name = "toolStripMenuItemCorrentes";
            this.toolStripMenuItemCorrentes.Size = new System.Drawing.Size(192, 26);
            this.toolStripMenuItemCorrentes.Tag = "2";
            this.toolStripMenuItemCorrentes.Text = "Ativos Correntes";
            // 
            // ToolStripMenuItemJaNegociados
            // 
            this.ToolStripMenuItemJaNegociados.Name = "ToolStripMenuItemJaNegociados";
            this.ToolStripMenuItemJaNegociados.Size = new System.Drawing.Size(192, 26);
            this.ToolStripMenuItemJaNegociados.Tag = "1";
            this.ToolStripMenuItemJaNegociados.Text = "Já Negociados";
            // 
            // toolStripMenuItemTodos
            // 
            this.toolStripMenuItemTodos.Name = "toolStripMenuItemTodos";
            this.toolStripMenuItemTodos.Size = new System.Drawing.Size(192, 26);
            this.toolStripMenuItemTodos.Tag = "0";
            this.toolStripMenuItemTodos.Text = "Todos os Ativos";
            // 
            // toolStripDropDownButtonFrequencia
            // 
            this.toolStripDropDownButtonFrequencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripDropDownButtonFrequencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFrequencia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1minuto,
            this.toolStripMenuItem5minutos,
            this.toolStripMenuItem10minutos,
            this.toolStripMenuItem15minutos,
            this.toolStripSeparator1,
            this.toolStripMenuItemDesligado});
            this.toolStripDropDownButtonFrequencia.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonFrequencia.Image")));
            this.toolStripDropDownButtonFrequencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFrequencia.Name = "toolStripDropDownButtonFrequencia";
            this.toolStripDropDownButtonFrequencia.Size = new System.Drawing.Size(167, 25);
            this.toolStripDropDownButtonFrequencia.Text = "Frequência: 5 minutos";
            this.toolStripDropDownButtonFrequencia.ToolTipText = "Frequência de atualização";
            // 
            // toolStripMenuItem1minuto
            // 
            this.toolStripMenuItem1minuto.Name = "toolStripMenuItem1minuto";
            this.toolStripMenuItem1minuto.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem1minuto.Tag = "1";
            this.toolStripMenuItem1minuto.Text = "1 minuto";
            // 
            // toolStripMenuItem5minutos
            // 
            this.toolStripMenuItem5minutos.Name = "toolStripMenuItem5minutos";
            this.toolStripMenuItem5minutos.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem5minutos.Tag = "5";
            this.toolStripMenuItem5minutos.Text = "5 minutos";
            // 
            // toolStripMenuItem10minutos
            // 
            this.toolStripMenuItem10minutos.Name = "toolStripMenuItem10minutos";
            this.toolStripMenuItem10minutos.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem10minutos.Tag = "10";
            this.toolStripMenuItem10minutos.Text = "10 minutos";
            // 
            // toolStripMenuItem15minutos
            // 
            this.toolStripMenuItem15minutos.Name = "toolStripMenuItem15minutos";
            this.toolStripMenuItem15minutos.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem15minutos.Tag = "15";
            this.toolStripMenuItem15minutos.Text = "15 minutos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItemDesligado
            // 
            this.toolStripMenuItemDesligado.Name = "toolStripMenuItemDesligado";
            this.toolStripMenuItemDesligado.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItemDesligado.Tag = "0";
            this.toolStripMenuItemDesligado.Text = "Desligado";
            // 
            // toolStripButtonAtualizarSelecionados
            // 
            this.toolStripButtonAtualizarSelecionados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripButtonAtualizarSelecionados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAtualizarSelecionados.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAtualizarSelecionados.Image")));
            this.toolStripButtonAtualizarSelecionados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAtualizarSelecionados.Name = "toolStripButtonAtualizarSelecionados";
            this.toolStripButtonAtualizarSelecionados.Size = new System.Drawing.Size(205, 25);
            this.toolStripButtonAtualizarSelecionados.Text = "Atualizar ativos selecionados";
            this.toolStripButtonAtualizarSelecionados.Click += new System.EventHandler(this.toolStripButtonAtualizar_Click);
            // 
            // toolStripButtonAtualizarTodos
            // 
            this.toolStripButtonAtualizarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStripButtonAtualizarTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAtualizarTodos.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAtualizarTodos.Image")));
            this.toolStripButtonAtualizarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAtualizarTodos.Name = "toolStripButtonAtualizarTodos";
            this.toolStripButtonAtualizarTodos.Size = new System.Drawing.Size(176, 25);
            this.toolStripButtonAtualizarTodos.Text = "Atualizar todos os ativos";
            this.toolStripButtonAtualizarTodos.Click += new System.EventHandler(this.toolStripButtonAtualizar_Click);
            // 
            // toolStripButtonLerExtrato
            // 
            this.toolStripButtonLerExtrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLerExtrato.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLerExtrato.Image")));
            this.toolStripButtonLerExtrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLerExtrato.Name = "toolStripButtonLerExtrato";
            this.toolStripButtonLerExtrato.Size = new System.Drawing.Size(84, 25);
            this.toolStripButtonLerExtrato.Text = "Ler Extrato";
            this.toolStripButtonLerExtrato.Click += new System.EventHandler(this.toolStripButtonLerExtrato_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Recebendo cotações de ações BOVESPA";
            this.notifyIcon1.BalloonTipTitle = "Cotações";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Cotações";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // frmCotacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 801);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCotacoes";
            this.Text = "Cotações em Tempo Real";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCotacoes_FormClosing);
            this.Load += new System.EventHandler(this.frmCotacoes_Load);
            this.Resize += new System.EventHandler(this.frmCotacoes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCotacoes)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceCotacoes;
        private System.Windows.Forms.DataGridView dgvCotacoes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAtualizadoEm;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.BindingSource bindingSourceTotal;
        private System.Windows.Forms.DataGridView dgvTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelErros;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxConta;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAtivos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCorrentes;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJaNegociados;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTodos;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFrequencia;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5minutos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1minuto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDesligado;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10minutos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15minutos;
        private System.Windows.Forms.ToolStripButton toolStripButtonAtualizarTodos;
        private System.Windows.Forms.ToolStripButton toolStripButtonAtualizarSelecionados;
        private System.Windows.Forms.ToolStripButton toolStripButtonLerExtrato;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col14DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastTradeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastTradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousCloseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changePercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayLowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayHighDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patrimonioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMedioCompraReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn LucroReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdVendavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn LucroImediato;
    }
}

