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
using Sys.Data.Manager;


namespace App.Data.DpoClass
{
    [Revision(9)]
    [Table("Northwind..CustomerCustomerDemo", Level.Fixed)]    //Primary Keys = CustomerID + CustomerTypeID;  Identity = ;
    public class CustomerCustomerDemoDpo : DPObject
    {

#pragma warning disable

        [Column(_CustomerID, SqlDbType.NChar, Primary = true, Length = 5)]                        public string CustomerID;     //nchar(5) not null
        [Column(_CustomerTypeID, SqlDbType.NChar, Primary = true, Length = 10)]                   public string CustomerTypeID; //nchar(10) not null

#pragma warning restore

        public CustomerCustomerDemoDpo()
        {
        }

        public CustomerCustomerDemoDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CustomerCustomerDemoDpo(string customerid, string customertypeid)
        {
           this.CustomerID = customerid; this.CustomerTypeID = customertypeid; 

           this.Load();
           if(!this.Exists)
           {
              this.CustomerID = customerid; this.CustomerTypeID = customertypeid;     
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
                return new PrimaryKeys(new string[]{ _CustomerID, _CustomerTypeID });
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
              return new CustomerCustomerDemoDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _CustomerID = "CustomerID";
        public const string _CustomerTypeID = "CustomerTypeID";

       
        #endregion 



    }
}

