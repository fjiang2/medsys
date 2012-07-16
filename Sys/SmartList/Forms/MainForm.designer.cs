namespace Sys.SmartList.Forms
{
    partial class MainForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSearchBy = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonAddFavorite = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnInquiry = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.btnSwitchView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanelCollapse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditGridMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new Sys.ViewManager.Forms.TreeDpoView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbSearchBy,
            this.toolStripButtonAddFavorite,
            this.toolStripButtonRefresh,
            this.btnInquiry,
            this.toolStripButtonStop,
            this.btnPrint,
            this.btnPrintPreview,
            this.btnSwitchView,
            this.toolStripButtonPanelCollapse,
            this.toolStripButtonEditGridMode,
            this.toolStripButtonSave,
            this.toolStripButtonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1125, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Image = global::Sys.SmartList.Properties.Resources.ZoomHS;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "Find by";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.CausesValidation = false;
            this.cmbSearchBy.DropDownHeight = 150;
            this.cmbSearchBy.IntegralHeight = false;
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(200, 25);
            this.cmbSearchBy.TextChanged += new System.EventHandler(this.cmbSearchBy_TextChanged);
            // 
            // toolStripButtonAddFavorite
            // 
            this.toolStripButtonAddFavorite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddFavorite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFavorite.Image = global::Sys.SmartList.Properties.Resources.star;
            this.toolStripButtonAddFavorite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFavorite.Name = "toolStripButtonAddFavorite";
            this.toolStripButtonAddFavorite.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddFavorite.Text = "Add Favorite";
            this.toolStripButtonAddFavorite.ToolTipText = "Add/Edit Favorite";
            this.toolStripButtonAddFavorite.Click += new System.EventHandler(this.toolStripButtonAddFavorite_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::Sys.SmartList.Properties.Resources.RefreshDocViewHS;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.ToolTipText = "Refresh Smart List";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // btnInquiry
            // 
            this.btnInquiry.Image = global::Sys.SmartList.Properties.Resources.FormRunHS;
            this.btnInquiry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInquiry.Name = "btnInquiry";
            this.btnInquiry.Size = new System.Drawing.Size(64, 22);
            this.btnInquiry.Text = "Inquire";
            this.btnInquiry.ToolTipText = "Search Data in Database";
            this.btnInquiry.Click += new System.EventHandler(this.btnInquiry_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = global::Sys.SmartList.Properties.Resources.StopHS;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.ToolTipText = "Stop Loading Data";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Sys.SmartList.Properties.Resources.PrintHS;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 22);
            this.btnPrint.Text = "Print...";
            this.btnPrint.ToolTipText = "Preview, Print or Export Report";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::Sys.SmartList.Properties.Resources.PrintPreviewHS;
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(105, 22);
            this.btnPrintPreview.Text = "Print Preview...";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnSwitchView
            // 
            this.btnSwitchView.Image = global::Sys.SmartList.Properties.Resources.ShowGridlinesHS;
            this.btnSwitchView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSwitchView.Name = "btnSwitchView";
            this.btnSwitchView.Size = new System.Drawing.Size(109, 22);
            this.btnSwitchView.Text = "Show Grid View";
            this.btnSwitchView.Visible = false;
            this.btnSwitchView.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // toolStripButtonPanelCollapse
            // 
            this.toolStripButtonPanelCollapse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPanelCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanelCollapse.Image = global::Sys.SmartList.Properties.Resources.FillLeftHS;
            this.toolStripButtonPanelCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanelCollapse.Name = "toolStripButtonPanelCollapse";
            this.toolStripButtonPanelCollapse.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPanelCollapse.Text = "Collapse/Show Left Panel";
            this.toolStripButtonPanelCollapse.Click += new System.EventHandler(this.toolStripButtonPanelCollapse_Click);
            // 
            // toolStripButtonEditGridMode
            // 
            this.toolStripButtonEditGridMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEditGridMode.Image = global::Sys.SmartList.Properties.Resources.application_form_magnify;
            this.toolStripButtonEditGridMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditGridMode.Name = "toolStripButtonEditGridMode";
            this.toolStripButtonEditGridMode.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonEditGridMode.Text = "View Mode";
            this.toolStripButtonEditGridMode.ToolTipText = "Current Mode is View Mode";
            this.toolStripButtonEditGridMode.Visible = false;
            this.toolStripButtonEditGridMode.Click += new System.EventHandler(this.toolStripButtonEditGridMode_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = global::Sys.SmartList.Properties.Resources.saveHS;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save grid data to database";
            this.toolStripButtonSave.Visible = false;
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Image = global::Sys.SmartList.Properties.Resources.information;
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonAbout.Text = "Help";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1125, 645);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 9;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(269, 645);
            this.treeView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 670);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Smart List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnInquiry;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbSearchBy;
        private System.Windows.Forms.ToolStripButton btnSwitchView;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFavorite;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sys.ViewManager.Forms.TreeDpoView treeView1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanelCollapse;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditGridMode;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;

    }
}