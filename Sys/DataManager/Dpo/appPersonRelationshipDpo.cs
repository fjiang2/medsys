//
// Machine Generated Code
//   by devel at 7/12/2012 1:16:00 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.DataManager.Dpo
{
    [Revision(0)]
    [Table("app00103", Level.System, Pack = false)]    //Primary Keys = Person_ID1 + Person_ID2;  Identity = ;
    public class appPersonRelationshipDpo : DPObject
    {

#pragma warning disable

        [Column(_Person_ID1, SqlDbType.Int, Primary = true)]                                      public int Person_ID1;        //int(4) not null
        [Column(_Person_ID2, SqlDbType.Int, Primary = true)]                                      public int Person_ID2;        //int(4) not null
        [Column(_RelationshipEnum, SqlDbType.Int)]                                                public int RelationshipEnum;  //int(4) not null

#pragma warning restore

        public appPersonRelationshipDpo()
        {
        }

        public appPersonRelationshipDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appPersonRelationshipDpo(int person_id1, int person_id2)
        {
           this.Person_ID1 = person_id1; this.Person_ID2 = person_id2; 

           this.Load();
           if(!this.Exists)
           {
              this.Person_ID1 = person_id1; this.Person_ID2 = person_id2;     
           }
        }
        


        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Person_ID1, _Person_ID2 });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        

        public static string TABLE_NAME
        { 
            get
            {
              return new appPersonRelationshipDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Person_ID1 = "Person_ID1";
        public const string _Person_ID2 = "Person_ID2";
        public const string _RelationshipEnum = "RelationshipEnum";

       
        #endregion 



    }
}

