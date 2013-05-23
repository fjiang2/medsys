using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JControl : JWinControl
    {
        PropertyInfo propertyInfo;

        public JControl(Control control, string property, DataField field)
            : base(control, field)
        {
            Type type = control.GetType();

            propertyInfo = type.GetProperty(property);
            if (property == null)
                throw new Sys.JException("wrong property name {0} in {1}", property, type.FullName);
        }

        public override void Fill()
        {
            base.Fill();

            if(value == System.DBNull.Value)
                value = null;

            if (propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(Control, value, null);
            }

            return;
        }

        public override void Collect()
        {
            if (propertyInfo.CanRead)
                value = propertyInfo.GetValue(Control, null);

            if (value == null)
                value = System.DBNull.Value;

            base.Collect();
            return;
        }
    }
}
