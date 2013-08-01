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
    [Table("sys01302", Level.System)]    //Primary Keys = Name + Workflow_Name;  Identity = ID;
    public class wfStateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Workflow_Name, CType.NVarChar, Primary = true, Length = 50)]                 public string Workflow_Name {get; set;} //nvarchar(50) not null
        [Column(_Name, CType.NVarChar, Primary = true, Length = 50)]                          public string Name {get; set;} //nvarchar(50) not null
        [Column(_Index, CType.Int, Nullable = true)]                                          public int? Index {get; set;} //int(4) null
        [Column(_Label, CType.NVarChar, Nullable = true, Length = 50)]                        public string Label {get; set;} //nvarchar(50) null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 500)]                 public string Description {get; set;} //nvarchar(500) null
        [Column(_Ty, CType.Int)]                                                              public int Ty {get; set;}     //int(4) not null
        [Column(_Offset, CType.Float)]                                                        public double Offset {get; set;} //float(8) not null
        [Column(_Duration, CType.Float)]                                                      public double Duration {get; set;} //float(8) not null
        [Column(_Metadata, CType.NVarChar, Nullable = true, Length = 1024)]                   public string Metadata {get; set;} //nvarchar(1024) null
        [Column(_Dependency, CType.NVarChar, Length = 1024)]                                  public string Dependency {get; set;} //nvarchar(1024) not null
        [Column(_Preaction, CType.NVarChar, Nullable = true, Length = 1024)]                  public string Preaction {get; set;} //nvarchar(1024) null
        [Column(_Action, CType.NVarChar, Length = 1024)]                                      public string Action {get; set;} //nvarchar(1024) not null
        [Column(_AfterAction, CType.NVarChar, Nullable = true, Length = 1024)]                public string AfterAction {get; set;} //nvarchar(1024) null
        [Column(_Postaction, CType.NVarChar, Nullable = true, Length = 1024)]                 public string Postaction {get; set;} //nvarchar(1024) null
        [Column(_Channel, CType.Int)]                                                         public int Channel {get; set;} //int(4) not null
        [Column(_Agent, CType.NVarChar, Nullable = true, Length = 1024)]                      public string Agent {get; set;} //nvarchar(1024) null

#pragma warning restore

        public wfStateDpo()
        {
        }

        public wfStateDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfStateDpo(string name, string workflow_name)
        {
           this.Name = name; this.Workflow_Name = workflow_name; 

           this.Load();
           if(!this.Exists)
           {
              this.Name = name; this.Workflow_Name = workflow_name;     
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
                return new PrimaryKeys(new string[]{ _Name, _Workflow_Name });
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
              return new wfStateDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Workflow_Name = "Workflow_Name";
        public const string _Name = "Name";
        public const string _Index = "Index";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Ty = "Ty";
        public const string _Offset = "Offset";
        public const string _Duration = "Duration";
        public const string _Metadata = "Metadata";
        public const string _Dependency = "Dependency";
        public const string _Preaction = "Preaction";
        public const string _Action = "Action";
        public const string _AfterAction = "AfterAction";
        public const string _Postaction = "Postaction";
        public const string _Channel = "Channel";
        public const string _Agent = "Agent";

       
        #endregion 



    }
}

