using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace App.Data
{
    public class PhoneDpo : DpoClass.appPhoneDpo
    {
        public PhoneDpo()
        {
        }

        public PhoneDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public PhoneDpo(int phone_id)
           :base(phone_id)
        {
         
        }

        public override string ToString()
        {
            return string.Format("Phone:{0}, Mobile:{1}", this.Phone, this.Mobile);
        }
    }
}
