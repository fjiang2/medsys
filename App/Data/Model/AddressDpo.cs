﻿using System;
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
    }
}
