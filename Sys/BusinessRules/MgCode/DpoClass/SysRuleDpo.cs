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


namespace Sys.BusinessRules.DpoClass
{
    [Revision(13)]
    [Table("sys00401", Level.System)]    //Primary Keys = ID;  Identity = ID;
    internal class SysRuleDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Error_Code, CType.Int)]                                                      public int Error_Code {get; set;} //int(4) not null
        [Column(_OrderBy, CType.Int, Nullable = true)]                                        public int? OrderBy {get; set;} //int(4) null
        [Column(_Workflow_Name, CType.NVarChar, Length = 128)]                                public string Workflow_Name {get; set;} //nvarchar(128) not null
        [Column(_State_Name, CType.NVarChar, Nullable = true, Length = 128)]                  public string State_Name {get; set;} //nvarchar(128) null
        [Column(_Label, CType.NVarChar, Length = 256)]                                        public string Label {get; set;} //nvarchar(256) not null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 512)]                 public string Description {get; set;} //nvarchar(512) null
        [Column(_Turned_Off_Ind, CType.Bit)]                                                  public bool Turned_Off_Ind {get; set;} //bit(1) not null
        [Column(_Rule_Direct_Ind, CType.Bit, Nullable = true)]                                public bool? Rule_Direct_Ind {get; set;} //bit(1) null
        [Column(_Antecedent, CType.NVarChar, Nullable = true, Length = 2024)]                 public string Antecedent {get; set;} //nvarchar(2024) null
        [Column(_Consequent, CType.NVarChar, Nullable = true, Length = 2024)]                 public string Consequent {get; set;} //nvarchar(2024) null
        [Column(_Severity_Level, CType.Int, Nullable = true)]                                 public int? Severity_Level {get; set;} //int(4) null
        [Column(_Trace_Key, CType.NVarChar, Nullable = true, Length = 128)]                   public string Trace_Key {get; set;} //nvarchar(128) null
        [Column(_Message, CType.NVarChar, Nullable = true, Length = 2024)]                    public string Message {get; set;} //nvarchar(2024) null
        [Column(_Business_Rule, CType.NVarChar, Length = 4000)]                               public string Business_Rule {get; set;} //nvarchar(4000) not null
        [Column(_Specification, CType.NVarChar, Nullable = true, Length = 4000)]              public string Specification {get; set;} //nvarchar(4000) null
        [Column(_Comment, CType.NVarChar, Nullable = true, Length = 4000)]                    public string Comment {get; set;} //nvarchar(4000) null
        [Column(_Released, CType.Bit)]                                                        public bool Released {get; set;} //bit(1) not null
        [Column(_Date_Created, CType.DateTime, Nullable = true)]                              public DateTime? Date_Created {get; set;} //datetime(8) null
        [Column(_Creator, CType.Int, Nullable = true)]                                        public int? Creator {get; set;} //int(4) null
        [Column(_Date_Modified, CType.DateTime, Nullable = true)]                             public DateTime? Date_Modified {get; set;} //datetime(8) null
        [Column(_Modifier, CType.Int, Nullable = true)]                                       public int? Modifier {get; set;} //int(4) null

#pragma warning restore

        public SysRuleDpo()
        {
        }

        public SysRuleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public SysRuleDpo(int id)
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
              return new SysRuleDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Error_Code = "Error_Code";
        public const string _OrderBy = "OrderBy";
        public const string _Workflow_Name = "Workflow_Name";
        public const string _State_Name = "State_Name";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Turned_Off_Ind = "Turned_Off_Ind";
        public const string _Rule_Direct_Ind = "Rule_Direct_Ind";
        public const string _Antecedent = "Antecedent";
        public const string _Consequent = "Consequent";
        public const string _Severity_Level = "Severity_Level";
        public const string _Trace_Key = "Trace_Key";
        public const string _Message = "Message";
        public const string _Business_Rule = "Business_Rule";
        public const string _Specification = "Specification";
        public const string _Comment = "Comment";
        public const string _Released = "Released";
        public const string _Date_Created = "Date_Created";
        public const string _Creator = "Creator";
        public const string _Date_Modified = "Date_Modified";
        public const string _Modifier = "Modifier";

       
        #endregion 



    }
}

