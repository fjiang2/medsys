using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;
using Sys.Data;

namespace Stock
{
    public class DailyFetch
    {
  
        public DailyFetch()
        {
            Company company = new Company("AIR", false);
            company.Download();
        }

      

    }
}
