namespace Investimentos {
    partial class frmBalanco {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTotal = new DataGridViewWithButtons.VBControls.DataGridViewWithButtons();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaCorrenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataSource1 = new EFWinforms.EntityDataSource(this.components);
            this.dgvBalanco = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdAssociadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorMedioCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorMedioCompraRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanco)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTotal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvBalanco, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 506);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgvTotal
            // 
            this.dgvTotal.AllowUserToAddRows = false;
            this.dgvTotal.AllowUserToDeleteRows = false;
            this.dgvTotal.AutoGenerateColumns = false;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotal.ColumnHeadersVisible = false;
            this.dgvTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column3,
            this.Column4,
            this.dataGridViewTextBoxColumn7,
            this.nomeDataGridViewTextBoxColumn,
            this.agenciaDataGridViewTextBoxColumn,
            this.contaCorrenteDataGridViewTextBoxColumn,
            this.senhaDataGridViewTextBoxColumn,
            this.infoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn11});
            this.dgvTotal.DataMember = "Contas";
            this.dgvTotal.DataSource = this.entityDataSource1;
            this.dgvTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotal.Enabled = false;
            this.dgvTotal.EnableHeadersVisualStyles = false;
            this.dgvTotal.Location = new System.Drawing.Point(3, 476);
            this.dgvTotal.MultiSelect = false;
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotal.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTotal.RowHeadersWidth = 25;
            this.dgvTotal.RowTemplate.Height = 24;
            this.dgvTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTotal.Size = new System.Drawing.Size(793, 27);
            this.dgvTotal.TabIndex = 4;
            this.dgvTotal.Tag = "9";
            this.dgvTotal.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvContas_RowsAdded);
            this.dgvTotal.SelectionChanged += new System.EventHandler(this.dgvContas_SelectionChanged);
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
            this.dataGridViewTextBoxColumn1.HeaderText = "1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle13.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn3.HeaderText = "3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn4.HeaderText = "4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn5.HeaderText = "5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LucroTotal";
            this.Column3.HeaderText = "7";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LucroTotalReal";
            this.Column4.HeaderText = "8";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ContaId";
            this.dataGridViewTextBoxColumn7.HeaderText = "ContaId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // agenciaDataGridViewTextBoxColumn
            // 
            this.agenciaDataGridViewTextBoxColumn.DataPropertyName = "Agencia";
            this.agenciaDataGridViewTextBoxColumn.HeaderText = "Agencia";
            this.agenciaDataGridViewTextBoxColumn.Name = "agenciaDataGridViewTextBoxColumn";
            this.agenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contaCorrenteDataGridViewTextBoxColumn
            // 
            this.contaCorrenteDataGridViewTextBoxColumn.DataPropertyName = "ContaCorrente";
            this.contaCorrenteDataGridViewTextBoxColumn.HeaderText = "ContaCorrente";
            this.contaCorrenteDataGridViewTextBoxColumn.Name = "contaCorrenteDataGridViewTextBoxColumn";
            this.contaCorrenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // senhaDataGridViewTextBoxColumn
            // 
            this.senhaDataGridViewTextBoxColumn.DataPropertyName = "Senha";
            this.senhaDataGridViewTextBoxColumn.HeaderText = "Senha";
            this.senhaDataGridViewTextBoxColumn.Name = "senhaDataGridViewTextBoxColumn";
            this.senhaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // infoDataGridViewTextBoxColumn
            // 
            this.infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            this.infoDataGridViewTextBoxColumn.HeaderText = "Info";
            this.infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            this.infoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LucroTotal";
            this.dataGridViewTextBoxColumn8.HeaderText = "LucroTotal";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "LucroTotalReal";
            this.dataGridViewTextBoxColumn11.HeaderText = "LucroTotalReal";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DataLayer.InvestimentosEntities);
            // 
            // dgvBalanco
            // 
            this.dgvBalanco.AllowUserToAddRows = false;
            this.dgvBalanco.AllowUserToDeleteRows = false;
            this.dgvBalanco.AutoGenerateColumns = false;
            this.dgvBalanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalanco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.Qtd,
            this.qtdAssociadaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn17,
            this.valorMedioCompraDataGridViewTextBoxColumn,
            this.valorMedioCompraRealDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvBalanco.DataMember = "Contas.Saidas";
            this.dgvBalanco.DataSource = this.entityDataSource1;
            this.dgvBalanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanco.Location = new System.Drawing.Point(3, 3);
            this.dgvBalanco.Name = "dgvBalanco";
            this.dgvBalanco.ReadOnly = true;
            this.dgvBalanco.RowHeadersWidth = 25;
            this.dgvBalanco.RowTemplate.Height = 24;
            this.dgvBalanco.Size = new System.Drawing.Size(793, 467);
            this.dgvBalanco.TabIndex = 5;
            this.dgvBalanco.Tag = "8";
            this.dgvBalanco.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendas_CellFormatting);
            this.dgvBalanco.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvBalanco_ColumnWidthChanged);
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn14.HeaderText = "Ativo";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Data";
            this.dataGridViewTextBoxColumn15.HeaderText = "Data";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // Qtd
            // 
            this.Qtd.DataPropertyName = "Qtd";
            this.Qtd.HeaderText = "Venda";
            this.Qtd.Name = "Qtd";
            this.Qtd.ReadOnly = true;
            // 
            // qtdAssociadaDataGridViewTextBoxColumn
            // 
            this.qtdAssociadaDataGridViewTextBoxColumn.DataPropertyName = "QtdAssociada";
            this.qtdAssociadaDataGridViewTextBoxColumn.HeaderText = "Compras";
            this.qtdAssociadaDataGridViewTextBoxColumn.Name = "qtdAssociadaDataGridViewTextBoxColumn";
            this.qtdAssociadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ValorReal";
            this.dataGridViewTextBoxColumn17.HeaderText = "Valor Venda";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // valorMedioCompraDataGridViewTextBoxColumn
            // 
            this.valorMedioCompraDataGridViewTextBoxColumn.DataPropertyName = "ValorMedioCompra";
            this.valorMedioCompraDataGridViewTextBoxColumn.HeaderText = "VM Compra";
            this.valorMedioCompraDataGridViewTextBoxColumn.Name = "valorMedioCompraDataGridViewTextBoxColumn";
            this.valorMedioCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorMedioCompraRealDataGridViewTextBoxColumn
            // 
            this.valorMedioCompraRealDataGridViewTextBoxColumn.DataPropertyName = "ValorMedioCompraReal";
            this.valorMedioCompraRealDataGridViewTextBoxColumn.HeaderText = "VM Real";
            this.valorMedioCompraRealDataGridViewTextBoxColumn.Name = "valorMedioCompraRealDataGridViewTextBoxColumn";
            this.valorMedioCompraRealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Lucro";
            this.dataGridViewTextBoxColumn9.HeaderText = "Lucro";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "LucroReal";
            this.dataGridViewTextBoxColumn10.HeaderText = "Lucro Real";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // frmBalanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(799, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBalanco";
            this.Text = "Balanço";
            this.Load += new System.EventHandler(this.Vendas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EFWinforms.EntityDataSource entityDataSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DataGridViewWithButtons.VBControls.DataGridViewWithButtons dgvTotal;
        private System.Windows.Forms.DataGridView dgvBalanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaCorrenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn infoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdAssociadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorMedioCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorMedioCompraRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}