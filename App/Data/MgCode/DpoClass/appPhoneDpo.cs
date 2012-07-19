//
// Machine Generated Code
//   by devel at 7/16/2012 4:00:01 PM
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
    [Table("app00104", Level.Application, Pack = false)]    //Primary Keys = Phone_ID;  Identity = ;
    public class appPhoneDpo : DPObject
    {

#pragma warning disable

        [Column(_Phone_ID, SqlDbType.Int, Primary = true)]                                        public int Phone_ID;          //int(4) not null
        [Column(_Phone, SqlDbType.VarChar, Length = 16)]                                          public string Phone;          //varchar(16) not null
        [Column(_Mobile, SqlDbType.VarChar, Nullable = true, Length = 16)]                        public string Mobile;         //varchar(16) null
        [Column(_Fax, SqlDbType.VarChar, Nullable = true, Length = 16)]                           public string Fax;            //varchar(16) null
        [Column(_Pager, SqlDbType.VarChar, Nullable = true, Length = 16)]                         public string Pager;          //varchar(16) null

#pragma warning restore

        public appPhoneDpo()
        {
        }

        public appPhoneDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appPhoneDpo(int phone_id)
        {
           this.Phone_ID = phone_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Phone_ID = phone_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Phone_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Phone_ID });
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
              return new appPhoneDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Phone_ID = "Phone_ID";
        public const string _Phone = "Phone";
        public const string _Mobile = "Mobile";
        public const string _Fax = "Fax";
        public const string _Pager = "Pager";

       
        #endregion 



    }
}

