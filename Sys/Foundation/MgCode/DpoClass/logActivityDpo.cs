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
    [Revision(16)]
    [Table("sys00304", Level.System, Pack = false)]    //Primary Keys = Application_Name + Computer_Name + User_Name;  Identity = ID;
    internal class logActivityDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_User_Name, CType.VarChar, Primary = true, Length = 20)]                      public string User_Name {get; set;} //varchar(20) not null
        [Column(_Application_Name, CType.VarChar, Primary = true, Length = 50)]               public string Application_Name {get; set;} //varchar(50) not null
        [Column(_Computer_Name, CType.VarChar, Primary = true, Length = 15)]                  public string Computer_Name {get; set;} //varchar(15) not null
        [Column(_DateEntered, CType.DateTime)]                                                public DateTime DateEntered {get; set;} //datetime(8) not null
        [Column(_Version, CType.VarChar, Nullable = true, Length = 10)]                       public string Version {get; set;} //varchar(10) null

#pragma warning restore

        public logActivityDpo()
        {
        }

        public logActivityDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public logActivityDpo(string application_name, string computer_name, string user_name)
        {
           this.Application_Name = application_name; this.Computer_Name = computer_name; this.User_Name = user_name; 

           this.Load();
           if(!this.Exists)
           {
              this.Application_Name = application_name; this.Computer_Name = computer_name; this.User_Name = user_name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Application_Name, _Computer_Name, _User_Name });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new logActivityDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _User_Name = "User_Name";
        public const string _Application_Name = "Application_Name";
        public const string _Computer_Name = "Computer_Name";
        public const string _DateEntered = "DateEntered";
        public const string _Version = "Version";

       
        #endregion 



    }
}

