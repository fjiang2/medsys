using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.DataManager
{
    public class AddressDpo : Dpo.appAddressDpo
    {
          
        public AddressDpo()
        {
            this.Country_Code = "US";
        }

        
        public AddressDpo(DataRow dataRow)
            :base(dataRow)
        {
        }
    }
}
