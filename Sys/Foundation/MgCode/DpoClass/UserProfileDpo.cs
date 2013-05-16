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
    [Revision(13)]
    [Table("sys00505", Level.System, Pack = false)]    //Primary Keys = User_ID;  Identity = ;
    public class UserProfileDpo : DPObject
    {

#pragma warning disable

        [Column(_User_ID, SqlDbType.Int, Primary = true)]                                         public int User_ID {get; set;} //int(4) not null
        [Column(_Setting, SqlDbType.Text, Nullable = true)]                                       public string Setting {get; set;} //text(16) null
        [Column(_Configuration, SqlDbType.Text, Nullable = true)]                                 public string Configuration {get; set;} //text(16) null

#pragma warning restore

        public UserProfileDpo()
        {
        }

        public UserProfileDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public UserProfileDpo(int user_id)
        {
           this.User_ID = user_id; 

           this.Load();
           if(!this.Exists)
           {
              this.User_ID = user_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.User_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _User_ID });
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
              return new UserProfileDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _User_ID = "User_ID";
        public const string _Setting = "Setting";
        public const string _Configuration = "Configuration";

       
        #endregion 



    }
}

