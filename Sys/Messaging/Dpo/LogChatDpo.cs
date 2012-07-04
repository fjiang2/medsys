//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:12 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.Messaging.Dpo
{
    [Revision(10)]
    [Table("sys01201", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class LogChatDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_User_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string User_Name;      //nvarchar(50) null
        [Column(_Friend_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Friend_Name;    //nvarchar(50) null
        [Column(_Start_Time, SqlDbType.DateTime, Nullable = true)]                                public DateTime? Start_Time;  //datetime(8) null
        [Column(_End_Time, SqlDbType.DateTime, Nullable = true)]                                  public DateTime? End_Time;    //datetime(8) null
        [Column(_History, SqlDbType.NText, Nullable = true)]                                      public string History;        //ntext(16) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ID });
            }
        }



        public override IdentityKeys Identity
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

