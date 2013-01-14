using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JMemoExEdit : JWinControl
    {
        public JMemoExEdit(DevExpress.XtraEditors.MemoExEdit edit, DataField field)
            : base(edit, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            (Control as MemoExEdit).Text = value.ToString().Trim(); 

            return;
        }

        public override void Collect()
        {
            value = (Control as MemoExEdit).Text;
            
            base.Collect();
            return;
        }
    }
}
