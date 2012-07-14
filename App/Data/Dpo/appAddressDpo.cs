//
// Machine Generated Code
//   by devel at 7/12/2012 1:15:41 PM
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
    [Revision(0)]
    [Table("app00102", Level.System, Pack = false)]    //Primary Keys = Address_ID;  Identity = Address_ID;
    public class appAddressDpo : DPObject
    {

#pragma warning disable

        [Column(_Address_ID, SqlDbType.Int, Identity = true, Primary = true)]                     public int Address_ID;        //int(4) not null
        [Column(_Category, SqlDbType.Int)]                                                        public int Category;          //int(4) not null
        [Column(_Street_Number, SqlDbType.Int, Nullable = true)]                                  public int? Street_Number;    //int(4) null
        [Column(_Street_Name, SqlDbType.NVarChar, Nullable = true, Length = 150)]                 public string Street_Name;    //nvarchar(150) null
        [Column(_Apartment, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Apartment;      //nvarchar(50) null
        [Column(_City, SqlDbType.NVarChar, Nullable = true, Length = 50)]                         public string City;           //nvarchar(50) null
        [Column(_State, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string State;          //nvarchar(50) null
        [Column(_Country_Code, SqlDbType.NVarChar, Nullable = true, Length = 50)]                 public string Country_Code;   //nvarchar(50) null
        [Column(_Postal_Code, SqlDbType.VarChar, Nullable = true, Length = 12)]                   public string Postal_Code;    //varchar(12) null

#pragma warning restore

        public appAddressDpo()
        {
        }

        public appAddressDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appAddressDpo(int address_id)
        {
           this.Address_ID = address_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Address_ID = address_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Address_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Address_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Address_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new appAddressDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Address_ID = "Address_ID";
        public const string _Category = "Category";
        public const string _Street_Number = "Street_Number";
        public const string _Street_Name = "Street_Name";
        public const string _Apartment = "Apartment";
        public const string _City = "City";
        public const string _State = "State";
        public const string _Country_Code = "Country_Code";
        public const string _Postal_Code = "Postal_Code";

       
        #endregion 



    }
}

