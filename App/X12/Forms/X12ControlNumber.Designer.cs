namespace X12.Forms
{
    partial class X12ControlNumber
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtInterchangeCtrlNum = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtGroupCtrlNum = new System.Windows.Forms.TextBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTransactionCtrlNum = new System.Windows.Forms.TextBox();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this.txtTransactionCtrlNum);
            this.layoutControl1.Controls.Add(this.txtGroupCtrlNum);
            this.layoutControl1.Controls.Add(this.txtInterchangeCtrlNum);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(313, 278);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(313, 278);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtInterchangeCtrlNum
            // 
            this.txtInterchangeCtrlNum.Location = new System.Drawing.Point(169, 12);
            this.txtInterchangeCtrlNum.Name = "txtInterchangeCtrlNum";
            this.txtInterchangeCtrlNum.Size = new System.Drawing.Size(132, 20);
            this.txtInterchangeCtrlNum.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtInterchangeCtrlNum;
            this.layoutControlItem1.CustomizationFormText = "Interchange Control Number";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(293, 24);
            this.layoutControlItem1.Text = "Interchange Control Number";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(153, 13);
            // 
            // txtGroupCtrlNum
            // 
            this.txtGroupCtrlNum.Location = new System.Drawing.Point(169, 36);
            this.txtGroupCtrlNum.Name = "txtGroupCtrlNum";
            this.txtGroupCtrlNum.Size = new System.Drawing.Size(132, 20);
            this.txtGroupCtrlNum.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtGroupCtrlNum;
            this.layoutControlItem2.CustomizationFormText = "Group Control Number";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(293, 24);
            this.layoutControlItem2.Text = "Group Control Number";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(153, 13);
            // 
            // txtTransactionCtrlNum
            // 
            this.txtTransactionCtrlNum.Location = new System.Drawing.Point(169, 60);
            this.txtTransactionCtrlNum.Name = "txtTransactionCtrlNum";
            this.txtTransactionCtrlNum.Size = new System.Drawing.Size(132, 20);
            this.txtTransactionCtrlNum.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTransactionCtrlNum;
            this.layoutControlItem3.CustomizationFormText = "Transaction Set Control Number";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(293, 24);
            this.layoutControlItem3.Text = "Transaction Set Control Number";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(153, 13);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(152, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnOK;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 202);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(156, 36);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(156, 202);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(137, 36);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(293, 130);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 238);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(293, 20);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // X12ControlNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 278);
            this.Controls.Add(this.layoutControl1);
            this.Name = "X12ControlNumber";
            this.Text = "X12 Control Number";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTransactionCtrlNum;
        private System.Windows.Forms.TextBox txtGroupCtrlNum;
        private System.Windows.Forms.TextBox txtInterchangeCtrlNum;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}