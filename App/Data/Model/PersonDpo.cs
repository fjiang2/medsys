using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using App.Data.DataEnum;

namespace App.Data
{
    public class PersonDpo : DpoClass.appPersonDpo
    {
        public PersonDpo()
        {
            this.Inactive = false;
        }

        public PersonDpo(DataRow dataRow)
            : base(dataRow)
        { 
        }
        
        public PersonDpo(int person_id)
            : base(person_id)
        { 
        
        }

        public GenderEnum GenderEnum
        {
            get { return (GenderEnum)this.Gender_Enum; }
            set { this.Gender_Enum = (int)value; }
        }



        public override string ToString()
        {
            return string.Format("{0} {1}", this.First_Name, this.Last_Name);
        }


        /// <summary>
        /// don't use this, use property Relatives instead
        /// </summary>
        private DPCollection<PersonDpo> cached__relatives;
        private DPCollection<PersonRelationshipDpo> cached__relationships;

        public DPCollection<PersonDpo> Relatives
        {
            get
            {
                if (cached__relatives == null)
                {
                    //Get all relatives' id
                    var reader1 = new TableReader<PersonRelationshipDpo>(new ColumnValue(PersonRelationshipDpo._Person_ID1, this.Person_ID));
                    cached__relationships = new DPCollection<PersonRelationshipDpo>(reader1.Table);
                    int[] ID2List = reader1.Table.ToArray<int>(PersonRelationshipDpo._Person_ID2);
                    if (ID2List.Length == 0)
                        return null;


                    var reader2 = new TableReader<PersonDpo>(new ColumnValue(PersonDpo._Person_ID, ID2List));
                    this.cached__relatives = new DPCollection<PersonDpo>(reader2.Table);
                }

                return cached__relatives;
            }
        }


        public void AddRelativeAndSave(PersonDpo relative, RelationshipEnum relationship)
        {
            
            Relatives.Add(relative);
            relative.Save(); //return Person_ID
            
            PersonRelationshipDpo dpo = new PersonRelationshipDpo(this.Person_ID, relative.Person_ID);
            dpo.RelationShipEnum = relationship;
            cached__relationships.Add(dpo);
        }

    }
}
