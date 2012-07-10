namespace Sys.ViewManager.Forms
{
    partial class JSelector
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
			this.components = new System.ComponentModel.Container();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.chkCellMerge = new System.Windows.Forms.CheckBox();
			this.chkHideRight = new System.Windows.Forms.CheckBox();
			this.chkHideLeft = new System.Windows.Forms.CheckBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.gridView1 = new Sys.ViewManager.Forms.JGridView();
			this.gridView2 = new Sys.ViewManager.Forms.JGridView();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.gridView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(916, 531);
			this.splitContainer1.SplitterDistance = 398;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.chkCellMerge);
			this.splitContainer2.Panel1.Controls.Add(this.chkHideRight);
			this.splitContainer2.Panel1.Controls.Add(this.chkHideLeft);
			this.splitContainer2.Panel1.Controls.Add(this.buttonAdd);
			this.splitContainer2.Panel1.Controls.Add(this.buttonRemove);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.gridView2);
			this.splitContainer2.Size = new System.Drawing.Size(514, 531);
			this.splitContainer2.SplitterDistance = 87;
			this.splitContainer2.TabIndex = 0;
			// 
			// chkCellMerge
			// 
			this.chkCellMerge.AutoSize = true;
			this.chkCellMerge.Location = new System.Drawing.Point(6, 446);
			this.chkCellMerge.Name = "chkCellMerge";
			this.chkCellMerge.Size = new System.Drawing.Size(56, 17);
			this.chkCellMerge.TabIndex = 5;
			this.chkCellMerge.Text = "Merge";
			this.chkCellMerge.UseVisualStyleBackColor = true;
			this.chkCellMerge.CheckedChanged += new System.EventHandler(this.chkCellMerge_CheckedChanged);
			// 
			// chkHideRight
			// 
			this.chkHideRight.AutoSize = true;
			this.chkHideRight.Location = new System.Drawing.Point(6, 372);
			this.chkHideRight.Name = "chkHideRight";
			this.chkHideRight.Size = new System.Drawing.Size(76, 17);
			this.chkHideRight.TabIndex = 4;
			this.chkHideRight.Text = "Hide Right";
			this.chkHideRight.UseVisualStyleBackColor = true;
			this.chkHideRight.CheckedChanged += new System.EventHandler(this.chkHideRight_CheckedChanged);
			// 
			// chkHideLeft
			// 
			this.chkHideLeft.AutoSize = true;
			this.chkHideLeft.Location = new System.Drawing.Point(6, 349);
			this.chkHideLeft.Name = "chkHideLeft";
			this.chkHideLeft.Size = new System.Drawing.Size(69, 17);
			this.chkHideLeft.TabIndex = 4;
			this.chkHideLeft.Text = "Hide Left";
			this.chkHideLeft.UseVisualStyleBackColor = true;
			this.chkHideLeft.CheckedChanged += new System.EventHandler(this.chkHideLeft_CheckedChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Location = new System.Drawing.Point(11, 234);
			this.buttonAdd.MaximumSize = new System.Drawing.Size(66, 39);
			this.buttonAdd.MinimumSize = new System.Drawing.Size(66, 39);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(66, 39);
			this.buttonAdd.TabIndex = 3;
			this.buttonAdd.Text = "<<";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.Location = new System.Drawing.Point(10, 288);
			this.buttonRemove.MaximumSize = new System.Drawing.Size(66, 39);
			this.buttonRemove.MinimumSize = new System.Drawing.Size(66, 39);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(66, 39);
			this.buttonRemove.TabIndex = 2;
			this.buttonRemove.Text = ">>";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// gridView1
			// 
			this.gridView1.DataSource = null;
			this.gridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridView1.Location = new System.Drawing.Point(0, 0);
			this.gridView1.Name = "gridView1";
			this.gridView1.Size = new System.Drawing.Size(398, 531);
			this.gridView1.TabIndex = 0;
			// 
			// gridView2
			// 
			this.gridView2.DataSource = null;
			this.gridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridView2.Location = new System.Drawing.Point(0, 0);
			this.gridView2.Name = "gridView2";
			this.gridView2.Size = new System.Drawing.Size(423, 531);
			this.gridView2.TabIndex = 0;
			// 
			// JSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "JSelector";
			this.Size = new System.Drawing.Size(916, 531);
			this.Resize += new System.EventHandler(this.JSelector_Resize);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private Sys.ViewManager.Forms.JGridView gridView1;
        private Sys.ViewManager.Forms.JGridView gridView2;
        private System.Windows.Forms.CheckBox chkHideRight;
        private System.Windows.Forms.CheckBox chkHideLeft;
		private System.Windows.Forms.CheckBox chkCellMerge;
    }
}
