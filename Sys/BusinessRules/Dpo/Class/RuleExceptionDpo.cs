//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:06 PM
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
    [Revision(10)]
    [Table("sys00402", Level.System)]    //Primary Keys = ;  Identity = ID;
    internal class RuleExceptionDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Error_Code, SqlDbType.Int)]                                                      public int Error_Code;        //int(4) not null
        [Column(_WorkflowInstance_ID, SqlDbType.Int, Nullable = true)]                            public int? WorkflowInstance_ID;//int(4) null
        [Column(_Reason, SqlDbType.NVarChar, Nullable = true, Length = 512)]                      public string Reason;         //nvarchar(512) null
        [Column(_Date_Created, SqlDbType.DateTime, Nullable = true)]                              public DateTime? Date_Created;//datetime(8) null
        [Column(_Creator, SqlDbType.Int, Nullable = true)]                                        public int? Creator;          //int(4) null
        [Column(_Date_Modified, SqlDbType.DateTime, Nullable = true)]                             public DateTime? Date_Modified;//datetime(8) null
        [Column(_Modifier, SqlDbType.Int, Nullable = true)]                                       public int? Modifier;         //int(4) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[] {});
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

