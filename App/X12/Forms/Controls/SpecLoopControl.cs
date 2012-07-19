using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.ViewManager.Forms;
using X12.DpoClass;

namespace X12.Forms
{
    public partial class SpecLoopControl : BaseUserControl
    {
        BindDpo<X12LoopTemplateDpo> bind;
        


        public SpecLoopControl()
        {
            InitializeComponent();

        
            bind = new BindDpo<X12LoopTemplateDpo>();

            bind.Bind(this.txtLoop, X12LoopTemplateDpo._Name);
            bind.Bind(this.txtSequence, X12LoopTemplateDpo._Sequence);
            bind.Bind(this.txtDescription, X12LoopTemplateDpo._Description);
            bind.Bind(this.chkRequired, X12LoopTemplateDpo._Required);

            bind.Bind(this.txtRepeatMin, X12LoopTemplateDpo._MinRepeat);
            bind.Bind(this.txtRepeatMax, X12LoopTemplateDpo._MaxRepeat);

            
        }


        public X12LoopTemplateDpo Dpo
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
            bind.Dpo = new X12LoopTemplateDpo();
            bind.Reset();
        }

        public void Save()
        {
            bind.ConfirmAndSave(string.Format("5010A Loop={0}", bind.Dpo.Name));
        }
    }
}
