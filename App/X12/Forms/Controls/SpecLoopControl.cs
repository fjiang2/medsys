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
using X12.Dpo;

namespace X12.Forms
{
    public partial class SpecLoopControl : BaseUserControl
    {
        BindDpo<X12LoopTemplateDpo> bind;
        


        public SpecLoopControl()
        {
            InitializeComponent();

        
            bind = new BindDpo<X12LoopTemplateDpo>();

            bind.Connect(this.txtLoop, X12LoopTemplateDpo._Name);
            bind.Connect(this.txtSequence, X12LoopTemplateDpo._Sequence);
            bind.Connect(this.txtDescription, X12LoopTemplateDpo._Description);
            bind.Connect(this.chkRequired, X12LoopTemplateDpo._Required);

            bind.Connect(this.txtRepeatMin, X12LoopTemplateDpo._MinRepeat);
            bind.Connect(this.txtRepeatMax, X12LoopTemplateDpo._MaxRepeat);

            
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
