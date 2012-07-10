//
// Machine Generated Code
//   by devel at 4/18/2012 3:50:04 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace App.Data.Dpo
{
    [Revision(8)]
    [Table("Region", Level.Default)]    //Primary Keys = RegionID;  Identity = ;
    public class RegionDpo : DPObject
    {

#pragma warning disable

        [Column(_RegionID, SqlDbType.Int, Primary = true)]                                        public int RegionID;          //int(4) not null
        [Column(_RegionDescription, SqlDbType.NChar, Length = 50)]                                public string RegionDescription;//nchar(50) not null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _RegionID });
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
              return new RegionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _RegionID = "RegionID";
        public const string _RegionDescription = "RegionDescription";

       
        #endregion 



    }
}

