namespace Investimentos {
    partial class frmVendas {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVendas = new DataGridViewWithButtons.VBControls.DataGridViewWithButtons();
            this.OperacaoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdComprada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VMCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VMCompraReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LucroReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvContas = new DataGridViewWithButtons.VBControls.DataGridViewWithButtons();
            this.qtdAntesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdCompradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdPendenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vMCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vMCompraRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lucroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lucroRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacaoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdAcumuladaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativoCorrenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.AutoGenerateColumns = false;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperacaoId,
            this.Codigo,
            this.Data,
            this.Qtd,
            this.QtdComprada,
            this.Valor,
            this.ValorReal,
            this.VMCompra,
            this.VMCompraReal,
            this.Lucro,
            this.LucroReal,
            this.qtdAntesDataGridViewTextBoxColumn,
            this.qtdCompradaDataGridViewTextBoxColumn,
            this.qtdPendenteDataGridViewTextBoxColumn,
            this.vMCompraDataGridViewTextBoxColumn,
            this.vMCompraRealDataGridViewTextBoxColumn,
            this.lucroDataGridViewTextBoxColumn,
            this.lucroRealDataGridViewTextBoxColumn,
            this.operacaoIdDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.qtdDataGridViewTextBoxColumn,
            this.qtdAcumuladaDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.valorRealDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.contaIdDataGridViewTextBoxColumn,
            this.ativoCorrenteDataGridViewTextBoxColumn,
            this.contaDataGridViewTextBoxColumn});
            this.dgvVendas.DataMember = "Contas.OperacoesDeSaida";
            this.dgvVendas.DataSource = this.entityDataSource1;
            this.dgvVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendas.EnableHeadersVisualStyles = false;
            this.dgvVendas.Location = new System.Drawing.Point(3, 3);
            this.dgvVendas.MultiSelect = false;
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVendas.RowHeadersWidth = 25;
            this.dgvVendas.RowTemplate.Height = 24;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(793, 467);
            this.dgvVendas.TabIndex = 3;
            this.dgvVendas.Tag = "9";
            this.dgvVendas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendas_CellFormatting);
            // 
            // OperacaoId
            // 
            this.OperacaoId.DataPropertyName = "OperacaoId";
            this.OperacaoId.HeaderText = "Op Id";
            this.OperacaoId.Name = "OperacaoId";
            this.OperacaoId.ReadOnly = true;
            this.OperacaoId.Width = 20;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Ativo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Qtd
            // 
            this.Qtd.DataPropertyName = "Qtd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.Qtd.DefaultCellStyle = dataGridViewCellStyle2;
            this.Qtd.HeaderText = "Venda";
            this.Qtd.Name = "Qtd";
            this.Qtd.ReadOnly = true;
            // 
            // QtdComprada
            // 
            this.QtdComprada.DataPropertyName = "QtdComprada";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.QtdComprada.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtdComprada.HeaderText = "Compras";
            this.QtdComprada.Name = "QtdComprada";
            this.QtdComprada.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // ValorReal
            // 
            this.ValorReal.DataPropertyName = "ValorReal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.ValorReal.DefaultCellStyle = dataGridViewCellStyle5;
            this.ValorReal.HeaderText = "Valor Real";
            this.ValorReal.Name = "ValorReal";
            this.ValorReal.ReadOnly = true;
            this.ValorReal.Visible = false;
            // 
            // VMCompra
            // 
            this.VMCompra.DataPropertyName = "VMCompra";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.VMCompra.DefaultCellStyle = dataGridViewCellStyle6;
            this.VMCompra.HeaderText = "VM Compra";
            this.VMCompra.Name = "VMCompra";
            this.VMCompra.ReadOnly = true;
            // 
            // VMCompraReal
            // 
            this.VMCompraReal.DataPropertyName = "VMCompraReal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.VMCompraReal.DefaultCellStyle = dataGridViewCellStyle7;
            this.VMCompraReal.HeaderText = "VM Real";
            this.VMCompraReal.Name = "VMCompraReal";
            this.VMCompraReal.ReadOnly = true;
            // 
            // Lucro
            // 
            this.Lucro.DataPropertyName = "Lucro";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.Lucro.DefaultCellStyle = dataGridViewCellStyle8;
            this.Lucro.HeaderText = "Lucro";
            this.Lucro.Name = "Lucro";
            this.Lucro.ReadOnly = true;
            // 
            // LucroReal
            // 
            this.LucroReal.DataPropertyName = "LucroReal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.LucroReal.DefaultCellStyle = dataGridViewCellStyle9;
            this.LucroReal.HeaderText = "Lucro Real";
            this.LucroReal.Name = "LucroReal";
            this.LucroReal.ReadOnly = true;
            this.LucroReal.Width = 120;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.InvestimentosEntities);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvContas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvVendas, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 506);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgvContas
            // 
            this.dgvContas.AllowUserToAddRows = false;
            this.dgvContas.AllowUserToDeleteRows = false;
            this.dgvContas.AutoGenerateColumns = false;
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.ColumnHeadersVisible = false;
            this.dgvContas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dgvContas.DataMember = "Contas";
            this.dgvContas.DataSource = this.entityDataSource1;
            this.dgvContas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContas.Enabled = false;
            this.dgvContas.EnableHeadersVisualStyles = false;
            this.dgvContas.Location = new System.Drawing.Point(3, 476);
            this.dgvContas.MultiSelect = false;
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContas.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvContas.RowHeadersWidth = 25;
            this.dgvContas.RowTemplate.Height = 24;
            this.dgvContas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvContas.Size = new System.Drawing.Size(793, 27);
            this.dgvContas.TabIndex = 4;
            this.dgvContas.Tag = "9";
            this.dgvContas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvContas_RowsAdded);
            this.dgvContas.SelectionChanged += new System.EventHandler(this.dgvContas_SelectionChanged);
            // 
            // qtdAntesDataGridViewTextBoxColumn
            // 
            this.qtdAntesDataGridViewTextBoxColumn.DataPropertyName = "QtdAntes";
            this.qtdAntesDataGridViewTextBoxColumn.HeaderText = "QtdAntes";
            this.qtdAntesDataGridViewTextBoxColumn.Name = "qtdAntesDataGridViewTextBoxColumn";
            this.qtdAntesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdCompradaDataGridViewTextBoxColumn
            // 
            this.qtdCompradaDataGridViewTextBoxColumn.DataPropertyName = "QtdComprada";
            this.qtdCompradaDataGridViewTextBoxColumn.HeaderText = "QtdComprada";
            this.qtdCompradaDataGridViewTextBoxColumn.Name = "qtdCompradaDataGridViewTextBoxColumn";
            this.qtdCompradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdPendenteDataGridViewTextBoxColumn
            // 
            this.qtdPendenteDataGridViewTextBoxColumn.DataPropertyName = "QtdPendente";
            this.qtdPendenteDataGridViewTextBoxColumn.HeaderText = "QtdPendente";
            this.qtdPendenteDataGridViewTextBoxColumn.Name = "qtdPendenteDataGridViewTextBoxColumn";
            this.qtdPendenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vMCompraDataGridViewTextBoxColumn
            // 
            this.vMCompraDataGridViewTextBoxColumn.DataPropertyName = "VMCompra";
            this.vMCompraDataGridViewTextBoxColumn.HeaderText = "VMCompra";
            this.vMCompraDataGridViewTextBoxColumn.Name = "vMCompraDataGridViewTextBoxColumn";
            this.vMCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vMCompraRealDataGridViewTextBoxColumn
            // 
            this.vMCompraRealDataGridViewTextBoxColumn.DataPropertyName = "VMCompraReal";
            this.vMCompraRealDataGridViewTextBoxColumn.HeaderText = "VMCompraReal";
            this.vMCompraRealDataGridViewTextBoxColumn.Name = "vMCompraRealDataGridViewTextBoxColumn";
            this.vMCompraRealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lucroDataGridViewTextBoxColumn
            // 
            this.lucroDataGridViewTextBoxColumn.DataPropertyName = "Lucro";
            this.lucroDataGridViewTextBoxColumn.HeaderText = "Lucro";
            this.lucroDataGridViewTextBoxColumn.Name = "lucroDataGridViewTextBoxColumn";
            this.lucroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lucroRealDataGridViewTextBoxColumn
            // 
            this.lucroRealDataGridViewTextBoxColumn.DataPropertyName = "LucroReal";
            this.lucroRealDataGridViewTextBoxColumn.HeaderText = "LucroReal";
            this.lucroRealDataGridViewTextBoxColumn.Name = "lucroRealDataGridViewTextBoxColumn";
            this.lucroRealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operacaoIdDataGridViewTextBoxColumn
            // 
            this.operacaoIdDataGridViewTextBoxColumn.DataPropertyName = "OperacaoId";
            this.operacaoIdDataGridViewTextBoxColumn.HeaderText = "OperacaoId";
            this.operacaoIdDataGridViewTextBoxColumn.Name = "operacaoIdDataGridViewTextBoxColumn";
            this.operacaoIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdDataGridViewTextBoxColumn
            // 
            this.qtdDataGridViewTextBoxColumn.DataPropertyName = "Qtd";
            this.qtdDataGridViewTextBoxColumn.HeaderText = "Qtd";
            this.qtdDataGridViewTextBoxColumn.Name = "qtdDataGridViewTextBoxColumn";
            this.qtdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdAcumuladaDataGridViewTextBoxColumn
            // 
            this.qtdAcumuladaDataGridViewTextBoxColumn.DataPropertyName = "QtdAcumulada";
            this.qtdAcumuladaDataGridViewTextBoxColumn.HeaderText = "QtdAcumulada";
            this.qtdAcumuladaDataGridViewTextBoxColumn.Name = "qtdAcumuladaDataGridViewTextBoxColumn";
            this.qtdAcumuladaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorRealDataGridViewTextBoxColumn
            // 
            this.valorRealDataGridViewTextBoxColumn.DataPropertyName = "ValorReal";
            this.valorRealDataGridViewTextBoxColumn.HeaderText = "ValorReal";
            this.valorRealDataGridViewTextBoxColumn.Name = "valorRealDataGridViewTextBoxColumn";
            this.valorRealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contaIdDataGridViewTextBoxColumn
            // 
            this.contaIdDataGridViewTextBoxColumn.DataPropertyName = "ContaId";
            this.contaIdDataGridViewTextBoxColumn.HeaderText = "ContaId";
            this.contaIdDataGridViewTextBoxColumn.Name = "contaIdDataGridViewTextBoxColumn";
            this.contaIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ativoCorrenteDataGridViewTextBoxColumn
            // 
            this.ativoCorrenteDataGridViewTextBoxColumn.DataPropertyName = "AtivoCorrente";
            this.ativoCorrenteDataGridViewTextBoxColumn.HeaderText = "AtivoCorrente";
            this.ativoCorrenteDataGridViewTextBoxColumn.Name = "ativoCorrenteDataGridViewTextBoxColumn";
            this.ativoCorrenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contaDataGridViewTextBoxColumn
            // 
            this.contaDataGridViewTextBoxColumn.DataPropertyName = "Conta";
            this.contaDataGridViewTextBoxColumn.HeaderText = "Conta";
            this.contaDataGridViewTextBoxColumn.Name = "contaDataGridViewTextBoxColumn";
            this.contaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ContaId";
            this.Column5.HeaderText = "0";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ContaId";
            this.dataGridViewTextBoxColumn1.HeaderText = "1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 24;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 24;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 24;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 24;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "7";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 24;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "8";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LucroTotal";
            this.Column3.HeaderText = "9";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LucroTotalReal";
            this.Column4.HeaderText = "10";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVendas";
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.Vendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EFWinforms.EntityDataSource entityDataSource1;
        private DataGridViewWithButtons.VBControls.DataGridViewWithButtons dgvVendas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DataGridViewWithButtons.VBControls.DataGridViewWithButtons dgvContas;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperacaoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdComprada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn VMCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn VMCompraReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn LucroReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdAntesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdCompradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdPendenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vMCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vMCompraRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lucroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lucroRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacaoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdAcumuladaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativoCorrenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}