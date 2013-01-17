using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JGenericControl<TControl, TColumn> : JWinControl
    {
        private TControl control;

        private Action<TControl, TColumn> fill = null;
        private Func<TControl, TColumn> collect = null;

        public JGenericControl(TControl control, Action<TControl, TColumn> fill, Func<TControl, TColumn> collect, DataField field)
            : base(null, field)
        {
            this.control = control;

            this.fill = fill;
            this.collect = collect;
        }

        public override void Fill()
        {
            if(this.value == System.DBNull.Value || value == null)
                this.value = null;

            if (fill != null)
                 fill(this.control, (TColumn)this.value);

            return;
        }

        public override void Collect()
        {
            if (collect != null)
                this.value = collect(this.control);

            if (this.value == null)
                this.value = System.DBNull.Value;

            return;
        }
    }
}
