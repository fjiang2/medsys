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


namespace App.Data.Dpo
{
    [Revision(9)]
    [Table("CustomerDemographics", Level.Default)]    //Primary Keys = CustomerTypeID;  Identity = ;
    public class CustomerDemographicDpo : DPObject
    {

#pragma warning disable

        [Column(_CustomerTypeID, SqlDbType.NChar, Primary = true, Length = 10)]                   public string CustomerTypeID; //nchar(10) not null
        [Column(_CustomerDesc, SqlDbType.NText, Nullable = true)]                                 public string CustomerDesc;   //ntext(16) null

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
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _CustomerTypeID });
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
              return new CustomerDemographicDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _CustomerTypeID = "CustomerTypeID";
        public const string _CustomerDesc = "CustomerDesc";

       
        #endregion 



    }
}

