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
    [Table("sys01308", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfNoteDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_WorkflowInstance_ID, CType.Int, Nullable = true)]                            public int? WorkflowInstance_ID {get; set;} //int(4) null
        [Column(_S1_Name, CType.NVarChar, Nullable = true, Length = 50)]                      public string S1_Name {get; set;} //nvarchar(50) null
        [Column(_S2_Name, CType.NVarChar, Nullable = true, Length = 50)]                      public string S2_Name {get; set;} //nvarchar(50) null
        [Column(_User_ID, CType.Int, Nullable = true)]                                        public int? User_ID {get; set;} //int(4) null
        [Column(_Date_Created, CType.DateTime, Nullable = true)]                              public DateTime? Date_Created {get; set;} //datetime(8) null
        [Column(_Comment, CType.NVarChar, Nullable = true, Length = -1)]                      public string Comment {get; set;} //nvarchar(-1) null

#pragma warning restore

        public wfNoteDpo()
        {
        }

        public wfNoteDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfNoteDpo(int id)
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
              return new wfNoteDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _WorkflowInstance_ID = "WorkflowInstance_ID";
        public const string _S1_Name = "S1_Name";
        public const string _S2_Name = "S2_Name";
        public const string _User_ID = "User_ID";
        public const string _Date_Created = "Date_Created";
        public const string _Comment = "Comment";

       
        #endregion 



    }
}

