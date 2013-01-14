using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using X12.DpoClass;

namespace X12.Forms
{
    public partial class SpecSegment1Control : BaseUserControl
    {
        BindDpo<X12SegmentTemplateDpo> bind;

        public SpecSegment1Control()
        {
            InitializeComponent();

            bind = new BindDpo<X12SegmentTemplateDpo>();

            bind.Bind(this.txtSegmentName, X12SegmentTemplateDpo._Name);
            bind.Bind(this.txtDescription, X12SegmentTemplateDpo._Description);
            
            bind.Bind(this.txtPurpose, X12SegmentTemplateDpo._Purpose);
            bind.Bind(this.txtNotes, X12SegmentTemplateDpo._Notes);
            bind.Bind(this.txtSyntax, X12SegmentTemplateDpo._Syntax);
            

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
