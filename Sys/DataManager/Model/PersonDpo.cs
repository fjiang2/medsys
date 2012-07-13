using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.DataManager
{
    public class PersonDpo : Dpo.appPersonDpo
    {
        public PersonDpo()
        {
            this.Inactive = false;
        }

        public PersonDpo(DataRow dataRow)
            : base(dataRow)
        { 
        }


    }
}
