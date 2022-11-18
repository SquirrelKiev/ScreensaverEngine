namespace ScreensaverEngine.FlyingToasters
{
    partial class ToasterConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numToasters = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.LTTCheckbox = new System.Windows.Forms.CheckBox();
            this.WTTCheckbox = new System.Windows.Forms.CheckBox();
            this.VWTTCheckbox = new System.Windows.Forms.CheckBox();
            this.BTCheckbox = new System.Windows.Forms.CheckBox();
            this.FTCheckbox = new System.Windows.Forms.CheckBox();
            this.minimumSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.maximumSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numToasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumSpeed)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of flying objects";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumToasters
            // 
            this.numToasters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numToasters.Location = new System.Drawing.Point(169, 3);
            this.numToasters.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numToasters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numToasters.Name = "numToasters";
            this.numToasters.Size = new System.Drawing.Size(138, 23);
            this.numToasters.TabIndex = 2;
            this.numToasters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OkButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(247, 281);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // LTTCheckbox
            // 
            this.LTTCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LTTCheckbox.AutoSize = true;
            this.LTTCheckbox.Location = new System.Drawing.Point(3, 90);
            this.LTTCheckbox.Name = "LTTCheckbox";
            this.LTTCheckbox.Size = new System.Drawing.Size(160, 19);
            this.LTTCheckbox.TabIndex = 5;
            this.LTTCheckbox.Text = "Lightly toasted toast";
            this.LTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // WTTCheckbox
            // 
            this.WTTCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WTTCheckbox.AutoSize = true;
            this.WTTCheckbox.Location = new System.Drawing.Point(3, 115);
            this.WTTCheckbox.Name = "WTTCheckbox";
            this.WTTCheckbox.Size = new System.Drawing.Size(160, 19);
            this.WTTCheckbox.TabIndex = 6;
            this.WTTCheckbox.Text = "Well toasted toast";
            this.WTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // VWTTCheckbox
            // 
            this.VWTTCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VWTTCheckbox.AutoSize = true;
            this.VWTTCheckbox.Location = new System.Drawing.Point(3, 140);
            this.VWTTCheckbox.Name = "VWTTCheckbox";
            this.VWTTCheckbox.Size = new System.Drawing.Size(160, 19);
            this.VWTTCheckbox.TabIndex = 7;
            this.VWTTCheckbox.Text = "Very well toasted toast";
            this.VWTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // BTCheckbox
            // 
            this.BTCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTCheckbox.AutoSize = true;
            this.BTCheckbox.Location = new System.Drawing.Point(3, 165);
            this.BTCheckbox.Name = "BTCheckbox";
            this.BTCheckbox.Size = new System.Drawing.Size(160, 19);
            this.BTCheckbox.TabIndex = 8;
            this.BTCheckbox.Text = "Burnt toast";
            this.BTCheckbox.UseVisualStyleBackColor = true;
            // 
            // FTCheckbox
            // 
            this.FTCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FTCheckbox.AutoSize = true;
            this.FTCheckbox.Location = new System.Drawing.Point(3, 190);
            this.FTCheckbox.Name = "FTCheckbox";
            this.FTCheckbox.Size = new System.Drawing.Size(160, 19);
            this.FTCheckbox.TabIndex = 9;
            this.FTCheckbox.Text = "Flying toasters";
            this.FTCheckbox.UseVisualStyleBackColor = true;
            // 
            // MinimumSpeed
            // 
            this.minimumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumSpeed.Location = new System.Drawing.Point(169, 61);
            this.minimumSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minimumSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minimumSpeed.Name = "minimumSpeed";
            this.minimumSpeed.Size = new System.Drawing.Size(138, 23);
            this.minimumSpeed.TabIndex = 11;
            this.minimumSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Minimum speed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaximumSpeed
            // 
            this.maximumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumSpeed.Location = new System.Drawing.Point(169, 32);
            this.maximumSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximumSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maximumSpeed.Name = "maximumSpeed";
            this.maximumSpeed.Size = new System.Drawing.Size(138, 23);
            this.maximumSpeed.TabIndex = 13;
            this.maximumSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Maximum speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.FTCheckbox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.volumeSlider, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.BTCheckbox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.maximumSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.VWTTCheckbox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.WTTCheckbox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numToasters, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.minimumSpeed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LTTCheckbox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 263);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // volumeSlider
            // 
            this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeSlider.Location = new System.Drawing.Point(169, 215);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(138, 45);
            this.volumeSlider.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 51);
            this.label4.TabIndex = 15;
            this.label4.Text = "Volume";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToasterConfigForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 316);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToasterConfigForm";
            this.Text = "Flying Toasters Config";
            ((System.ComponentModel.ISupportInitialize)(this.numToasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumSpeed)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numToasters;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox LTTCheckbox;
        private System.Windows.Forms.CheckBox WTTCheckbox;
        private System.Windows.Forms.CheckBox VWTTCheckbox;
        private System.Windows.Forms.CheckBox BTCheckbox;
        private System.Windows.Forms.CheckBox FTCheckbox;
        private System.Windows.Forms.NumericUpDown minimumSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maximumSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar volumeSlider;
    }
}