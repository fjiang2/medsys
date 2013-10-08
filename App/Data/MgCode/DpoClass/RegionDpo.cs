//
// Machine Generated Code
//   by devel at 5/16/2013
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace App.Data.DpoClass
{
    [Revision(10)]
    [Table("Northwind..[Region]", Level.Fixed)]    //Primary Keys = RegionID;  Identity = ;
    public class RegionDpo : DPObject
    {

#pragma warning disable

        [Column(_RegionID, CType.Int, Primary = true)]                                        public int RegionID {get; set;} //int(4) not null
        [Column(_RegionDescription, CType.NChar, Length = 50)]                                public string RegionDescription {get; set;} //nchar(50) not null

#pragma warning restore

        public RegionDpo()
        {
        }

        public RegionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public RegionDpo(int regionid)
        {
           this.RegionID = regionid; 

           this.Load();
           if(!this.Exists)
           {
              this.RegionID = regionid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.RegionID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _RegionID });
            }
        }



        public override IIdentityKeys Identity
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
              return new RegionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _RegionID = "RegionID";
        public const string _RegionDescription = "RegionDescription";

       
        #endregion 



    }
}

