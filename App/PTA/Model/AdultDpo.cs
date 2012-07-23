using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using App.Data;
using App.Data.DataEnum;
using PTA.DpoClass;

namespace PTA
{
    public class AdultDpo : ptaAdultDpo
    {
        PersonDpo person = new PersonDpo();
        AddressDpo address = new AddressDpo();
        PhoneDpo phone = new PhoneDpo();

        List<StudentDpo> students = new List<StudentDpo>();

        public AdultDpo()
        {
        }

        public AdultDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public AdultDpo(int adult_id)
            :base(adult_id)
        {
        }

        public override DataRow Load()
        {
            DataRow row = base.Load();

            if (this.Exists)
            {
                this.person = new PersonDpo(this.Adult_ID);
                this.address = new AddressDpo(this.Address_ID);
                this.phone = new PhoneDpo(this.Home_Phone_ID);


                TableReader<PersonRelationshipDpo> reader = new TableReader<PersonRelationshipDpo>(
                     new ColumnValue(PersonRelationshipDpo._Person_ID2, this.Adult_ID)
                     );

                var relations = reader.ToDPList<PersonRelationshipDpo>();

                foreach (var relation in relations)
                {
                    var student = new StudentDpo(relation.Person_ID1);
                    students.Add(student);

                }
            }

            return row;
        }

        public IEnumerable<StudentDpo> Students
        {
            get   { return students;  }
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
            if (this.Exists)
            {
                this.person.Person_ID = this.Adult_ID;
                this.person.Save();

                this.phone.Phone_ID = this.Home_Phone_ID;
                this.phone.Save();

                this.address.Address_ID = this.Address_ID;
                this.address.Save();
            }
            else
            {
                this.person.Save();
                this.Adult_ID = person.Person_ID;

                if (this.phone != null)
                {
                    this.phone.Save();
                    this.Home_Phone_ID = this.phone.Phone_ID;
                }

                if (this.address != null)
                {
                    this.address.Save();
                    this.Address_ID = this.address.Address_ID;
                }
            }

            foreach (StudentDpo student in students)
            {
                PersonRelationshipDpo dpo = new PersonRelationshipDpo(this.Adult_ID, student.Student_ID);
                if(student.Person.GenderEnum ==  GenderEnum.Male)
                    dpo.RelationShipEnum = RelationshipEnum.Son;
                else
                    dpo.RelationShipEnum = RelationshipEnum.Daughter;
                
                dpo.Save();
            }

            return base.Save();
        }


    }
}
