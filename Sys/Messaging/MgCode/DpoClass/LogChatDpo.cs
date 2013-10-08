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


namespace Sys.Messaging.DpoClass
{
    [Revision(13)]
    [Table("sys01201", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class LogChatDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_User_Name, CType.NVarChar, Nullable = true, Length = 50)]                    public string User_Name {get; set;} //nvarchar(50) null
        [Column(_Friend_Name, CType.NVarChar, Nullable = true, Length = 50)]                  public string Friend_Name {get; set;} //nvarchar(50) null
        [Column(_Start_Time, CType.DateTime, Nullable = true)]                                public DateTime? Start_Time {get; set;} //datetime(8) null
        [Column(_End_Time, CType.DateTime, Nullable = true)]                                  public DateTime? End_Time {get; set;} //datetime(8) null
        [Column(_History, CType.NText, Nullable = true)]                                      public string History {get; set;} //ntext(16) null

#pragma warning restore

        public LogChatDpo()
        {
        }

        public LogChatDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public LogChatDpo(int id)
        {
           this.ID = id; 

           this.Load();
           if(!this.Exists)
           {
              this.ID = id;     
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
                return new PrimaryKeys(new string[]{ _ID });
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
              return new LogChatDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _User_Name = "User_Name";
        public const string _Friend_Name = "Friend_Name";
        public const string _Start_Time = "Start_Time";
        public const string _End_Time = "End_Time";
        public const string _History = "History";

       
        #endregion 



    }
}

