﻿using System;
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
        [ForeignKey(StudentDpo._Student_ID,  typeof(PersonDpo), PersonDpo._Person_ID)]
        [Association("Person_ID=@Student_ID")]
        public PersonDpo Person = new PersonDpo();

        [ForeignKey(StudentDpo._Address_ID, typeof(AddressDpo), AddressDpo._Address_ID)]
        [Association("Address_ID=@Address_ID")]
        public AddressDpo Address = new AddressDpo();

        [ForeignKey(StudentDpo._Phone_ID, typeof(PhoneDpo), PhoneDpo._Phone_ID)]
        [Association("Phone_ID=@Phone_ID")]
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
