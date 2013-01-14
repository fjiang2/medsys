using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JHostObject : JWinControl
    {
        object obj;

        public JHostObject(object obj, DataField field)
            : base(null, field)
        {
            this.obj = obj;
        }

        public override void Fill()
        {
            //base.Fill();
            VAL val = Script.Evaluate(value.ToString());
            HostType.SetObjectProperties(obj, val);
            return;
        }

        public override void Collect()
        {
            VAL val = HostType.GetObjectProperties(obj);
            value = val.ToJson();
            //base.Collect();
            return;
        }
    }
}
