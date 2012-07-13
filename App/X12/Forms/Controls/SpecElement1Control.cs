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
using X12.Specification;


namespace X12.Forms
{
    public partial class SpecElement1Control : UserControl
    {
        BindDpo<X12ElementTemplateDpo> bind;
        
        public SpecElement1Control()
        {
            InitializeComponent();

        
            bind = new BindDpo<X12ElementTemplateDpo>();

            bind.Connect(this.txtSegmentName, X12ElementTemplateDpo._SegmentName);
            bind.Connect(this.txtDescription, X12ElementTemplateDpo._Description);

            bind.Connect(this.txtRefDes, X12ElementTemplateDpo._RefDes);
            bind.Connect(this.txtDeNum, X12ElementTemplateDpo._DeNum);
            bind.Connect(this.txtRepeatValue, X12ElementTemplateDpo._RepeatValue);
            bind.Connect(this.txtMinLength, X12ElementTemplateDpo._MinLength);
            bind.Connect(this.txtMaxLength, X12ElementTemplateDpo._MaxLength);

            this.rgCondition.LoadEnum<ConditionDesignator>();
            bind.Connect<string, ConditionDesignator>(this.rgCondition, 
                    "SelectedIndex",
                    columnValue => ElementTemplateDpo.FromCondition(columnValue),
                    controlValue => ElementTemplateDpo.ToCondition(controlValue),
                    X12ElementTemplateDpo._Condition);

            this.rgElementType.LoadEnum<DataELemenType>();
            bind.Connect<string, DataELemenType>(this.rgElementType,
                    "SelectedIndex",
                    columnValue => ElementTemplateDpo.FromDataType(columnValue),
                    controlValue => ElementTemplateDpo.ToDataType(controlValue),
                X12ElementTemplateDpo._DataType);

        }

        private void X12Element1Control_Load(object sender, EventArgs e)
        {

        }



        public X12ElementTemplateDpo Dpo
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
            bind.ConfirmAndSave(string.Format("Data Element={0}",  bind.Dpo.RefDes));
        }

     
    }
}
