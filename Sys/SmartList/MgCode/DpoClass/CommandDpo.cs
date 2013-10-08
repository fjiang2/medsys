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


namespace Sys.SmartList.DpoClass
{
    [Revision(19)]
    [Table("sys01101", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class CommandDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, CType.Int)]                                                        public int ParentID {get; set;} //int(4) not null
        [Column(_OrderBy, CType.Int)]                                                         public int OrderBy {get; set;} //int(4) not null
        [Column(_Image_Index, CType.Int)]                                                     public int Image_Index {get; set;} //int(4) not null
        [Column(_Ty, CType.Int)]                                                              public int Ty {get; set;}     //int(4) not null
        [Column(_Label, CType.NVarChar, Length = 50)]                                         public string Label {get; set;} //nvarchar(50) not null
        [Column(_Description, CType.Text, Nullable = true)]                                   public string Description {get; set;} //text(16) null
        [Column(_Header_Footer, CType.NVarChar, Length = 512)]                                public string Header_Footer {get; set;} //nvarchar(512) not null
        [Column(_Data_Provider, CType.Int)]                                                   public int Data_Provider {get; set;} //int(4) not null
        [Column(_Sql_Command, CType.VarChar, Length = -1)]                                    public string Sql_Command {get; set;} //varchar(-1) not null
        [Column(_User_Layout, CType.NVarChar, Length = 4000)]                                 public string User_Layout {get; set;} //nvarchar(4000) not null
        [Column(_Setting_Script, CType.NText)]                                                public string Setting_Script {get; set;} //ntext(16) not null
        [Column(_Access_Level, CType.Int)]                                                    public int Access_Level {get; set;} //int(4) not null
        [Column(_Released, CType.Bit)]                                                        public bool Released {get; set;} //bit(1) not null
        [Column(_Controlled, CType.Bit)]                                                      public bool Controlled {get; set;} //bit(1) not null
        [Column(_Enabled, CType.Bit)]                                                         public bool Enabled {get; set;} //bit(1) not null
        [Column(_Visible, CType.Bit)]                                                         public bool Visible {get; set;} //bit(1) not null
        [Column(_ViewMode, CType.Int)]                                                        public int ViewMode {get; set;} //int(4) not null
        [Column(_Owner_ID, CType.Int)]                                                        public int Owner_ID {get; set;} //int(4) not null
        [Column(_Help, CType.NText, Nullable = true)]                                         public string Help {get; set;} //ntext(16) null

#pragma warning restore

        public CommandDpo()
        {
        }

        public CommandDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CommandDpo(int id)
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
              return new CommandDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _OrderBy = "OrderBy";
        public const string _Image_Index = "Image_Index";
        public const string _Ty = "Ty";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Header_Footer = "Header_Footer";
        public const string _Data_Provider = "Data_Provider";
        public const string _Sql_Command = "Sql_Command";
        public const string _User_Layout = "User_Layout";
        public const string _Setting_Script = "Setting_Script";
        public const string _Access_Level = "Access_Level";
        public const string _Released = "Released";
        public const string _Controlled = "Controlled";
        public const string _Enabled = "Enabled";
        public const string _Visible = "Visible";
        public const string _ViewMode = "ViewMode";
        public const string _Owner_ID = "Owner_ID";
        public const string _Help = "Help";

       
        #endregion 



    }
}

