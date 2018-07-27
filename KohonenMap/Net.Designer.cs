namespace KohonenMap
{
    partial class Net
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
            this.ScaleMin = new System.Windows.Forms.Label();
            this.ScaleMiddle = new System.Windows.Forms.Label();
            this.ScaleMax = new System.Windows.Forms.Label();
            this.RangeScale = new System.Windows.Forms.PictureBox();
            this.NetPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RangeScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ScaleMin
            // 
            this.ScaleMin.AutoSize = true;
            this.ScaleMin.Location = new System.Drawing.Point(23, 12);
            this.ScaleMin.Name = "ScaleMin";
            this.ScaleMin.Size = new System.Drawing.Size(13, 13);
            this.ScaleMin.TabIndex = 15;
            this.ScaleMin.Text = "0";
            // 
            // ScaleMiddle
            // 
            this.ScaleMiddle.AutoSize = true;
            this.ScaleMiddle.Location = new System.Drawing.Point(17, 116);
            this.ScaleMiddle.Name = "ScaleMiddle";
            this.ScaleMiddle.Size = new System.Drawing.Size(19, 13);
            this.ScaleMiddle.TabIndex = 16;
            this.ScaleMiddle.Text = "00";
            // 
            // ScaleMax
            // 
            this.ScaleMax.AutoSize = true;
            this.ScaleMax.Location = new System.Drawing.Point(12, 219);
            this.ScaleMax.Name = "ScaleMax";
            this.ScaleMax.Size = new System.Drawing.Size(25, 13);
            this.ScaleMax.TabIndex = 17;
            this.ScaleMax.Text = "000";
            // 
            // RangeScale
            // 
            this.RangeScale.BackColor = System.Drawing.Color.Transparent;
            this.RangeScale.Location = new System.Drawing.Point(35, 17);
            this.RangeScale.Name = "RangeScale";
            this.RangeScale.Size = new System.Drawing.Size(49, 211);
            this.RangeScale.TabIndex = 1;
            this.RangeScale.TabStop = false;
            this.RangeScale.Paint += new System.Windows.Forms.PaintEventHandler(this.RangeScale_Paint);
            // 
            // NetPicture
            // 
            this.NetPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NetPicture.BackColor = System.Drawing.Color.Transparent;
            this.NetPicture.Location = new System.Drawing.Point(102, 9);
            this.NetPicture.Name = "NetPicture";
            this.NetPicture.Size = new System.Drawing.Size(295, 241);
            this.NetPicture.TabIndex = 0;
            this.NetPicture.TabStop = false;
            this.NetPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.NetPicture_Paint);
            // 
            // Net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 250);
            this.Controls.Add(this.ScaleMax);
            this.Controls.Add(this.ScaleMiddle);
            this.Controls.Add(this.ScaleMin);
            this.Controls.Add(this.RangeScale);
            this.Controls.Add(this.NetPicture);
            this.Name = "Net";
            this.ShowIcon = false;
            this.Text = "Net";
            this.Activated += new System.EventHandler(this.Net_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Net_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.RangeScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox NetPicture;
        public System.Windows.Forms.PictureBox RangeScale;
        private System.Windows.Forms.Label ScaleMin;
        private System.Windows.Forms.Label ScaleMiddle;
        private System.Windows.Forms.Label ScaleMax;
    }
}