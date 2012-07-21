using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JControl<TColumnValue, TControlValue> : JWinControl
    {
        PropertyInfo propertyInfo;

        private Func<TColumnValue, TControlValue> fill = null;
        private Func<TControlValue, TColumnValue> collect = null;

        public JControl(Control control, string property, Func<TColumnValue, TControlValue> fill, Func<TControlValue, TColumnValue> collect, DataField field)
            : base(control, field)
        {
            Type type = control.GetType();

            propertyInfo = type.GetProperty(property);
            if (property == null)
                throw new Sys.JException("wrong property name {0} in {1}", property, type.FullName);

            this.fill = fill;
            this.collect = collect;
        }



       

        public override void Fill()
        {
            base.Fill();

            if(this.value == System.DBNull.Value || value == null)
                this.value = null;

            if (propertyInfo.CanWrite)
            {
                if(fill != null)
                    propertyInfo.SetValue(Control, fill((TColumnValue)this.value), null);
                else
                    propertyInfo.SetValue(Control, this.value, null);
            }

            return;
        }

        public override void Collect()
        {
            if (propertyInfo.CanRead)
            {
                if (collect != null)
                    this.value = collect((TControlValue)propertyInfo.GetValue(Control, null));
                else
                    this.value = propertyInfo.GetValue(Control, null);
            }

            if (this.value == null)
                this.value = System.DBNull.Value;

            base.Collect();
            return;
        }
    }
}
