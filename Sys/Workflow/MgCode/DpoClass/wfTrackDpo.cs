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


namespace Sys.Workflow.DpoClass
{
    [Revision(14)]
    [Table("sys01307", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfTrackDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_WorkflowInstance_ID, SqlDbType.Int)]                                             public int WorkflowInstance_ID {get; set;} //int(4) not null
        [Column(_S1_Name, SqlDbType.NVarChar, Length = 50)]                                       public string S1_Name {get; set;} //nvarchar(50) not null
        [Column(_S2_Name, SqlDbType.NVarChar, Length = 50)]                                       public string S2_Name {get; set;} //nvarchar(50) not null
        [Column(_User_ID, SqlDbType.Int)]                                                         public int User_ID {get; set;} //int(4) not null
        [Column(_Date_Created, SqlDbType.DateTime)]                                               public DateTime Date_Created {get; set;} //datetime(8) not null

#pragma warning restore

        public wfTrackDpo()
        {
        }

        public wfTrackDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfTrackDpo(int id)
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
              return new wfTrackDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _WorkflowInstance_ID = "WorkflowInstance_ID";
        public const string _S1_Name = "S1_Name";
        public const string _S2_Name = "S2_Name";
        public const string _User_ID = "User_ID";
        public const string _Date_Created = "Date_Created";

       
        #endregion 



    }
}

