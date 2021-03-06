﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data.DataEnum;

namespace App.Data
{
    public class PersonRelationshipDpo : DpoClass.appPersonRelationshipDpo
    {
          
        public PersonRelationshipDpo()
        {
        }

        
        public PersonRelationshipDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public PersonRelationshipDpo(int person_id1, int person_id2)
            : base(person_id1, person_id2)
        {
        }

        public RelationshipEnum RelationShipEnum
        {
            get { return (RelationshipEnum)this.Relationship_Enum; }
            set { this.Relationship_Enum = (int)value; }
        }

        public override string ToString()
        {
            return string.Format("{0} --{1}--> {2}", this.Person_ID1, this.RelationShipEnum, this.Person_ID2);
        }
    }
}
