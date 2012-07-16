using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace App.Data
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
        
        public PersonDpo(int person_id)
            : base(person_id)
        { 
        
        }

    }
}
