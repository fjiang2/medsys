using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JVal : JWinControl
    {
        VAL val;

        public JVal(VAL val, DataField field)
            : base(null, field)
        {
            this.val = val;
        }

        public override void Fill()
        {
            //base.Fill();

            val = Script.Evaluate(value.ToString());
            return;
        }

        public override void Collect()
        {
            value = val.ToJson();

            //base.Collect();
            return;
        }
    }
}
