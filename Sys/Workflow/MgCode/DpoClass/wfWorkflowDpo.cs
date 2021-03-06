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
    [Table("sys01301", Level.System)]    //Primary Keys = Name;  Identity = ID;
    public class wfWorkflowDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, CType.Int, Nullable = true)]                                       public int? ParentID {get; set;} //int(4) null
        [Column(_Name, CType.NVarChar, Primary = true, Length = 50)]                          public string Name {get; set;} //nvarchar(50) not null
        [Column(_Company, CType.NVarChar, Nullable = true, Length = 50)]                      public string Company {get; set;} //nvarchar(50) null
        [Column(_Label, CType.NVarChar, Length = 128)]                                        public string Label {get; set;} //nvarchar(128) not null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 1024)]                public string Description {get; set;} //nvarchar(1024) null
        [Column(_Metadata, CType.NText, Nullable = true)]                                     public string Metadata {get; set;} //ntext(16) null
        [Column(_Released, CType.Bit)]                                                        public bool Released {get; set;} //bit(1) not null
        [Column(_Visible, CType.Bit)]                                                         public bool Visible {get; set;} //bit(1) not null
        [Column(_Enabled, CType.Bit)]                                                         public bool Enabled {get; set;} //bit(1) not null
        [Column(_Deleted, CType.Bit)]                                                         public bool Deleted {get; set;} //bit(1) not null
        [Column(_Date_Created, CType.DateTime, Nullable = true)]                              public DateTime? Date_Created {get; set;} //datetime(8) null
        [Column(_Creator, CType.Int, Nullable = true)]                                        public int? Creator {get; set;} //int(4) null
        [Column(_Date_Modified, CType.DateTime, Nullable = true)]                             public DateTime? Date_Modified {get; set;} //datetime(8) null
        [Column(_Modifier, CType.Int, Nullable = true)]                                       public int? Modifier {get; set;} //int(4) null

#pragma warning restore

        public wfWorkflowDpo()
        {
        }

        public wfWorkflowDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfWorkflowDpo(string name)
        {
           this.Name = name; 

           this.Load();
           if(!this.Exists)
           {
              this.Name = name;     
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
                return new PrimaryKeys(new string[]{ _Name });
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
              return new wfWorkflowDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _Name = "Name";
        public const string _Company = "Company";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Metadata = "Metadata";
        public const string _Released = "Released";
        public const string _Visible = "Visible";
        public const string _Enabled = "Enabled";
        public const string _Deleted = "Deleted";
        public const string _Date_Created = "Date_Created";
        public const string _Creator = "Creator";
        public const string _Date_Modified = "Date_Modified";
        public const string _Modifier = "Modifier";

       
        #endregion 



    }
}

