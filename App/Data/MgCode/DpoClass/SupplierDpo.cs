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
    [Table("Northwind..[Suppliers]", Level.Fixed)]    //Primary Keys = SupplierID;  Identity = SupplierID;
    public class SupplierDpo : DPObject
    {

#pragma warning disable

        [Column(_SupplierID, CType.Int, Identity = true, Primary = true)]                     public int SupplierID {get; set;} //int(4) not null
        [Column(_CompanyName, CType.NVarChar, Length = 40)]                                   public string CompanyName {get; set;} //nvarchar(40) not null
        [Column(_ContactName, CType.NVarChar, Nullable = true, Length = 30)]                  public string ContactName {get; set;} //nvarchar(30) null
        [Column(_ContactTitle, CType.NVarChar, Nullable = true, Length = 30)]                 public string ContactTitle {get; set;} //nvarchar(30) null
        [Column(_Address, CType.NVarChar, Nullable = true, Length = 60)]                      public string Address {get; set;} //nvarchar(60) null
        [Column(_City, CType.NVarChar, Nullable = true, Length = 15)]                         public string City {get; set;} //nvarchar(15) null
        [Column(_Region, CType.NVarChar, Nullable = true, Length = 15)]                       public string Region {get; set;} //nvarchar(15) null
        [Column(_PostalCode, CType.NVarChar, Nullable = true, Length = 10)]                   public string PostalCode {get; set;} //nvarchar(10) null
        [Column(_Country, CType.NVarChar, Nullable = true, Length = 15)]                      public string Country {get; set;} //nvarchar(15) null
        [Column(_Phone, CType.NVarChar, Nullable = true, Length = 24)]                        public string Phone {get; set;} //nvarchar(24) null
        [Column(_Fax, CType.NVarChar, Nullable = true, Length = 24)]                          public string Fax {get; set;} //nvarchar(24) null
        [Column(_HomePage, CType.NText, Nullable = true)]                                     public string HomePage {get; set;} //ntext(16) null

#pragma warning restore

        public SupplierDpo()
        {
        }

        public SupplierDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public SupplierDpo(int supplierid)
        {
           this.SupplierID = supplierid; 

           this.Load();
           if(!this.Exists)
           {
              this.SupplierID = supplierid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.SupplierID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _SupplierID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _SupplierID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new SupplierDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _SupplierID = "SupplierID";
        public const string _CompanyName = "CompanyName";
        public const string _ContactName = "ContactName";
        public const string _ContactTitle = "ContactTitle";
        public const string _Address = "Address";
        public const string _City = "City";
        public const string _Region = "Region";
        public const string _PostalCode = "PostalCode";
        public const string _Country = "Country";
        public const string _Phone = "Phone";
        public const string _Fax = "Fax";
        public const string _HomePage = "HomePage";

       
        #endregion 



    }
}

