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
    [ConstraintForeignKey(StudentDpo._Student_ID, typeof(PersonDpo), PersonDpo._Person_ID)]
    [ConstraintForeignKey(StudentDpo._Address_ID, typeof(AddressDpo), AddressDpo._Address_ID)]
    [ConstraintForeignKey(StudentDpo._Phone_ID, typeof(PhoneDpo), PhoneDpo._Phone_ID)]
    public class StudentDpo : ptaStudentDpo
    {
        [Map(_Student_ID,  PersonDpo._Person_ID)]
        [Association(StudentDpo._Student_ID, PersonDpo._Person_ID)]
        public PersonDpo Person = new PersonDpo();

        [Map(_Address_ID,  AddressDpo._Address_ID)]
        [Association(StudentDpo._Address_ID, AddressDpo._Address_ID)]
        public AddressDpo Address = new AddressDpo();

        [Map(_Phone_ID, PhoneDpo._Phone_ID)]
        [Association(StudentDpo._Phone_ID, PhoneDpo._Phone_ID)]
        public PhoneDpo Phone = new PhoneDpo();

        
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
