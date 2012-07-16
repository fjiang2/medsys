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
using DevExpress.XtraEditors;

namespace X12.Forms
{
    public partial class SpecElement1Control : UserControl
    {
        BindDpo<X12ElementTemplateDpo> bind;
        
        public SpecElement1Control()
        {
            InitializeComponent();

        
            bind = new BindDpo<X12ElementTemplateDpo>();

            bind.Bind(this.txtSegmentName, X12ElementTemplateDpo._SegmentName);
            bind.Bind(this.txtDescription, X12ElementTemplateDpo._Description);

            bind.Bind(this.txtRefDes, X12ElementTemplateDpo._RefDes);
            bind.Bind(this.txtDeNum, X12ElementTemplateDpo._DeNum);
            bind.Bind(this.txtRepeatValue, X12ElementTemplateDpo._RepeatValue);
            bind.Bind(this.txtMinLength, X12ElementTemplateDpo._MinLength);
            bind.Bind(this.txtMaxLength, X12ElementTemplateDpo._MaxLength);

            this.rgCondition.LoadEnum<ConditionDesignator>();
            //bind.Bind<string, ConditionDesignator>(this.rgCondition, 
            //        "SelectedIndex",
            //        columnValue => ElementTemplateDpo.FromCondition(columnValue),
            //        controlValue => ElementTemplateDpo.ToCondition(controlValue),
            //        X12ElementTemplateDpo._Condition);

            bind.Bind<RadioGroup, string>(this.rgCondition,
                    (control, value) => control.SelectedIndex = (int)ElementTemplateDpo.FromCondition(value),
                    (control) => ElementTemplateDpo.ToCondition((ConditionDesignator)control.SelectedIndex),
                    X12ElementTemplateDpo._Condition);



            this.rgElementType.LoadEnum<DataELemenType>();
            //bind.Bind<string, DataELemenType>(this.rgElementType,
            //        "SelectedIndex",
            //        columnValue => ElementTemplateDpo.FromDataType(columnValue),
            //        controlValue => ElementTemplateDpo.ToDataType(controlValue),
            //    X12ElementTemplateDpo._DataType);

            bind.Bind<RadioGroup, string>(this.rgElementType,
                    (control, value) => control.SelectedIndex = (int)ElementTemplateDpo.FromDataType(value),
                    (control) => ElementTemplateDpo.ToDataType((DataELemenType)control.SelectedIndex),
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
