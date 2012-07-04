//
// Machine Generated Code
//   by devel at 4/23/2012 12:41:52 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.SmartList.Dpo
{
    [Revision(6)]
    [Table("sys01103", Level.System)]    //Primary Keys = Command_ID + url;  Identity = ID;
    public class RepxDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Command_ID, SqlDbType.Int, Primary = true)]                                      public int Command_ID;        //int(4) not null
        [Column(_url, SqlDbType.NVarChar, Primary = true, Length = 50)]                           public string url;            //nvarchar(50) not null
        [Column(_repx, SqlDbType.NText)]                                                          public string repx;           //ntext(16) not null

#pragma warning restore

        public RepxDpo()
        {
        }

        public RepxDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public RepxDpo(int command_id, string url)
        {
           this.Command_ID = command_id; this.url = url; 

           this.Load();
           if(!this.Exists)
           {
              this.Command_ID = command_id; this.url = url;     
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
                return new PrimaryKeys(new string[]{ _Command_ID, _url });
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
              return new RepxDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Command_ID = "Command_ID";
        public const string _url = "url";
        public const string _repx = "repx";

       
        #endregion 



    }
}

