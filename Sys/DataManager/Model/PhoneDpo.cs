using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.DataManager
{
    public class PhoneDpo : Dpo.appPhoneDpo
    {
       public PhoneDpo()
        {
            this.PhoneEnum = PhoneEnum.Home;
        }

       public PhoneDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

       public PhoneEnum PhoneEnum
       {
           get { return (PhoneEnum)this.Phone_Enum; }
           set { this.Phone_Enum = (int)value; }
       }
    }
}
