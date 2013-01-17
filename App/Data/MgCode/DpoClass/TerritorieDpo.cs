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
using Sys.Data.Manager;


namespace App.Data.DpoClass
{
    [Revision(8)]
    [Table("Northwind..Territories", Level.Fixed)]    //Primary Keys = TerritoryID;  Identity = ;
    public class TerritorieDpo : DPObject
    {

#pragma warning disable

        [Column(_TerritoryID, SqlDbType.NVarChar, Primary = true, Length = 20)]                   public string TerritoryID;    //nvarchar(20) not null
        [Column(_TerritoryDescription, SqlDbType.NChar, Length = 50)]                             public string TerritoryDescription;//nchar(50) not null
        [Column(_RegionID, SqlDbType.Int)]                                                        public int RegionID;          //int(4) not null

#pragma warning restore

        public TerritorieDpo()
        {
        }

        public TerritorieDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public TerritorieDpo(string territoryid)
        {
           this.TerritoryID = territoryid; 

           this.Load();
           if(!this.Exists)
           {
              this.TerritoryID = territoryid;     
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
                return new PrimaryKeys(new string[]{ _TerritoryID });
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
              return new TerritorieDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _TerritoryID = "TerritoryID";
        public const string _TerritoryDescription = "TerritoryDescription";
        public const string _RegionID = "RegionID";

       
        #endregion 



    }
}

