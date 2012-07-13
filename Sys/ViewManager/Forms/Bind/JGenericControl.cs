using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JGenericControl<TControl, TColumn> : JWinControl where TControl : System.Windows.Forms.Control
    {
        private Action<TControl, TColumn> fill = null;
        private Func<TControl, TColumn> collect = null;

        public JGenericControl(Control control, Action<TControl, TColumn> fill, Func<TControl, TColumn> collect, DataField field)
            : base(control, field)
        {
            Type type = control.GetType();

            this.fill = fill;
            this.collect = collect;
        }



       

        public override void Fill()
        {
            if(this.value == System.DBNull.Value || value == null)
                this.value = null;

            if (fill != null)
                 fill((TControl)this.Control, (TColumn)this.value);

            return;
        }

        public override void Collect()
        {
            if (collect != null)
                this.value = collect((TControl)Control);

            if (this.value == null)
                this.value = System.DBNull.Value;

            return;
        }
    }
}
