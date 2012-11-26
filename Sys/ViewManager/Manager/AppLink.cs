using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.ViewManager.DpoClass;
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
            DataTable dt = new TableReader<AppLinkDpo>().Table;
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
