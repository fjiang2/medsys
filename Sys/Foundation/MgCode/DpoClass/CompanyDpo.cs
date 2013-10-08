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


namespace Sys.Foundation.DpoClass
{
    [Revision(14)]
    [Table("sys00504", Level.System, Pack = false)]    //Primary Keys = Comany_ID;  Identity = Comany_ID;
    public class CompanyDpo : DPObject
    {

#pragma warning disable

        [Column(_Comany_ID, CType.Int, Identity = true, Primary = true)]                      public int Comany_ID {get; set;} //int(4) not null
        [Column(_Name, CType.NVarChar, Length = 100)]                                         public string Name {get; set;} //nvarchar(100) not null
        [Column(_Address_ID, CType.NChar, Nullable = true, Length = 10)]                      public string Address_ID {get; set;} //nchar(10) null
        [Column(_Inactive, CType.Bit)]                                                        public bool Inactive {get; set;} //bit(1) not null
        [Column(_Default_DB, CType.VarChar, Nullable = true, Length = 50)]                    public string Default_DB {get; set;} //varchar(50) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Comany_ID });
            }
        }



        public override IIdentityKeys Identity
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

