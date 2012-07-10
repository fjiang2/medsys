namespace Sys.ViewManager.Forms
{
    partial class JSelectorTreeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bShrinkRestoreTop = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bShrinkRestoreBottom = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.jGridViewTop = new Sys.ViewManager.Forms.JGridView();
            this.jGridViewBottom = new Sys.ViewManager.Forms.JGridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(482, 313);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.jGridViewTop);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.jGridViewBottom);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(288, 313);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bShrinkRestoreTop);
            this.panel2.Controls.Add(this.bRemove);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(222, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(37, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(66, 156);
            this.panel2.TabIndex = 3;
            // 
            // bShrinkRestoreTop
            // 
            this.bShrinkRestoreTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShrinkRestoreTop.Location = new System.Drawing.Point(0, 0);
            this.bShrinkRestoreTop.MaximumSize = new System.Drawing.Size(0, 25);
            this.bShrinkRestoreTop.MinimumSize = new System.Drawing.Size(0, 25);
            this.bShrinkRestoreTop.Name = "bShrinkRestoreTop";
            this.bShrinkRestoreTop.Size = new System.Drawing.Size(0, 25);
            this.bShrinkRestoreTop.TabIndex = 2;
            this.bShrinkRestoreTop.Text = "Shrink";
            this.bShrinkRestoreTop.UseVisualStyleBackColor = true;
            this.bShrinkRestoreTop.Click += new System.EventHandler(this.bShrinkRestoreTop_Click);
            // 
            // bRemove
            // 
            this.bRemove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bRemove.Location = new System.Drawing.Point(0, 116);
            this.bRemove.MaximumSize = new System.Drawing.Size(66, 40);
            this.bRemove.MinimumSize = new System.Drawing.Size(66, 40);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(66, 40);
            this.bRemove.TabIndex = 1;
            this.bRemove.Text = "<<";
            this.bRemove.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bShrinkRestoreBottom);
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(222, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(37, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 153);
            this.panel1.TabIndex = 2;
            // 
            // bShrinkRestoreBottom
            // 
            this.bShrinkRestoreBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bShrinkRestoreBottom.Location = new System.Drawing.Point(0, 128);
            this.bShrinkRestoreBottom.MaximumSize = new System.Drawing.Size(66, 25);
            this.bShrinkRestoreBottom.MinimumSize = new System.Drawing.Size(66, 25);
            this.bShrinkRestoreBottom.Name = "bShrinkRestoreBottom";
            this.bShrinkRestoreBottom.Size = new System.Drawing.Size(66, 25);
            this.bShrinkRestoreBottom.TabIndex = 2;
            this.bShrinkRestoreBottom.Text = "Shrink";
            this.bShrinkRestoreBottom.UseVisualStyleBackColor = true;
            this.bShrinkRestoreBottom.Click += new System.EventHandler(this.bShrinkRestoreBottom_Click);
            // 
            // bAdd
            // 
            this.bAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.bAdd.Location = new System.Drawing.Point(0, 0);
            this.bAdd.MaximumSize = new System.Drawing.Size(66, 40);
            this.bAdd.MinimumSize = new System.Drawing.Size(66, 40);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(66, 40);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = ">>";
            this.bAdd.UseVisualStyleBackColor = true;
            // 
            // jGridViewTop
            // 
            this.jGridViewTop.DataSource = null;
            this.jGridViewTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jGridViewTop.Location = new System.Drawing.Point(0, 0);
            this.jGridViewTop.Name = "jGridViewTop";
            this.jGridViewTop.Size = new System.Drawing.Size(222, 156);
            this.jGridViewTop.TabIndex = 4;
            // 
            // jGridViewBottom
            // 
            this.jGridViewBottom.DataSource = null;
            this.jGridViewBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jGridViewBottom.Location = new System.Drawing.Point(0, 0);
            this.jGridViewBottom.Name = "jGridViewBottom";
            this.jGridViewBottom.Size = new System.Drawing.Size(222, 153);
            this.jGridViewBottom.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(190, 313);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // JSelectorTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "JSelectorTreeView";
            this.Size = new System.Drawing.Size(482, 313);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bShrinkRestoreBottom;
        private System.Windows.Forms.Button bShrinkRestoreTop;
        private JGridView jGridViewTop;
        private JGridView jGridViewBottom;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
