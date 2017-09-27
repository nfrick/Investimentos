namespace SerieHistorica {
    partial class frmCustomizeChart {
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
            this.colorPickerBackground = new LaMarvin.Windows.Forms.ColorPicker();
            this.colorPickerAxes = new LaMarvin.Windows.Forms.ColorPicker();
            this.colorPickerGrids = new LaMarvin.Windows.Forms.ColorPicker();
            this.colorPickerLegends = new LaMarvin.Windows.Forms.ColorPicker();
            this.colorPickerSerie = new LaMarvin.Windows.Forms.ColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.buttonInvert = new System.Windows.Forms.Button();
            this.comboBoxPallete = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorPickerAxesLabels = new LaMarvin.Windows.Forms.ColorPicker();
            this.SuspendLayout();
            // 
            // colorPickerBackground
            // 
            this.colorPickerBackground.Location = new System.Drawing.Point(139, 26);
            this.colorPickerBackground.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerBackground.Name = "colorPickerBackground";
            this.colorPickerBackground.Size = new System.Drawing.Size(125, 47);
            this.colorPickerBackground.TabIndex = 1;
            this.colorPickerBackground.ColorChanged += new System.EventHandler(this.colorPickerBackground_ColorChanged);
            // 
            // colorPickerAxes
            // 
            this.colorPickerAxes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerAxes.Location = new System.Drawing.Point(139, 81);
            this.colorPickerAxes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerAxes.Name = "colorPickerAxes";
            this.colorPickerAxes.Size = new System.Drawing.Size(125, 47);
            this.colorPickerAxes.TabIndex = 3;
            this.colorPickerAxes.ColorChanged += new System.EventHandler(this.colorPickerAxes_ColorChanged);
            // 
            // colorPickerGrids
            // 
            this.colorPickerGrids.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerGrids.Location = new System.Drawing.Point(139, 191);
            this.colorPickerGrids.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerGrids.Name = "colorPickerGrids";
            this.colorPickerGrids.Size = new System.Drawing.Size(125, 47);
            this.colorPickerGrids.TabIndex = 7;
            this.colorPickerGrids.ColorChanged += new System.EventHandler(this.colorPickerGrids_ColorChanged);
            // 
            // colorPickerLegends
            // 
            this.colorPickerLegends.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerLegends.Location = new System.Drawing.Point(139, 246);
            this.colorPickerLegends.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerLegends.Name = "colorPickerLegends";
            this.colorPickerLegends.Size = new System.Drawing.Size(125, 47);
            this.colorPickerLegends.TabIndex = 9;
            this.colorPickerLegends.ColorChanged += new System.EventHandler(this.colorPickerLegends_ColorChanged);
            // 
            // colorPickerSerie
            // 
            this.colorPickerSerie.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerSerie.Location = new System.Drawing.Point(139, 301);
            this.colorPickerSerie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerSerie.Name = "colorPickerSerie";
            this.colorPickerSerie.Size = new System.Drawing.Size(125, 47);
            this.colorPickerSerie.TabIndex = 11;
            this.colorPickerSerie.ColorChanged += new System.EventHandler(this.colorPickerSerie_ColorChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Background";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Axes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grids";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Legend text";
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Location = new System.Drawing.Point(22, 309);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(83, 31);
            this.comboBoxSeries.TabIndex = 10;
            this.comboBoxSeries.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeries_SelectedIndexChanged);
            // 
            // buttonInvert
            // 
            this.buttonInvert.Location = new System.Drawing.Point(21, 357);
            this.buttonInvert.Name = "buttonInvert";
            this.buttonInvert.Size = new System.Drawing.Size(243, 42);
            this.buttonInvert.TabIndex = 12;
            this.buttonInvert.Text = "Invert Background";
            this.buttonInvert.UseVisualStyleBackColor = true;
            this.buttonInvert.Click += new System.EventHandler(this.buttonInvert_Click);
            // 
            // comboBoxPallete
            // 
            this.comboBoxPallete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPallete.FormattingEnabled = true;
            this.comboBoxPallete.Location = new System.Drawing.Point(139, 413);
            this.comboBoxPallete.Name = "comboBoxPallete";
            this.comboBoxPallete.Size = new System.Drawing.Size(125, 31);
            this.comboBoxPallete.TabIndex = 14;
            this.comboBoxPallete.SelectedIndexChanged += new System.EventHandler(this.comboBoxPallete_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pallete";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Axes labels";
            // 
            // colorPickerAxesLabels
            // 
            this.colorPickerAxesLabels.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerAxesLabels.Location = new System.Drawing.Point(139, 136);
            this.colorPickerAxesLabels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPickerAxesLabels.Name = "colorPickerAxesLabels";
            this.colorPickerAxesLabels.Size = new System.Drawing.Size(125, 47);
            this.colorPickerAxesLabels.TabIndex = 5;
            this.colorPickerAxesLabels.ColorChanged += new System.EventHandler(this.colorPickerAxesLabels_ColorChanged);
            // 
            // frmCustomizeChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 467);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.colorPickerAxesLabels);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPallete);
            this.Controls.Add(this.buttonInvert);
            this.Controls.Add(this.comboBoxSeries);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorPickerSerie);
            this.Controls.Add(this.colorPickerLegends);
            this.Controls.Add(this.colorPickerGrids);
            this.Controls.Add(this.colorPickerAxes);
            this.Controls.Add(this.colorPickerBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCustomizeChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Customize Chart";
            this.Load += new System.EventHandler(this.frmCustomizeChart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LaMarvin.Windows.Forms.ColorPicker colorPickerBackground;
        private LaMarvin.Windows.Forms.ColorPicker colorPickerAxes;
        private LaMarvin.Windows.Forms.ColorPicker colorPickerGrids;
        private LaMarvin.Windows.Forms.ColorPicker colorPickerLegends;
        private LaMarvin.Windows.Forms.ColorPicker colorPickerSerie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSeries;
        private System.Windows.Forms.Button buttonInvert;
        private System.Windows.Forms.ComboBox comboBoxPallete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LaMarvin.Windows.Forms.ColorPicker colorPickerAxesLabels;
    }
}