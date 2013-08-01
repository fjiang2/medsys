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
    [Revision(9)]
    [Table("Northwind..[Customers]", Level.Fixed)]    //Primary Keys = CustomerID;  Identity = ;
    public class CustomerDpo : DPObject
    {

#pragma warning disable

        [Column(_CustomerID, CType.NChar, Primary = true, Length = 5)]                        public string CustomerID {get; set;} //nchar(5) not null
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

#pragma warning restore

        public CustomerDpo()
        {
        }

        public CustomerDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CustomerDpo(string customerid)
        {
           this.CustomerID = customerid; 

           this.Load();
           if(!this.Exists)
           {
              this.CustomerID = customerid;     
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
        


        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _CustomerID });
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
              return new CustomerDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _CustomerID = "CustomerID";
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

       
        #endregion 



    }
}

