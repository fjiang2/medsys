using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data;
using PTA.Dpo;
using Sys.Data;

namespace PTA
{
    public class StudentDpo : ptaStudentDpo
    {
        PersonDpo person = new PersonDpo();
        AddressDpo address = new AddressDpo();
        PhoneDpo phone = new PhoneDpo();

        List<AdultDpo> adults = new List<AdultDpo>();

        public StudentDpo()
        {
        }

        public StudentDpo(DataRow dataRow)
            :base(dataRow)
        {
            
        }


        public StudentDpo(int student_id)
            : base(student_id)
        { 
        }

        public override DataRow Load()
        {
            DataRow row = base.Load();

            if (this.Exists)
            {
                this.person = new PersonDpo(this.Student_ID);
                
                if(this.Address_ID != null)
                    this.address = new AddressDpo((int)this.Address_ID);

                if(this.Phone_ID != null)
                    this.phone = new PhoneDpo((int)this.Phone_ID);

                TableReader<PersonRelationshipDpo> reader = new TableReader<PersonRelationshipDpo>(
                        new ColumnValue(PersonRelationshipDpo._Person_ID1, this.Student_ID)
                        );

                var relations = reader.ToDPList<PersonRelationshipDpo>();

                foreach (var relation in relations)
                {
                    var adult = new AdultDpo(relation.Person_ID2);
                    adults.Add(adult);

                }
            }

            return row;
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

        public IEnumerable<AdultDpo> Adults
        {
            get   {  return this.adults; }
        }

        public void Add(AdultDpo adult)
        {
            this.adults.Add(adult);
        }

        public override DataRow Save()
        {
            if (!this.Exists)
            {
                this.person.Save();
                this.Student_ID = person.Person_ID;

                if (this.phone != null)
                {
                    this.phone.Save();
                    this.Phone_ID = this.phone.Phone_ID;
                }

                if (this.address != null)
                {
                    this.address.Save();
                    this.Address_ID = this.address.Address_ID;
                }
            }
            else
            {
                this.person.Save();

                if (this.Phone_ID != null)
                {
                    this.phone.Phone_ID = (int)this.Phone_ID;
                    this.phone.Save();
                }

                if (this.Address_ID != null)
                {
                    this.address.Address_ID = (int)this.Address_ID;
                    this.address.Save();
                }
            }

            return base.Save();
        }
    }
}
