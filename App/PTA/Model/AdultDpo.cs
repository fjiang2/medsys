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

        [Association("Person_ID=@Adult_ID")]
        public PersonDpo Person;

        [ForeignKey(AdultDpo._Address_ID, AddressDpo._Address_ID)]
        [Association("Address_ID=@Address_ID")]
        public AddressDpo Address;

        [Association("Phone_ID=@Hone_Phone_ID")]
        public PhoneDpo Phone;

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


        public void Add(StudentDpo student)
        {
            this.Person.Add(student.Person, RelationshipEnum.Student);
        }

        public IEnumerable<PersonDpo> Students
        {
            get { return Person.Relatives; }
        }


        public override DataRow Save()
        {
            DataRow row = base.Save();
            this.SaveAssociations();
            return row;
        }


    }
}
