namespace Sys.Platform.Forms
{
    partial class ImageViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSnapshot = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoom75 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoomCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonFitSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFitWidth = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFillWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSnapshot,
            this.toolStripDropDownButtonZoom,
            this.toolStripButtonFitSize,
            this.toolStripButtonFitWidth,
            this.toolStripButtonFillWindow,
            this.toolStripButtonRotateRight,
            this.toolStripButtonRotateLeft,
            this.toolStripButtonPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(604, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSnapshot
            // 
            this.toolStripButtonSnapshot.Enabled = false;
            this.toolStripButtonSnapshot.Image = global::Sys.Platform.Properties.Resources.camera;
            this.toolStripButtonSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSnapshot.Name = "toolStripButtonSnapshot";
            this.toolStripButtonSnapshot.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSnapshot.Text = "Snapshot";
            this.toolStripButtonSnapshot.Click += new System.EventHandler(this.toolStripButtonSnapshot_Click);
            // 
            // toolStripDropDownButtonZoom
            // 
            this.toolStripDropDownButtonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoom200,
            this.btnZoom100,
            this.btnZoom75,
            this.btnZoom50,
            this.btnZoom25,
            this.btnZoomCustom});
            this.toolStripDropDownButtonZoom.Image = global::Sys.Platform.Properties.Resources.ZoomHS;
            this.toolStripDropDownButtonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonZoom.Name = "toolStripDropDownButtonZoom";
            this.toolStripDropDownButtonZoom.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonZoom.Text = "Zoom";
            // 
            // btnZoom200
            // 
            this.btnZoom200.Name = "btnZoom200";
            this.btnZoom200.Size = new System.Drawing.Size(125, 22);
            this.btnZoom200.Text = "200%";
            this.btnZoom200.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoom100
            // 
            this.btnZoom100.Name = "btnZoom100";
            this.btnZoom100.Size = new System.Drawing.Size(125, 22);
            this.btnZoom100.Text = "100%";
            this.btnZoom100.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoom75
            // 
            this.btnZoom75.Name = "btnZoom75";
            this.btnZoom75.Size = new System.Drawing.Size(125, 22);
            this.btnZoom75.Text = "75%";
            this.btnZoom75.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoom50
            // 
            this.btnZoom50.Name = "btnZoom50";
            this.btnZoom50.Size = new System.Drawing.Size(125, 22);
            this.btnZoom50.Text = "50%";
            this.btnZoom50.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoom25
            // 
            this.btnZoom25.Name = "btnZoom25";
            this.btnZoom25.Size = new System.Drawing.Size(125, 22);
            this.btnZoom25.Text = "25%";
            this.btnZoom25.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoomCustom
            // 
            this.btnZoomCustom.Name = "btnZoomCustom";
            this.btnZoomCustom.Size = new System.Drawing.Size(125, 22);
            this.btnZoomCustom.Text = "Custom...";
            this.btnZoomCustom.Click += new System.EventHandler(this.btnZoomCustom_Click);
            // 
            // toolStripButtonFitSize
            // 
            this.toolStripButtonFitSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFitSize.Image = global::Sys.Platform.Properties.Resources.CanvasScaleHS;
            this.toolStripButtonFitSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFitSize.Name = "toolStripButtonFitSize";
            this.toolStripButtonFitSize.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFitSize.Text = "Fit Size";
            this.toolStripButtonFitSize.ToolTipText = "Fit to Screen";
            this.toolStripButtonFitSize.Click += new System.EventHandler(this.toolStripButtonFitSize_Click);
            // 
            // toolStripButtonFitWidth
            // 
            this.toolStripButtonFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFitWidth.Image = global::Sys.Platform.Properties.Resources.CenterAcrossHS;
            this.toolStripButtonFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFitWidth.Name = "toolStripButtonFitWidth";
            this.toolStripButtonFitWidth.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFitWidth.Text = "Fit Width";
            this.toolStripButtonFitWidth.ToolTipText = "Fit to Width";
            this.toolStripButtonFitWidth.Click += new System.EventHandler(this.toolStripButtonFitWidth_Click);
            // 
            // toolStripButtonFillWindow
            // 
            this.toolStripButtonFillWindow.Image = global::Sys.Platform.Properties.Resources.photo;
            this.toolStripButtonFillWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFillWindow.Name = "toolStripButtonFillWindow";
            this.toolStripButtonFillWindow.Size = new System.Drawing.Size(89, 22);
            this.toolStripButtonFillWindow.Text = "Fill Window";
            this.toolStripButtonFillWindow.Click += new System.EventHandler(this.toolStripButtonFillWindow_Click);
            // 
            // toolStripButtonRotateRight
            // 
            this.toolStripButtonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateRight.Image = global::Sys.Platform.Properties.Resources.Edit_RedoHS;
            this.toolStripButtonRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateRight.Name = "toolStripButtonRotateRight";
            this.toolStripButtonRotateRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateRight.Text = "Rotate Right";
            this.toolStripButtonRotateRight.ToolTipText = "Rotate Right";
            this.toolStripButtonRotateRight.Click += new System.EventHandler(this.toolStripButtonRotateRight_Click);
            // 
            // toolStripButtonRotateLeft
            // 
            this.toolStripButtonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateLeft.Image = global::Sys.Platform.Properties.Resources.Edit_UndoHS;
            this.toolStripButtonRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateLeft.Name = "toolStripButtonRotateLeft";
            this.toolStripButtonRotateLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateLeft.Text = "Rotate Left";
            this.toolStripButtonRotateLeft.ToolTipText = "Rotate Left";
            this.toolStripButtonRotateLeft.Click += new System.EventHandler(this.toolStripButtonRotateLeft_Click);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrint.Image = global::Sys.Platform.Properties.Resources.PrintHS;
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrint.Text = "Print Image";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(604, 375);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 406);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(604, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.RefreshItems += new System.EventHandler(this.bindingNavigator1_RefreshItems);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 375);
            this.panel1.TabIndex = 3;
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 431);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PictureForm";
            this.Text = "Image Viewer";
            this.SizeChanged += new System.EventHandler(this.PictureForm_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSnapshot;
        private System.Windows.Forms.ToolStripButton toolStripButtonFillWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFitSize;
        private System.Windows.Forms.ToolStripButton toolStripButtonFitWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonZoom;
        private System.Windows.Forms.ToolStripMenuItem btnZoom200;
        private System.Windows.Forms.ToolStripMenuItem btnZoom100;
        private System.Windows.Forms.ToolStripMenuItem btnZoom75;
        private System.Windows.Forms.ToolStripMenuItem btnZoom50;
        private System.Windows.Forms.ToolStripMenuItem btnZoom25;
        private System.Windows.Forms.ToolStripMenuItem btnZoomCustom;
    }
}