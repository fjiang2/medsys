namespace X12.Forms
{
    partial class X12FileEditor
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.btnParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.comboSegments = new System.Windows.Forms.ToolStripComboBox();
            this.btnShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSpec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnControlNumber = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSegmentLine = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageX12 = new System.Windows.Forms.TabPage();
            this.segmentControl1 = new X12.Forms.X12SegmentControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageX12.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.btnParse,
            this.toolStripSeparator1,
            this.toolStripButtonSearch,
            this.comboSegments,
            this.btnShowGrid,
            this.toolStripButtonSpec,
            this.toolStripSeparator2,
            this.btnControlNumber,
            this.btnDeleteSegmentLine});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1118, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Image = global::X12.Properties.Resources.openHS;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonOpen.Text = "Open X12";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::X12.Properties.Resources.saveHS;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // btnParse
            // 
            this.btnParse.Image = global::X12.Properties.Resources.FormRunHS;
            this.btnParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(77, 22);
            this.btnParse.Text = "Parse X12";
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Image = global::X12.Properties.Resources.ZoomHS;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonSearch.Text = "Search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // comboSegments
            // 
            this.comboSegments.Name = "comboSegments";
            this.comboSegments.Size = new System.Drawing.Size(100, 25);
            this.comboSegments.TextChanged += new System.EventHandler(this.comboSegments_TextChanged);
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowGrid.Image = global::X12.Properties.Resources.ShowGridlines2HS;
            this.btnShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(23, 22);
            this.btnShowGrid.Text = "Grid Analyze";
            this.btnShowGrid.Click += new System.EventHandler(this.btnShowGrid_Click);
            // 
            // toolStripButtonSpec
            // 
            this.toolStripButtonSpec.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSpec.Image = global::X12.Properties.Resources.DocumentHS;
            this.toolStripButtonSpec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSpec.Name = "toolStripButtonSpec";
            this.toolStripButtonSpec.Size = new System.Drawing.Size(130, 22);
            this.toolStripButtonSpec.Text = "5010A Specification";
            this.toolStripButtonSpec.Click += new System.EventHandler(this.toolStripButtonSpec_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnControlNumber
            // 
            this.btnControlNumber.Image = global::X12.Properties.Resources.OptionsHS;
            this.btnControlNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnControlNumber.Name = "btnControlNumber";
            this.btnControlNumber.Size = new System.Drawing.Size(136, 22);
            this.btnControlNumber.Text = "X12 Control Number";
            this.btnControlNumber.Click += new System.EventHandler(this.btnControlNumber_Click);
            // 
            // btnDeleteSegmentLine
            // 
            this.btnDeleteSegmentLine.Image = global::X12.Properties.Resources.DeleteHS;
            this.btnDeleteSegmentLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSegmentLine.Name = "btnDeleteSegmentLine";
            this.btnDeleteSegmentLine.Size = new System.Drawing.Size(94, 22);
            this.btnDeleteSegmentLine.Text = "Delete Line...";
            this.btnDeleteSegmentLine.Click += new System.EventHandler(this.btnDeleteSegmentLine_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 819);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 11;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(308, 819);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageX12);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(806, 819);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageX12
            // 
            this.tabPageX12.Controls.Add(this.segmentControl1);
            this.tabPageX12.Location = new System.Drawing.Point(4, 22);
            this.tabPageX12.Name = "tabPageX12";
            this.tabPageX12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageX12.Size = new System.Drawing.Size(798, 793);
            this.tabPageX12.TabIndex = 0;
            this.tabPageX12.Text = "X12";
            this.tabPageX12.UseVisualStyleBackColor = true;
            // 
            // segmentControl1
            // 
            this.segmentControl1.AllowCellMerge = false;
            this.segmentControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentControl1.Location = new System.Drawing.Point(3, 3);
            this.segmentControl1.Name = "segmentControl1";
            this.segmentControl1.Size = new System.Drawing.Size(792, 787);
            this.segmentControl1.TabIndex = 0;
            // 
            // X12FileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 844);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X12FileEditor";
            this.Text = "X12 File Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageX12.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton btnShowGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageX12;
        private System.Windows.Forms.ToolStripComboBox comboSegments;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpec;
        private X12SegmentControl segmentControl1;
        private System.Windows.Forms.ToolStripButton btnControlNumber;
        private System.Windows.Forms.ToolStripButton btnParse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDeleteSegmentLine;
    }
}

