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
        [Association(PersonDpo._Person_ID, PersonRelationshipDpo._Person_ID1)]
        public DPCollection<PersonRelationshipDpo> Relationships = new DPCollection<PersonRelationshipDpo>();

        public PersonDpo()
        {
            this.Person_ID = -1;
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

        public GenderEnum Gender
        {
            get { return (GenderEnum)this.Gender_Enum; }
            set { this.Gender_Enum = (int)value; }
        }

        public MaritalStatusEnum MaritalStatus
        {
            get { return (MaritalStatusEnum)this.MaritalStatus_Enum; }
            set { this.MaritalStatus_Enum = (int)value; }
        }
            


        public override string ToString()
        {
            return string.Format("{0} {1}", this.First_Name, this.Last_Name);
        }


        public override DataRow Load()
        {
            DataRow row = base.Load();

            if (this.Exists)
            {
                if (Relationships.Count > 0)
                {
                    int[] ID2List = this.Relationships.Table.ToArray<int>(PersonRelationshipDpo._Person_ID2);
                    
                    var reader2 = new TableReader<PersonDpo>(PersonDpo._Person_ID.ColumName().IN(ID2List));
                    this.cached__relatives = new DPCollection<PersonDpo>(reader2.Table);
                }
            }

            return row;
        }


        /// <summary>
        /// don't use this, use property Relatives instead
        /// </summary>
        private DPCollection<PersonDpo> cached__relatives;

        public DPCollection<PersonDpo> Relatives
        {
            get
            {
                return cached__relatives;
            }
        }


        public void Add(PersonDpo relative, RelationshipEnum relationship)
        {
            Relatives.Add(relative);

            if (relative.Person_ID == -1 
                || this.Relationships.Where(dpo => dpo.Person_ID1 == this.Person_ID && dpo.Person_ID2 == relative.Person_ID).Count() == 0
                )
            {
                PersonRelationshipDpo dpo = new PersonRelationshipDpo(this.Person_ID, relative.Person_ID);
                dpo.RelationShipEnum = relationship;
                this.Relationships.Add(dpo);
            }
        }

    }
}
