using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.ViewManager.Dpo;
using Sys.Data;
using Sys.Data.Manager;
using DevExpress.XtraNavBar;
using System.Drawing;
using Sys.Security;

namespace Sys.ViewManager.Manager
{
    public class AppLink
    {
        DPCollection<AppLinkDpo> links;

        public AppLink(Account account)
        {
            DataTable dt = SqlCmd.FillDataTable("SELECT * FROM {0}", AppLinkDpo.TABLE_NAME);
            links = new DPCollection<AppLinkDpo>(dt);

     
        }

        public DPCollection<AppLinkDpo> Links
        {
            get
            {
                return this.links;
            }
        }
    }
}
