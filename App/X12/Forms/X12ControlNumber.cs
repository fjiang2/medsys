using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X12.File;

namespace X12.Forms
{
    public partial class X12ControlNumber : Form
    {
        X12File x12;

        public X12ControlNumber(X12File x12)
        {
            InitializeComponent();

            this.x12 = x12;

            this.txtInterchangeCtrlNum.Text = x12[SegmentType.ISA][0][13].Text;
            this.txtGroupCtrlNum.Text = x12[SegmentType.GS][0][6].Text;
            this.txtTransactionCtrlNum.Text = x12[SegmentType.ST][0][2].Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            x12[SegmentType.ISA][0][13].Value = this.txtInterchangeCtrlNum.Text;
            x12[SegmentType.IEA][0][2].Value = this.txtInterchangeCtrlNum.Text;

            x12[SegmentType.GS][0][6].Value = this.txtGroupCtrlNum.Text;
            x12[SegmentType.GE][0][2].Value = this.txtGroupCtrlNum.Text;

            x12[SegmentType.ST][0][2].Value = this.txtTransactionCtrlNum.Text;
            x12[SegmentType.SE][0][2].Value = this.txtTransactionCtrlNum.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
