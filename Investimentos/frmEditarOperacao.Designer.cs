namespace Investimentos {
    partial class frmEditarOperacao {
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
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAtivo = new System.Windows.Forms.ComboBox();
            this.nudQtdPrevista = new System.Windows.Forms.NumericUpDown();
            this.nudQtdReal = new System.Windows.Forms.NumericUpDown();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.nudValorReal = new System.Windows.Forms.NumericUpDown();
            this.comboBoxOperacao = new System.Windows.Forms.ComboBox();
            this.labelAtivo = new System.Windows.Forms.Label();
            this.labelOperacao = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelQtdPrevista = new System.Windows.Forms.Label();
            this.labelQtdReal = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelValorReal = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdPrevista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorReal)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerData.Location = new System.Drawing.Point(108, 93);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.ShowUpDown = true;
            this.dateTimePickerData.Size = new System.Drawing.Size(139, 30);
            this.dateTimePickerData.TabIndex = 2;
            // 
            // comboBoxAtivo
            // 
            this.comboBoxAtivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAtivo.FormattingEnabled = true;
            this.comboBoxAtivo.Location = new System.Drawing.Point(108, 19);
            this.comboBoxAtivo.Name = "comboBoxAtivo";
            this.comboBoxAtivo.Size = new System.Drawing.Size(119, 31);
            this.comboBoxAtivo.TabIndex = 0;
            this.comboBoxAtivo.TextChanged += new System.EventHandler(this.combos_TextChanged);
            // 
            // nudQtdPrevista
            // 
            this.nudQtdPrevista.Location = new System.Drawing.Point(108, 129);
            this.nudQtdPrevista.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQtdPrevista.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdPrevista.Name = "nudQtdPrevista";
            this.nudQtdPrevista.Size = new System.Drawing.Size(118, 30);
            this.nudQtdPrevista.TabIndex = 3;
            this.nudQtdPrevista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQtdPrevista.ThousandsSeparator = true;
            this.nudQtdPrevista.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudQtdReal
            // 
            this.nudQtdReal.Location = new System.Drawing.Point(299, 130);
            this.nudQtdReal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQtdReal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdReal.Name = "nudQtdReal";
            this.nudQtdReal.Size = new System.Drawing.Size(118, 30);
            this.nudQtdReal.TabIndex = 4;
            this.nudQtdReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQtdReal.ThousandsSeparator = true;
            this.nudQtdReal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudValor
            // 
            this.nudValor.DecimalPlaces = 2;
            this.nudValor.Location = new System.Drawing.Point(108, 165);
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(118, 30);
            this.nudValor.TabIndex = 5;
            this.nudValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValor.ThousandsSeparator = true;
            // 
            // nudValorReal
            // 
            this.nudValorReal.DecimalPlaces = 2;
            this.nudValorReal.Location = new System.Drawing.Point(299, 166);
            this.nudValorReal.Name = "nudValorReal";
            this.nudValorReal.Size = new System.Drawing.Size(118, 30);
            this.nudValorReal.TabIndex = 6;
            this.nudValorReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValorReal.ThousandsSeparator = true;
            // 
            // comboBoxOperacao
            // 
            this.comboBoxOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperacao.FormattingEnabled = true;
            this.comboBoxOperacao.Location = new System.Drawing.Point(107, 56);
            this.comboBoxOperacao.Name = "comboBoxOperacao";
            this.comboBoxOperacao.Size = new System.Drawing.Size(119, 31);
            this.comboBoxOperacao.TabIndex = 1;
            this.comboBoxOperacao.TextChanged += new System.EventHandler(this.combos_TextChanged);
            // 
            // labelAtivo
            // 
            this.labelAtivo.AutoSize = true;
            this.labelAtivo.BackColor = System.Drawing.Color.Transparent;
            this.labelAtivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelAtivo.Location = new System.Drawing.Point(18, 22);
            this.labelAtivo.Name = "labelAtivo";
            this.labelAtivo.Size = new System.Drawing.Size(49, 23);
            this.labelAtivo.TabIndex = 9;
            this.labelAtivo.Text = "Ativo";
            // 
            // labelOperacao
            // 
            this.labelOperacao.AutoSize = true;
            this.labelOperacao.BackColor = System.Drawing.Color.Transparent;
            this.labelOperacao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelOperacao.Location = new System.Drawing.Point(18, 59);
            this.labelOperacao.Name = "labelOperacao";
            this.labelOperacao.Size = new System.Drawing.Size(84, 23);
            this.labelOperacao.TabIndex = 10;
            this.labelOperacao.Text = "Operação";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.BackColor = System.Drawing.Color.Transparent;
            this.labelData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelData.Location = new System.Drawing.Point(18, 99);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(46, 23);
            this.labelData.TabIndex = 11;
            this.labelData.Text = "Data";
            // 
            // labelQtdPrevista
            // 
            this.labelQtdPrevista.AutoSize = true;
            this.labelQtdPrevista.BackColor = System.Drawing.Color.Transparent;
            this.labelQtdPrevista.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelQtdPrevista.Location = new System.Drawing.Point(18, 134);
            this.labelQtdPrevista.Name = "labelQtdPrevista";
            this.labelQtdPrevista.Size = new System.Drawing.Size(103, 23);
            this.labelQtdPrevista.TabIndex = 12;
            this.labelQtdPrevista.Text = "Qtd Prevista";
            // 
            // labelQtdReal
            // 
            this.labelQtdReal.AutoSize = true;
            this.labelQtdReal.BackColor = System.Drawing.Color.Transparent;
            this.labelQtdReal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelQtdReal.Location = new System.Drawing.Point(255, 134);
            this.labelQtdReal.Name = "labelQtdReal";
            this.labelQtdReal.Size = new System.Drawing.Size(42, 23);
            this.labelQtdReal.TabIndex = 14;
            this.labelQtdReal.Text = "Real";
            this.labelQtdReal.Click += new System.EventHandler(this.labelQtdReal_Click);
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.BackColor = System.Drawing.Color.Transparent;
            this.labelValor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelValor.Location = new System.Drawing.Point(18, 167);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(49, 23);
            this.labelValor.TabIndex = 13;
            this.labelValor.Text = "Valor";
            // 
            // labelValorReal
            // 
            this.labelValorReal.AutoSize = true;
            this.labelValorReal.BackColor = System.Drawing.Color.Transparent;
            this.labelValorReal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelValorReal.Location = new System.Drawing.Point(254, 167);
            this.labelValorReal.Name = "labelValorReal";
            this.labelValorReal.Size = new System.Drawing.Size(42, 23);
            this.labelValorReal.TabIndex = 15;
            this.labelValorReal.Text = "Real";
            this.labelValorReal.Click += new System.EventHandler(this.labelValorReal_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonOK.Location = new System.Drawing.Point(362, 19);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(55, 42);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "ü";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.Red;
            this.buttonCancelar.Location = new System.Drawing.Point(362, 63);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(55, 42);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "û";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // frmEditarOperacao
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(434, 209);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelValorReal);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelQtdReal);
            this.Controls.Add(this.labelQtdPrevista);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelOperacao);
            this.Controls.Add(this.labelAtivo);
            this.Controls.Add(this.comboBoxOperacao);
            this.Controls.Add(this.nudValorReal);
            this.Controls.Add(this.nudValor);
            this.Controls.Add(this.nudQtdReal);
            this.Controls.Add(this.nudQtdPrevista);
            this.Controls.Add(this.comboBoxAtivo);
            this.Controls.Add(this.dateTimePickerData);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditarOperacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Operação";
            this.Load += new System.EventHandler(this.EditarOperacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdPrevista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorReal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerData;
        private System.Windows.Forms.ComboBox comboBoxAtivo;
        private System.Windows.Forms.NumericUpDown nudQtdPrevista;
        private System.Windows.Forms.NumericUpDown nudQtdReal;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.NumericUpDown nudValorReal;
        private System.Windows.Forms.ComboBox comboBoxOperacao;
        private System.Windows.Forms.Label labelAtivo;
        private System.Windows.Forms.Label labelOperacao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelQtdPrevista;
        private System.Windows.Forms.Label labelQtdReal;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelValorReal;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancelar;
    }
}