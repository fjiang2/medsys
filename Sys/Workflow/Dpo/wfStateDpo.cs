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
using Sys.Data.Manager;
using Tie;

namespace Sys.Workflow.Dpo
{
    [Revision(11)]
    [Table("sys01302", Level.System)]    //Primary Keys = Name + Workflow_Name;  Identity = ID;
    public class wfStateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Workflow_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                 public string Workflow_Name;  //nvarchar(50) not null
        [Column(_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                          public string Name;           //nvarchar(50) not null
        [Column(_Index, SqlDbType.Int, Nullable = true)]                                          public int? Index;            //int(4) null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Label;          //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 500)]                 public string Description;    //nvarchar(500) null
        [Column(_Ty, SqlDbType.Int)]                                                              [NonValized] public int Ty;                //int(4) not null
        [Column(_Offset, SqlDbType.Float)]                                                        public double Offset;         //float(8) not null
        [Column(_Duration, SqlDbType.Float)]                                                      public double Duration;       //float(8) not null
        [Column(_Metadata, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                   public string Metadata;       //nvarchar(1024) null
        [Column(_Dependency, SqlDbType.NVarChar, Length = 1024)]                                  public string Dependency;     //nvarchar(1024) not null
        [Column(_Preaction, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                  public string Preaction;      //nvarchar(1024) null
        [Column(_Action, SqlDbType.NVarChar, Length = 1024)]                                      public string Action;         //nvarchar(1024) not null
        [Column(_AfterAction, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                public string AfterAction;    //nvarchar(1024) null
        [Column(_Postaction, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                 public string Postaction;     //nvarchar(1024) null
        [Column(_Channel, SqlDbType.Int)]                                                         public int Channel;           //int(4) not null
        [Column(_Agent, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                      public string Agent;          //nvarchar(1024) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Name, _Workflow_Name });
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

