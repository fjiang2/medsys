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


namespace Sys.SmartList.DpoClass
{
    [Revision(9)]
    [Table("sys01103", Level.System)]    //Primary Keys = Command_ID + url;  Identity = ID;
    public class RepxDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Command_ID, CType.Int, Primary = true)]                                      public int Command_ID {get; set;} //int(4) not null
        [Column(_url, CType.NVarChar, Primary = true, Length = 50)]                           public string url {get; set;} //nvarchar(50) not null
        [Column(_repx, CType.NText)]                                                          public string repx {get; set;} //ntext(16) not null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Command_ID, _url });
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

