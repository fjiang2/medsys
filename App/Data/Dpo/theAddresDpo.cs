//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:16 PM
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
    [Revision(9)]
    [Table("theAddress", Level.System)]    //Primary Keys = Addr_ID;  Identity = Addr_ID;
    public class theAddresDpo : DPObject
    {

#pragma warning disable

        [Column(_Addr_ID, SqlDbType.Int, Identity = true, Primary = true)]                        public int Addr_ID;           //int(4) not null
        [Column(_Street1, SqlDbType.NVarChar, Length = 100)]                                      public string Street1;        //nvarchar(100) not null
        [Column(_Street2, SqlDbType.NVarChar, Nullable = true, Length = 100)]                     public string Street2;        //nvarchar(100) null
        [Column(_City, SqlDbType.NVarChar, Length = 50)]                                          public string City;           //nvarchar(50) not null
        [Column(_State, SqlDbType.NVarChar, Length = 50)]                                         public string State;          //nvarchar(50) not null
        [Column(_Zip, SqlDbType.NVarChar, Length = 10)]                                           public string Zip;            //nvarchar(10) not null
        [Column(_Country_Code, SqlDbType.NVarChar, Nullable = true, Length = 50)]                 public string Country_Code;   //nvarchar(50) null
        [Column(_Country_Sub_Code, SqlDbType.NChar, Nullable = true, Length = 10)]                public string Country_Sub_Code;//nchar(10) null

#pragma warning restore

        public theAddresDpo()
        {
        }

        public theAddresDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theAddresDpo(int addr_id)
        {
           this.Addr_ID = addr_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Addr_ID = addr_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Addr_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Addr_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Addr_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theAddresDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Addr_ID = "Addr_ID";
        public const string _Street1 = "Street1";
        public const string _Street2 = "Street2";
        public const string _City = "City";
        public const string _State = "State";
        public const string _Zip = "Zip";
        public const string _Country_Code = "Country_Code";
        public const string _Country_Sub_Code = "Country_Sub_Code";

       
        #endregion 



    }
}

