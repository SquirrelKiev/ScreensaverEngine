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
            this.ToasterCountLabel = new System.Windows.Forms.Label();
            this.NumToasters = new System.Windows.Forms.NumericUpDown();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumToasters)).BeginInit();
            this.SuspendLayout();
            // 
            // ToasterCountLabel
            // 
            this.ToasterCountLabel.AutoSize = true;
            this.ToasterCountLabel.Location = new System.Drawing.Point(12, 15);
            this.ToasterCountLabel.Name = "ToasterCountLabel";
            this.ToasterCountLabel.Size = new System.Drawing.Size(143, 15);
            this.ToasterCountLabel.TabIndex = 1;
            this.ToasterCountLabel.Text = "Number of Flying Objects";
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
            this.OkButton.Location = new System.Drawing.Point(197, 276);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // ToasterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NumToasters);
            this.Controls.Add(this.ToasterCountLabel);
            this.Name = "ToasterConfigForm";
            this.Text = "ConfigForm";
            ((System.ComponentModel.ISupportInitialize)(this.NumToasters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ToasterCountLabel;
        private System.Windows.Forms.NumericUpDown NumToasters;
        private System.Windows.Forms.Button OkButton;
    }
}