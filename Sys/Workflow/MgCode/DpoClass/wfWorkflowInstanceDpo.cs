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
    [Table("sys01304", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfWorkflowInstanceDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Workflow_Name, CType.NVarChar, Length = 50)]                                 public string Workflow_Name {get; set;} //nvarchar(50) not null
        [Column(_Label, CType.NVarChar, Length = 128)]                                        public string Label {get; set;} //nvarchar(128) not null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 1024)]                public string Description {get; set;} //nvarchar(1024) null
        [Column(_Work_Date, CType.DateTime, Nullable = true)]                                 public DateTime? Work_Date {get; set;} //datetime(8) null
        [Column(_Complete_Date, CType.DateTime, Nullable = true)]                             public DateTime? Complete_Date {get; set;} //datetime(8) null
        [Column(_Heap, CType.NText, Nullable = true)]                                         public string Heap {get; set;} //ntext(16) null
        [Column(_Deleted, CType.Bit)]                                                         public bool Deleted {get; set;} //bit(1) not null

#pragma warning restore

        public wfWorkflowInstanceDpo()
        {
        }

        public wfWorkflowInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfWorkflowInstanceDpo(int id)
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
              return new wfWorkflowInstanceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Workflow_Name = "Workflow_Name";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Work_Date = "Work_Date";
        public const string _Complete_Date = "Complete_Date";
        public const string _Heap = "Heap";
        public const string _Deleted = "Deleted";

       
        #endregion 



    }
}

