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
    [Revision(3)]
    [Table("app00102", Level.Application, Pack = false)]    //Primary Keys = Address_ID;  Identity = Address_ID;
    public class appAddressDpo : DPObject
    {

#pragma warning disable

        [Column(_Address_ID, SqlDbType.Int, Identity = true, Primary = true)]                     public int Address_ID {get; set;} //int(4) not null
        [Column(_Address_Enum, SqlDbType.Int)]                                                    public int Address_Enum {get; set;} //int(4) not null
        [Column(_Street_Number, SqlDbType.Int, Nullable = true)]                                  public int? Street_Number {get; set;} //int(4) null
        [Column(_Street_Name, SqlDbType.NVarChar, Nullable = true, Length = 150)]                 public string Street_Name {get; set;} //nvarchar(150) null
        [Column(_Apartment, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Apartment {get; set;} //nvarchar(50) null
        [Column(_City, SqlDbType.NVarChar, Nullable = true, Length = 50)]                         public string City {get; set;} //nvarchar(50) null
        [Column(_State, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string State {get; set;} //nvarchar(50) null
        [Column(_Postal_Code, SqlDbType.VarChar, Nullable = true, Length = 12)]                   public string Postal_Code {get; set;} //varchar(12) null
        [Column(_Country_Code, SqlDbType.NVarChar, Nullable = true, Length = 50)]                 public string Country_Code {get; set;} //nvarchar(50) null
        [Column(_Country_Sub_Code, SqlDbType.NVarChar, Nullable = true, Length = 20)]             public string Country_Sub_Code {get; set;} //nvarchar(20) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Address_ID });
            }
        }



        public override IIdentityKeys Identity
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
        public const string _Address_Enum = "Address_Enum";
        public const string _Street_Number = "Street_Number";
        public const string _Street_Name = "Street_Name";
        public const string _Apartment = "Apartment";
        public const string _City = "City";
        public const string _State = "State";
        public const string _Postal_Code = "Postal_Code";
        public const string _Country_Code = "Country_Code";
        public const string _Country_Sub_Code = "Country_Sub_Code";

       
        #endregion 



    }
}

