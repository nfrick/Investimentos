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
            this.components = new System.ComponentModel.Container();
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
            this.textBoxAgencia = new System.Windows.Forms.TextBox();
            this.textBoxContaCorrente = new System.Windows.Forms.TextBox();
            this.textBoxOperacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.labelAgencia.Location = new System.Drawing.Point(12, 44);
            this.labelAgencia.Name = "labelAgencia";
            this.labelAgencia.Size = new System.Drawing.Size(65, 21);
            this.labelAgencia.TabIndex = 1;
            this.labelAgencia.Text = "Agência";
            // 
            // labelContaCorrente
            // 
            this.labelContaCorrente.AutoSize = true;
            this.labelContaCorrente.Location = new System.Drawing.Point(14, 77);
            this.labelContaCorrente.Name = "labelContaCorrente";
            this.labelContaCorrente.Size = new System.Drawing.Size(51, 21);
            this.labelContaCorrente.TabIndex = 2;
            this.labelContaCorrente.Text = "Conta";
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(12, 148);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(53, 21);
            this.labelSenha.TabIndex = 4;
            this.labelSenha.Text = "Senha";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(14, 181);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(37, 21);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Info";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(111, 6);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(181, 29);
            this.textBoxNome.TabIndex = 6;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(111, 146);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(181, 29);
            this.textBoxSenha.TabIndex = 10;
            this.textBoxSenha.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSenha_Validating);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(111, 181);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(363, 106);
            this.textBoxInfo.TabIndex = 11;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.Red;
            this.buttonCancelar.Location = new System.Drawing.Point(419, 56);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(55, 42);
            this.buttonCancelar.TabIndex = 13;
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
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "ü";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxAgencia
            // 
            this.textBoxAgencia.Location = new System.Drawing.Point(111, 41);
            this.textBoxAgencia.Name = "textBoxAgencia";
            this.textBoxAgencia.Size = new System.Drawing.Size(181, 29);
            this.textBoxAgencia.TabIndex = 7;
            this.textBoxAgencia.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAgencia_Validating);
            // 
            // textBoxContaCorrente
            // 
            this.textBoxContaCorrente.Location = new System.Drawing.Point(111, 76);
            this.textBoxContaCorrente.Name = "textBoxContaCorrente";
            this.textBoxContaCorrente.Size = new System.Drawing.Size(181, 29);
            this.textBoxContaCorrente.TabIndex = 8;
            this.textBoxContaCorrente.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxConta_Validating);
            // 
            // textBoxOperacao
            // 
            this.textBoxOperacao.Location = new System.Drawing.Point(111, 111);
            this.textBoxOperacao.Name = "textBoxOperacao";
            this.textBoxOperacao.Size = new System.Drawing.Size(181, 29);
            this.textBoxOperacao.TabIndex = 9;
            this.textBoxOperacao.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxOperacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Operação";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataMember = "";
            // 
            // frmConta
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(486, 305);
            this.Controls.Add(this.textBoxOperacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxContaCorrente);
            this.Controls.Add(this.textBoxAgencia);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxAgencia;
        private System.Windows.Forms.TextBox textBoxContaCorrente;
        private System.Windows.Forms.TextBox textBoxOperacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}