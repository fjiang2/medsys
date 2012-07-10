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
    public partial class SpecSegment1Control : BaseUserControl
    {
        BindDpo<X12SegmentTemplateDpo> bind;

        public SpecSegment1Control()
        {
            InitializeComponent();

            bind = new BindDpo<X12SegmentTemplateDpo>();

            bind.Connect(this.txtSegmentName, X12SegmentTemplateDpo._Name);
            bind.Connect(this.txtDescription, X12SegmentTemplateDpo._Description);
            
            bind.Connect(this.txtPurpose, X12SegmentTemplateDpo._Purpose);
            bind.Connect(this.txtNotes, X12SegmentTemplateDpo._Notes);
            bind.Connect(this.txtSyntax, X12SegmentTemplateDpo._Syntax);
            

        }


        public X12SegmentTemplateDpo Dpo
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
            bind.ConfirmAndSave(string.Format("Segment={0}",  bind.Dpo.Name));
        }

    }
}
