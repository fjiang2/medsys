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
    [Table("Northwind..[Shippers]", Level.Fixed)]    //Primary Keys = ShipperID;  Identity = ShipperID;
    public class ShipperDpo : DPObject
    {

#pragma warning disable

        [Column(_ShipperID, CType.Int, Identity = true, Primary = true)]                      public int ShipperID {get; set;} //int(4) not null
        [Column(_CompanyName, CType.NVarChar, Length = 40)]                                   public string CompanyName {get; set;} //nvarchar(40) not null
        [Column(_Phone, CType.NVarChar, Nullable = true, Length = 24)]                        public string Phone {get; set;} //nvarchar(24) null

#pragma warning restore

        public ShipperDpo()
        {
        }

        public ShipperDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ShipperDpo(int shipperid)
        {
           this.ShipperID = shipperid; 

           this.Load();
           if(!this.Exists)
           {
              this.ShipperID = shipperid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ShipperID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ShipperID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _ShipperID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new ShipperDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ShipperID = "ShipperID";
        public const string _CompanyName = "CompanyName";
        public const string _Phone = "Phone";

       
        #endregion 



    }
}

