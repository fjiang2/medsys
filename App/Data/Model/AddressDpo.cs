using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace App.Data
{
    public class AddressDpo : DpoClass.appAddressDpo
    {
          
        public AddressDpo()
        {
            this.Country_Code = "US";
        }

        
        public AddressDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public AddressDpo(int address_id)
            : base(address_id)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}\r\n{3},{4} {5}", this.Street_Number, this.Street_Name,this.Apartment, 
                this.City, this.State, this.Postal_Code);
        }
    }
}
