using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data;
using App.Data.DataEnum;
using PTA.DpoClass;
using Sys.Data;

namespace PTA
{
    public class StudentDpo : ptaStudentDpo
    {
        [Association("Person_ID=@Adult_ID")]
        public PersonDpo Person;

        [Association("Address_ID=@Address_ID")]
        public AddressDpo Address;

        [Association("Phone_ID=@Hone_Phone_ID")]
        public PhoneDpo Phone;

        
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



        public IEnumerable<PersonDpo> Adults
        {
            get {  return this.Person.Relatives; }
        }

        public void Add(AdultDpo adult)
        {
            this.Person.Add(adult.Person, RelationshipEnum.Guardian);
        }

        public override DataRow Save()
        {
            DataRow row = base.Save();
            this.SaveAssociations();
            return row;
        }

    }
}
