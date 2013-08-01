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


namespace Sys.PersistentObjects.DpoClass
{
    [Revision(13)]
    [Table("sys00203", Level.System, Pack = false)]    //Primary Keys = name + table_id;  Identity = column_id;
    internal class dictDataColumnDpo : DPObject
    {

#pragma warning disable

        [Column(_column_id, CType.Int, Identity = true)]                                      public int column_id {get; set;} //int(4) not null
        [Column(_table_id, CType.Int, Primary = true)]                                        public int table_id {get; set;} //int(4) not null
        [Column(_name, CType.VarChar, Primary = true, Length = 50)]                           public string name {get; set;} //varchar(50) not null
        [Column(_label, CType.NVarChar, Nullable = true, Length = 50)]                        public string label {get; set;} //nvarchar(50) null
        [Column(_description, CType.NVarChar, Nullable = true, Length = 128)]                 public string description {get; set;} //nvarchar(128) null
        [Column(_version, CType.Int)]                                                         public int version {get; set;} //int(4) not null

#pragma warning restore

        public dictDataColumnDpo()
        {
        }

        public dictDataColumnDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public dictDataColumnDpo(string name, int table_id)
        {
           this.name = name; this.table_id = table_id; 

           this.Load();
           if(!this.Exists)
           {
              this.name = name; this.table_id = table_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.column_id;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _name, _table_id });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _column_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new dictDataColumnDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _column_id = "column_id";
        public const string _table_id = "table_id";
        public const string _name = "name";
        public const string _label = "label";
        public const string _description = "description";
        public const string _version = "version";

       
        #endregion 



    }
}

