//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:40 AM
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
    [Revision(11)]
    [Table("sys00401", Level.System)]    //Primary Keys = ID;  Identity = ID;
    internal class SysRuleDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_Error_Code, SqlDbType.Int)]                                                      public int Error_Code;        //int(4) not null
        [Column(_OrderBy, SqlDbType.Int, Nullable = true)]                                        public int? OrderBy;          //int(4) null
        [Column(_Workflow_Name, SqlDbType.NVarChar, Length = 128)]                                public string Workflow_Name;  //nvarchar(128) not null
        [Column(_State_Name, SqlDbType.NVarChar, Nullable = true, Length = 128)]                  public string State_Name;     //nvarchar(128) null
        [Column(_Label, SqlDbType.NVarChar, Length = 256)]                                        public string Label;          //nvarchar(256) not null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 512)]                 public string Description;    //nvarchar(512) null
        [Column(_Turned_Off_Ind, SqlDbType.Bit)]                                                  public bool Turned_Off_Ind;   //bit(1) not null
        [Column(_Rule_Direct_Ind, SqlDbType.Bit, Nullable = true)]                                public bool? Rule_Direct_Ind; //bit(1) null
        [Column(_Antecedent, SqlDbType.NVarChar, Nullable = true, Length = 2024)]                 public string Antecedent;     //nvarchar(2024) null
        [Column(_Consequent, SqlDbType.NVarChar, Nullable = true, Length = 2024)]                 public string Consequent;     //nvarchar(2024) null
        [Column(_Severity_Level, SqlDbType.Int, Nullable = true)]                                 public int? Severity_Level;   //int(4) null
        [Column(_Trace_Key, SqlDbType.NVarChar, Nullable = true, Length = 128)]                   public string Trace_Key;      //nvarchar(128) null
        [Column(_Message, SqlDbType.NVarChar, Nullable = true, Length = 2024)]                    public string Message;        //nvarchar(2024) null
        [Column(_Business_Rule, SqlDbType.NVarChar, Length = 4000)]                               public string Business_Rule;  //nvarchar(4000) not null
        [Column(_Specification, SqlDbType.NVarChar, Nullable = true, Length = 4000)]              public string Specification;  //nvarchar(4000) null
        [Column(_Comment, SqlDbType.NVarChar, Nullable = true, Length = 4000)]                    public string Comment;        //nvarchar(4000) null
        [Column(_Released, SqlDbType.Bit)]                                                        public bool Released;         //bit(1) not null
        [Column(_Date_Created, SqlDbType.DateTime, Nullable = true)]                              public DateTime? Date_Created;//datetime(8) null
        [Column(_Creator, SqlDbType.Int, Nullable = true)]                                        public int? Creator;          //int(4) null
        [Column(_Date_Modified, SqlDbType.DateTime, Nullable = true)]                             public DateTime? Date_Modified;//datetime(8) null
        [Column(_Modifier, SqlDbType.Int, Nullable = true)]                                       public int? Modifier;         //int(4) null

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
