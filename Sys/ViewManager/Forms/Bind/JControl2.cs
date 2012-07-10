using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JControl<TValue, TControl> : JWinControl
    {
        PropertyInfo propertyInfo;

        private Func<TValue, TControl> fill = null;
        private Func<TControl, TValue> collect = null;

        public JControl(Control control, string property, Func<TValue, TControl> fill, Func<TControl, TValue> collect, DataField field)
            : base(control, field)
        {
            Type type = control.GetType();

            propertyInfo = type.GetProperty(property);
            if (property == null)
                throw new Sys.SysException("wrong property name {0} in {1}", property, type.FullName);

            this.fill = fill;
            this.collect = collect;
        }



       

        public override void Fill()
        {
            base.Fill();

            if(value == System.DBNull.Value || value == null)
                value = null;

            if (propertyInfo.CanWrite && fill != null)
            {
                propertyInfo.SetValue(Control, fill((TValue)value), null);
            }

            return;
        }

        public override void Collect()
        {
            if (propertyInfo.CanRead && collect != null)
                value = collect((TControl)propertyInfo.GetValue(Control, null));

            if (value == null)
                value = System.DBNull.Value;

            base.Collect();
            return;
        }
    }
}
