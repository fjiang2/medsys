using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JDomainUpDown: JWinControl
    {
        public JDomainUpDown(DomainUpDown domainUpDown, DataField field)
            : base(domainUpDown, field)
        {
        }

        public override void Fill()
        {
            base.Fill();

            (Control as DomainUpDown).SelectedItem = value;
            return;
        }

        public override void Collect()
        {
            value = (Control as DomainUpDown).SelectedItem;
            base.Collect();
            return;
        }

    }
}
