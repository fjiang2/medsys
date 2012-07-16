using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using X12.Dpo;

namespace X12.Forms
{
    public partial class SpecSegment2Control : BaseUserControl
    {
        BindDpo<X12SegmentInstanceDpo> bind;

        public SpecSegment2Control()
        {
            InitializeComponent();

            bind = new BindDpo<X12SegmentInstanceDpo>();

            bind.Bind(this.txtSegmentName, X12SegmentInstanceDpo._Name);
            bind.Bind(this.txtLoop, X12SegmentInstanceDpo._LoopName);
            bind.Bind(this.txtDescription, X12SegmentInstanceDpo._Description);
            bind.Bind(this.txtRepeatValue, X12SegmentInstanceDpo._RepeatValue);
            bind.Bind(this.chkRequired, X12SegmentInstanceDpo._Required);
            bind.Bind(this.txtSequence, X12SegmentInstanceDpo._Sequence);
            
            bind.Bind(this.txtTR3Notes, X12SegmentInstanceDpo._TR3_Notes);
            bind.Bind(this.txtTR3Example, X12SegmentInstanceDpo._TR3_Example);

            bind.Bind(this.txtRule, X12SegmentInstanceDpo._Situational_Rule);
            bind.Bind(this.txtScript, X12SegmentInstanceDpo._Script);

        }


        public X12SegmentInstanceDpo Dpo
        {
            get
            {
                return bind.Dpo;
            }
            set
            {
                bind.Dpo = value;
                bind.Reset();
            }
        }


        public void Clear()
        {
            bind.Clear();
        }

        public void Save()
        {
            x12Segment1Control1.Save();
            bind.ConfirmAndSave(string.Format("5010A Loop={0} Segment={1}", bind.Dpo.LoopName, bind.Dpo.Name));
        }

        private void txtSegmentName_TextChanged(object sender, EventArgs e)
        {
            x12Segment1Control1.Dpo = new X12SegmentTemplateDpo((sender as TextBox).Text);
        }

    }
}
