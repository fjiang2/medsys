//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:07 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Foundation.Dpo
{
    [Revision(11)]
    [Table("sys00504", Level.System, Pack = false)]    //Primary Keys = Comany_ID;  Identity = Comany_ID;
    public class CompanyDpo : DPObject
    {

#pragma warning disable

        [Column(_Comany_ID, SqlDbType.Int, Identity = true, Primary = true)]                      public int Comany_ID;         //int(4) not null
        [Column(_Name, SqlDbType.NVarChar, Length = 100)]                                         public string Name;           //nvarchar(100) not null
        [Column(_Address_ID, SqlDbType.NChar, Nullable = true, Length = 10)]                      public string Address_ID;     //nchar(10) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null
        [Column(_Default_DB, SqlDbType.VarChar, Nullable = true, Length = 50)]                    public string Default_DB;     //varchar(50) null

#pragma warning restore

        public CompanyDpo()
        {
        }

        public CompanyDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CompanyDpo(int comany_id)
        {
           this.Comany_ID = comany_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Comany_ID = comany_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Comany_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Comany_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Comany_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new CompanyDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Comany_ID = "Comany_ID";
        public const string _Name = "Name";
        public const string _Address_ID = "Address_ID";
        public const string _Inactive = "Inactive";
        public const string _Default_DB = "Default_DB";

       
        #endregion 



    }
}

