namespace Investimentos {
    partial class frmConta {
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
            this.labelNome = new System.Windows.Forms.Label();
            this.labelAgencia = new System.Windows.Forms.Label();
            this.labelContaCorrente = new System.Windows.Forms.Label();
            this.labelSenha = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.maskedTextBoxAgencia = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxContaCorrente = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 9);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(53, 21);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome";
            // 
            // labelAgencia
            // 
            this.labelAgencia.AutoSize = true;
            this.labelAgencia.Location = new System.Drawing.Point(13, 49);
            this.labelAgencia.Name = "labelAgencia";
            this.labelAgencia.Size = new System.Drawing.Size(65, 21);
            this.labelAgencia.TabIndex = 1;
            this.labelAgencia.Text = "Agência";
            // 
            // labelContaCorrente
            // 
            this.labelContaCorrente.AutoSize = true;
            this.labelContaCorrente.Location = new System.Drawing.Point(14, 89);
            this.labelContaCorrente.Name = "labelContaCorrente";
            this.labelContaCorrente.Size = new System.Drawing.Size(51, 21);
            this.labelContaCorrente.TabIndex = 2;
            this.labelContaCorrente.Text = "Conta";
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(14, 129);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(53, 21);
            this.labelSenha.TabIndex = 3;
            this.labelSenha.Text = "Senha";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(14, 169);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(37, 21);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "Info";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(111, 6);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(109, 29);
            this.textBoxNome.TabIndex = 0;
            this.textBoxNome.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(111, 126);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(109, 29);
            this.textBoxSenha.TabIndex = 3;
            this.textBoxSenha.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(111, 166);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(363, 106);
            this.textBoxInfo.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.Red;
            this.buttonCancelar.Location = new System.Drawing.Point(419, 56);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(55, 42);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "û";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonOK.Location = new System.Drawing.Point(419, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(55, 42);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "ü";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // maskedTextBoxAgencia
            // 
            this.maskedTextBoxAgencia.Location = new System.Drawing.Point(111, 47);
            this.maskedTextBoxAgencia.Mask = "0000-0";
            this.maskedTextBoxAgencia.Name = "maskedTextBoxAgencia";
            this.maskedTextBoxAgencia.Size = new System.Drawing.Size(109, 29);
            this.maskedTextBoxAgencia.TabIndex = 7;
            this.maskedTextBoxAgencia.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxContaCorrente
            // 
            this.maskedTextBoxContaCorrente.Location = new System.Drawing.Point(111, 86);
            this.maskedTextBoxContaCorrente.Mask = "90000-&";
            this.maskedTextBoxContaCorrente.Name = "maskedTextBoxContaCorrente";
            this.maskedTextBoxContaCorrente.Size = new System.Drawing.Size(109, 29);
            this.maskedTextBoxContaCorrente.TabIndex = 8;
            this.maskedTextBoxContaCorrente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // frmConta
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(486, 284);
            this.Controls.Add(this.maskedTextBoxContaCorrente);
            this.Controls.Add(this.maskedTextBoxAgencia);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelContaCorrente);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelAgencia);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conta de Investimento";
            this.Load += new System.EventHandler(this.frmConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelAgencia;
        private System.Windows.Forms.Label labelContaCorrente;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAgencia;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxContaCorrente;
    }
}