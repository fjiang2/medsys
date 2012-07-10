//
// Machine Generated Code
//   by devel at 4/18/2012 3:50:03 PM
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
    [Revision(7)]
    [Table("Customers", Level.Default)]    //Primary Keys = CustomerID;  Identity = ;
    public class CustomerDpo : DPObject
    {

#pragma warning disable

        [Column(_CustomerID, SqlDbType.NChar, Primary = true, Length = 5)]                        public string CustomerID;     //nchar(5) not null
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
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _CustomerID });
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

