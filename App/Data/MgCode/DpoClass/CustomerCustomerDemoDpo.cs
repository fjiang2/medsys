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
    [Revision(11)]
    [Table("Northwind..[CustomerCustomerDemo]", Level.Fixed)]    //Primary Keys = CustomerID + CustomerTypeID;  Identity = ;
    public class CustomerCustomerDemoDpo : DPObject
    {

#pragma warning disable

        [ForeignKey(typeof(App.Data.DpoClass.CustomerDpo), App.Data.DpoClass.CustomerDpo._CustomerID)]
        [Column(_CustomerID, SqlDbType.NChar, Primary = true, Length = 5)]                        public string CustomerID {get; set;} //nchar(5) not null
        [ForeignKey(typeof(App.Data.DpoClass.CustomerDemographicDpo), App.Data.DpoClass.CustomerDemographicDpo._CustomerTypeID)]
        [Column(_CustomerTypeID, SqlDbType.NChar, Primary = true, Length = 10)]                   public string CustomerTypeID {get; set;} //nchar(10) not null

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

