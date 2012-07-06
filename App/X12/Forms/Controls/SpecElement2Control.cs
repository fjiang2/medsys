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
using Sys.ViewManager.DevEx;
using Sys.Data;
using X12.Specification;

namespace X12.Forms
{
    public partial class SpecElement2Control : UserControl
    {
        BindDpo<ElementInstanceDpo> bind;
        
        public SpecElement2Control()
        {
            InitializeComponent();
            bind = new BindDpo<ElementInstanceDpo>();

            bind.Connect(this.txtDescription, X12ElementInstanceDpo._Description);
            bind.Connect(this.txtSituationalRule, X12ElementInstanceDpo._Situational_Rule);
            
            this.rgUsage.LoadEnum<UsageType>();
            bind.Connect(this.rgUsage, X12ElementInstanceDpo._Usage);

         
        }


        public ElementInstanceDpo Dpo
        {
            get
            {
                return bind.Dpo;
            }
            set
            {
                bind.Dpo = value;
                DataTable table = new TableReader<X12CodeDefinitionDpo>(new ColumnValue(X12CodeDefinitionDpo._ElementInstance_ID, value.ID)).Table;
                gridControl1.DataSource = table;
                bind.Reset();
            }
        }


        public void Clear()
        {
            bind.Clear();
        }

        public void Save()
        {
            bind.ConfirmAndSave(string.Format("Data Element={0}", bind.Dpo.Description));
            var definitions =  new DPList<X12CodeDefinitionDpo>((DataTable)gridControl1.DataSource);
            foreach(var dpo in definitions)
            {
                dpo.ID = -1;
                dpo.ElementInstance_ID = bind.Dpo.ID;
            }

            definitions.Save();

        }
    }
}
