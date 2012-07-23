using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data.DataEnum;

namespace App.Data
{
    public class PersonDpo : DpoClass.appPersonDpo
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

        public GenderEnum GenderEnum
        {
            get { return (GenderEnum)this.Gender_Enum; }
            set { this.Gender_Enum = (int)value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.First_Name, this.Last_Name);
        }
    }
}
