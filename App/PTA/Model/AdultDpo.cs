using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data;
using PTA.Dpo;

namespace PTA
{
    class AdultDpo : PersonDpo
    {
        ptaAdultDpo adult;
        AddressDpo address;
        PhoneDpo phone;

        public AdultDpo()
        {
            this.adult = new ptaAdultDpo();
            this.address = new AddressDpo();
            this.phone = new PhoneDpo();

        }

        public AdultDpo(DataRow dataRow)
            :base(dataRow)
        {
            this.adult = new ptaAdultDpo(dataRow);
            this.address = new AddressDpo(dataRow);
            this.phone = new PhoneDpo(dataRow);
        }

        public AddressDpo Address
        {
            get { return this.address; }
        }

        public PhoneDpo Phone
        {
            get { return this.phone; }
        }


    }
}
