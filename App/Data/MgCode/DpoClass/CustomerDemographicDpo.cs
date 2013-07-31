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
    [Table("Northwind..[CustomerDemographics]", Level.Fixed)]    //Primary Keys = CustomerTypeID;  Identity = ;
    public class CustomerDemographicDpo : DPObject
    {

#pragma warning disable

        [Column(_CustomerTypeID, SqlDbType.NChar, Primary = true, Length = 10)]                   public string CustomerTypeID {get; set;} //nchar(10) not null
        [Column(_CustomerDesc, SqlDbType.NText, Nullable = true)]                                 public string CustomerDesc {get; set;} //ntext(16) null

#pragma warning restore

        public CustomerDemographicDpo()
        {
        }

        public CustomerDemographicDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CustomerDemographicDpo(string customertypeid)
        {
           this.CustomerTypeID = customertypeid; 

           this.Load();
           if(!this.Exists)
           {
              this.CustomerTypeID = customertypeid;     
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
                return new PrimaryKeys(new string[]{ _CustomerTypeID });
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
              return new CustomerDemographicDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _CustomerTypeID = "CustomerTypeID";
        public const string _CustomerDesc = "CustomerDesc";

       
        #endregion 



    }
}

