using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using App.Data;
using PTA.Dpo;

namespace PTA
{
    class AdultDpo : ptaAdultDpo
    {
        PersonDpo person;
        AddressDpo address;
        PhoneDpo phone;

        public AdultDpo()
        {
            this.person = new PersonDpo();
            this.address = new AddressDpo();
            this.phone = new PhoneDpo();

        }

        public AdultDpo(DataRow dataRow)
            :base(dataRow)
        {
            this.person = new PersonDpo(dataRow);
            this.address = new AddressDpo(dataRow);
            this.phone = new PhoneDpo(dataRow);
        }

        public AdultDpo(int adult_id)
            :base(adult_id)
        {
            this.person = new PersonDpo(adult_id);
            this.address = new AddressDpo(this.Address_ID);
            
             this.phone = new PhoneDpo(this.Home_Phone_ID);
        }


        public StudentDpo Student
        {
            get
            { 
                TableReader<PersonRelationshipDpo> reader = new TableReader<PersonRelationshipDpo>(
                    new ColumnValue(PersonRelationshipDpo._Person_ID1, this.Adult_ID), 
                    new ColumnValue(PersonRelationshipDpo._Relationship_Enum, RelationshipEnum.Daughter)
                    );
                //PersonRelationshipDpo relation = new PersonRelationshipDpo(this.Adult_ID, Re
                return null;
            }
        }

        public PersonDpo Person
        {
            get { return this.person; }
        }

        public AddressDpo Address
        {
            get { return this.address; }
        }

        public PhoneDpo Phone
        {
            get { return this.phone; }
        }

        public override DataRow Save()
        {
            DataRow row = base.Save();
            
            this.person.Person_ID = this.Adult_ID;
            this.phone.Phone_ID = this.Home_Phone_ID;
            this.address.Address_ID = this.Address_ID;

            this.person.Save();
            this.address.Save();
            this.phone.Save();

            return row;
        }


    }
}
