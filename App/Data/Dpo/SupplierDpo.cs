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


namespace App.Data.Dpo
{
    [Revision(8)]
    [Table("Northwind..Suppliers", Level.Fixed)]    //Primary Keys = SupplierID;  Identity = SupplierID;
    public class SupplierDpo : DPObject
    {

#pragma warning disable

        [Column(_SupplierID, SqlDbType.Int, Identity = true, Primary = true)]                     public int SupplierID;        //int(4) not null
        [Column(_CompanyName, SqlDbType.NVarChar, Length = 40)]                                   public string CompanyName;    //nvarchar(40) not null
        [Column(_ContactName, SqlDbType.NVarChar, Nullable = true, Length = 30)]                  public string ContactName;    //nvarchar(30) null
        [Column(_ContactTitle, SqlDbType.NVarChar, Nullable = true, Length = 30)]                 public string ContactTitle;   //nvarchar(30) null
        [Column(_Address, SqlDbType.NVarChar, Nullable = true, Length = 60)]                      public string Address;        //nvarchar(60) null
        [Column(_City, SqlDbType.NVarChar, Nullable = true, Length = 15)]                         public string City;           //nvarchar(15) null
        [Column(_Region, SqlDbType.NVarChar, Nullable = true, Length = 15)]                       public string Region;         //nvarchar(15) null
        [Column(_PostalCode, SqlDbType.NVarChar, Nullable = true, Length = 10)]                   public string PostalCode;     //nvarchar(10) null
        [Column(_Country, SqlDbType.NVarChar, Nullable = true, Length = 15)]                      public string Country;        //nvarchar(15) null
        [Column(_Phone, SqlDbType.NVarChar, Nullable = true, Length = 24)]                        public string Phone;          //nvarchar(24) null
        [Column(_Fax, SqlDbType.NVarChar, Nullable = true, Length = 24)]                          public string Fax;            //nvarchar(24) null
        [Column(_HomePage, SqlDbType.NText, Nullable = true)]                                     public string HomePage;       //ntext(16) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _SupplierID });
            }
        }



        public override IdentityKeys Identity
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

