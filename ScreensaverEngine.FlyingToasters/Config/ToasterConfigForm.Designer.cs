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
            this.NumToasters = new System.Windows.Forms.NumericUpDown();
            this.OkButton = new System.Windows.Forms.Button();
            this.LTTCheckbox = new System.Windows.Forms.CheckBox();
            this.WTTCheckbox = new System.Windows.Forms.CheckBox();
            this.VWTTCheckbox = new System.Windows.Forms.CheckBox();
            this.BTCheckbox = new System.Windows.Forms.CheckBox();
            this.FTCheckbox = new System.Windows.Forms.CheckBox();
            this.MinimumSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MaximumSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumToasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of flying objects";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumToasters
            // 
            this.NumToasters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumToasters.Location = new System.Drawing.Point(178, 12);
            this.NumToasters.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.NumToasters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumToasters.Name = "NumToasters";
            this.NumToasters.Size = new System.Drawing.Size(94, 23);
            this.NumToasters.TabIndex = 2;
            this.NumToasters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(197, 226);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // LTTCheckbox
            // 
            this.LTTCheckbox.AutoSize = true;
            this.LTTCheckbox.Location = new System.Drawing.Point(12, 98);
            this.LTTCheckbox.Name = "LTTCheckbox";
            this.LTTCheckbox.Size = new System.Drawing.Size(133, 19);
            this.LTTCheckbox.TabIndex = 5;
            this.LTTCheckbox.Text = "Lightly toasted toast";
            this.LTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // WTTCheckbox
            // 
            this.WTTCheckbox.AutoSize = true;
            this.WTTCheckbox.Location = new System.Drawing.Point(12, 123);
            this.WTTCheckbox.Name = "WTTCheckbox";
            this.WTTCheckbox.Size = new System.Drawing.Size(120, 19);
            this.WTTCheckbox.TabIndex = 6;
            this.WTTCheckbox.Text = "Well toasted toast";
            this.WTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // VWTTCheckbox
            // 
            this.VWTTCheckbox.AutoSize = true;
            this.VWTTCheckbox.Location = new System.Drawing.Point(12, 148);
            this.VWTTCheckbox.Name = "VWTTCheckbox";
            this.VWTTCheckbox.Size = new System.Drawing.Size(143, 19);
            this.VWTTCheckbox.TabIndex = 7;
            this.VWTTCheckbox.Text = "Very well toasted toast";
            this.VWTTCheckbox.UseVisualStyleBackColor = true;
            // 
            // BTCheckbox
            // 
            this.BTCheckbox.AutoSize = true;
            this.BTCheckbox.Location = new System.Drawing.Point(12, 173);
            this.BTCheckbox.Name = "BTCheckbox";
            this.BTCheckbox.Size = new System.Drawing.Size(84, 19);
            this.BTCheckbox.TabIndex = 8;
            this.BTCheckbox.Text = "Burnt toast";
            this.BTCheckbox.UseVisualStyleBackColor = true;
            // 
            // FTCheckbox
            // 
            this.FTCheckbox.AutoSize = true;
            this.FTCheckbox.Location = new System.Drawing.Point(12, 198);
            this.FTCheckbox.Name = "FTCheckbox";
            this.FTCheckbox.Size = new System.Drawing.Size(102, 19);
            this.FTCheckbox.TabIndex = 9;
            this.FTCheckbox.Text = "Flying toasters";
            this.FTCheckbox.UseVisualStyleBackColor = true;
            // 
            // MinimumSpeed
            // 
            this.MinimumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimumSpeed.Location = new System.Drawing.Point(178, 35);
            this.MinimumSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MinimumSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinimumSpeed.Name = "MinimumSpeed";
            this.MinimumSpeed.Size = new System.Drawing.Size(94, 23);
            this.MinimumSpeed.TabIndex = 11;
            this.MinimumSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Minimum speed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaximumSpeed
            // 
            this.MaximumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximumSpeed.Location = new System.Drawing.Point(178, 58);
            this.MaximumSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaximumSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaximumSpeed.Name = "MaximumSpeed";
            this.MaximumSpeed.Size = new System.Drawing.Size(94, 23);
            this.MaximumSpeed.TabIndex = 13;
            this.MaximumSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Maximum speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToasterConfigForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.MaximumSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MinimumSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FTCheckbox);
            this.Controls.Add(this.BTCheckbox);
            this.Controls.Add(this.VWTTCheckbox);
            this.Controls.Add(this.WTTCheckbox);
            this.Controls.Add(this.LTTCheckbox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NumToasters);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToasterConfigForm";
            this.Text = "Flying Toasters Config";
            ((System.ComponentModel.ISupportInitialize)(this.NumToasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumToasters;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckBox LTTCheckbox;
        private System.Windows.Forms.CheckBox WTTCheckbox;
        private System.Windows.Forms.CheckBox VWTTCheckbox;
        private System.Windows.Forms.CheckBox BTCheckbox;
        private System.Windows.Forms.CheckBox FTCheckbox;
        private System.Windows.Forms.NumericUpDown MinimumSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MaximumSpeed;
        private System.Windows.Forms.Label label3;
    }
}