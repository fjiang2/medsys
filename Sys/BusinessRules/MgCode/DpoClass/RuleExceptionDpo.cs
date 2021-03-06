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
    [Table("sys00402", Level.System)]    //Primary Keys = ;  Identity = ID;
    internal class RuleExceptionDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Error_Code, CType.Int)]                                                      public int Error_Code {get; set;} //int(4) not null
        [Column(_WorkflowInstance_ID, CType.Int, Nullable = true)]                            public int? WorkflowInstance_ID {get; set;} //int(4) null
        [Column(_Reason, CType.NVarChar, Nullable = true, Length = 512)]                      public string Reason {get; set;} //nvarchar(512) null
        [Column(_Date_Created, CType.DateTime, Nullable = true)]                              public DateTime? Date_Created {get; set;} //datetime(8) null
        [Column(_Creator, CType.Int, Nullable = true)]                                        public int? Creator {get; set;} //int(4) null
        [Column(_Date_Modified, CType.DateTime, Nullable = true)]                             public DateTime? Date_Modified {get; set;} //datetime(8) null
        [Column(_Modifier, CType.Int, Nullable = true)]                                       public int? Modifier {get; set;} //int(4) null

#pragma warning restore

        public RuleExceptionDpo()
        {
        }

        public RuleExceptionDpo(DataRow dataRow)
            :base(dataRow)
        {
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
                return new PrimaryKeys(new string[] {});
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
              return new RuleExceptionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Error_Code = "Error_Code";
        public const string _WorkflowInstance_ID = "WorkflowInstance_ID";
        public const string _Reason = "Reason";
        public const string _Date_Created = "Date_Created";
        public const string _Creator = "Creator";
        public const string _Date_Modified = "Date_Modified";
        public const string _Modifier = "Modifier";

       
        #endregion 



    }
}

