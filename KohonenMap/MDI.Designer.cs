namespace KohonenMap
{
    partial class MDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.WindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NodeSizeLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MapSizeLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.ClustersCount = new System.Windows.Forms.NumericUpDown();
            this.NodeSizeBox = new System.Windows.Forms.NumericUpDown();
            this.MapSizeBox = new System.Windows.Forms.NumericUpDown();
            this.FullRange = new System.Windows.Forms.ToolStripButton();
            this.RangeFromSample = new System.Windows.Forms.ToolStripButton();
            this.PixelMap = new System.Windows.Forms.ToolStripButton();
            this.HexagonMap = new System.Windows.Forms.ToolStripButton();
            this.ClusterMap = new System.Windows.Forms.ToolStripButton();
            this.Recalculate = new System.Windows.Forms.ToolStripButton();
            this.LoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.ParametersList = new System.Windows.Forms.ToolStripMenuItem();
            this.Cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.Horizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClustersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapSizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadData,
            this.ParametersList,
            this.WindowMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // WindowMenu
            // 
            this.WindowMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cascade,
            this.Horizontal,
            this.Vertical});
            this.WindowMenu.Name = "WindowMenu";
            this.WindowMenu.Size = new System.Drawing.Size(48, 20);
            this.WindowMenu.Text = "Окно";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = ".txt |";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FullRange,
            this.RangeFromSample,
            this.toolStripSeparator1,
            this.PixelMap,
            this.HexagonMap,
            this.ClusterMap,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.NodeSizeLabel,
            this.toolStripTextBox2,
            this.toolStripSeparator3,
            this.MapSizeLabel,
            this.toolStripTextBox3,
            this.Recalculate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 533);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(42, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NodeSizeLabel
            // 
            this.NodeSizeLabel.Name = "NodeSizeLabel";
            this.NodeSizeLabel.Size = new System.Drawing.Size(58, 22);
            this.NodeSizeLabel.Text = "Node size";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(42, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // MapSizeLabel
            // 
            this.MapSizeLabel.Name = "MapSizeLabel";
            this.MapSizeLabel.Size = new System.Drawing.Size(53, 22);
            this.MapSizeLabel.Text = "Map size";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(42, 25);
            // 
            // ClustersCount
            // 
            this.ClustersCount.Enabled = false;
            this.ClustersCount.Location = new System.Drawing.Point(486, 535);
            this.ClustersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ClustersCount.Name = "ClustersCount";
            this.ClustersCount.Size = new System.Drawing.Size(42, 20);
            this.ClustersCount.TabIndex = 6;
            this.ClustersCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ClustersCount.ValueChanged += new System.EventHandler(this.ClustersCount_ValueChanged);
            // 
            // NodeSizeBox
            // 
            this.NodeSizeBox.Enabled = false;
            this.NodeSizeBox.Location = new System.Drawing.Point(594, 535);
            this.NodeSizeBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NodeSizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NodeSizeBox.Name = "NodeSizeBox";
            this.NodeSizeBox.Size = new System.Drawing.Size(42, 20);
            this.NodeSizeBox.TabIndex = 7;
            this.NodeSizeBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NodeSizeBox.ValueChanged += new System.EventHandler(this.NodeSizeBox_ValueChanged);
            // 
            // MapSizeBox
            // 
            this.MapSizeBox.Enabled = false;
            this.MapSizeBox.Location = new System.Drawing.Point(697, 535);
            this.MapSizeBox.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.MapSizeBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MapSizeBox.Name = "MapSizeBox";
            this.MapSizeBox.Size = new System.Drawing.Size(42, 20);
            this.MapSizeBox.TabIndex = 8;
            this.MapSizeBox.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // FullRange
            // 
            this.FullRange.Image = global::KohonenMap.Properties.Resources.fullRange;
            this.FullRange.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FullRange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullRange.Name = "FullRange";
            this.FullRange.Size = new System.Drawing.Size(79, 22);
            this.FullRange.Text = "Full range";
            this.FullRange.Click += new System.EventHandler(this.FullRange_Click);
            // 
            // RangeFromSample
            // 
            this.RangeFromSample.Checked = true;
            this.RangeFromSample.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RangeFromSample.Image = global::KohonenMap.Properties.Resources.rangeFromSample;
            this.RangeFromSample.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RangeFromSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RangeFromSample.Name = "RangeFromSample";
            this.RangeFromSample.Size = new System.Drawing.Size(130, 22);
            this.RangeFromSample.Text = "Range from sample";
            this.RangeFromSample.Click += new System.EventHandler(this.RangeFromSample_Click);
            // 
            // PixelMap
            // 
            this.PixelMap.Image = global::KohonenMap.Properties.Resources.pixelMap;
            this.PixelMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PixelMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PixelMap.Name = "PixelMap";
            this.PixelMap.Size = new System.Drawing.Size(78, 22);
            this.PixelMap.Text = "Pixel map";
            this.PixelMap.Click += new System.EventHandler(this.PixelMap_Click);
            // 
            // HexagonMap
            // 
            this.HexagonMap.Checked = true;
            this.HexagonMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HexagonMap.Image = global::KohonenMap.Properties.Resources.hexagonMap;
            this.HexagonMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HexagonMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HexagonMap.Name = "HexagonMap";
            this.HexagonMap.Size = new System.Drawing.Size(101, 22);
            this.HexagonMap.Text = "Hexagon map";
            this.HexagonMap.Click += new System.EventHandler(this.HexagonMap_Click);
            // 
            // ClusterMap
            // 
            this.ClusterMap.Image = global::KohonenMap.Properties.Resources.clustMap;
            this.ClusterMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ClusterMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClusterMap.Name = "ClusterMap";
            this.ClusterMap.Size = new System.Drawing.Size(91, 22);
            this.ClusterMap.Text = "Cluster map";
            this.ClusterMap.Click += new System.EventHandler(this.ClusterMap_Click);
            // 
            // Recalculate
            // 
            this.Recalculate.Image = global::KohonenMap.Properties.Resources.reculct;
            this.Recalculate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Recalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Recalculate.Name = "Recalculate";
            this.Recalculate.Size = new System.Drawing.Size(97, 22);
            this.Recalculate.Text = "Пересчитать";
            this.Recalculate.Click += new System.EventHandler(this.Recalculate_Click);
            // 
            // LoadData
            // 
            this.LoadData.Image = global::KohonenMap.Properties.Resources.input_25064_640;
            this.LoadData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(133, 20);
            this.LoadData.Text = "Загрузить данные";
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // ParametersList
            // 
            this.ParametersList.Image = global::KohonenMap.Properties.Resources.netMini;
            this.ParametersList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ParametersList.Name = "ParametersList";
            this.ParametersList.Size = new System.Drawing.Size(61, 20);
            this.ParametersList.Text = "Сети";
            // 
            // Cascade
            // 
            this.Cascade.Image = global::KohonenMap.Properties.Resources.cas;
            this.Cascade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cascade.Name = "Cascade";
            this.Cascade.Size = new System.Drawing.Size(163, 22);
            this.Cascade.Text = "Каскад";
            this.Cascade.Click += new System.EventHandler(this.Cascade_Click);
            // 
            // Horizontal
            // 
            this.Horizontal.Image = global::KohonenMap.Properties.Resources.hor;
            this.Horizontal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Horizontal.Name = "Horizontal";
            this.Horizontal.Size = new System.Drawing.Size(163, 22);
            this.Horizontal.Text = "По горизонтали";
            this.Horizontal.Click += new System.EventHandler(this.Horizontal_Click);
            // 
            // Vertical
            // 
            this.Vertical.Image = global::KohonenMap.Properties.Resources.ver;
            this.Vertical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Vertical.Name = "Vertical";
            this.Vertical.Size = new System.Drawing.Size(163, 22);
            this.Vertical.Text = "По вертикали";
            this.Vertical.Click += new System.EventHandler(this.Vertical_Click);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 558);
            this.Controls.Add(this.MapSizeBox);
            this.Controls.Add(this.NodeSizeBox);
            this.Controls.Add(this.ClustersCount);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI";
            this.Text = "Карты Кохонена";
            this.Resize += new System.EventHandler(this.MDI_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClustersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapSizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LoadData;
        private System.Windows.Forms.ToolStripMenuItem ParametersList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem WindowMenu;
        private System.Windows.Forms.ToolStripMenuItem Cascade;
        private System.Windows.Forms.ToolStripMenuItem Horizontal;
        private System.Windows.Forms.ToolStripMenuItem Vertical;
        public System.Windows.Forms.ToolStripButton FullRange;
        public System.Windows.Forms.ToolStripButton RangeFromSample;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton PixelMap;
        public System.Windows.Forms.ToolStripButton HexagonMap;
        public System.Windows.Forms.ToolStripButton ClusterMap;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        public System.Windows.Forms.NumericUpDown NodeSizeBox;
        public System.Windows.Forms.NumericUpDown MapSizeBox;
        public System.Windows.Forms.ToolStripLabel NodeSizeLabel;
        public System.Windows.Forms.ToolStripLabel MapSizeLabel;
        public System.Windows.Forms.ToolStripButton Recalculate;
        public System.Windows.Forms.NumericUpDown ClustersCount;
        public System.Windows.Forms.ToolStrip toolStrip1;
    }
}