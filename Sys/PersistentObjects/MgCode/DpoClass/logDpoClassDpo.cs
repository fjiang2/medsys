//
// Machine Generated Code
//   by devel at 11/13/2012
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
    [Revision(2)]
    [Table("sys00305", Level.System, Pack = false)]    //Primary Keys = table_id + user_id;  Identity = class_id;
    public class logDpoClassDpo : DPObject
    {

#pragma warning disable

        [Column(_class_id, SqlDbType.Int, Identity = true)]                                       public int class_id;          //int(4) not null
        [Column(_table_id, SqlDbType.Int, Primary = true)]                                        public int table_id;          //int(4) not null
        [Column(_user_id, SqlDbType.Int, Primary = true)]                                         public int user_id;           //int(4) not null
        [Column(_path, SqlDbType.NVarChar, Length = 250)]                                         public string path;           //nvarchar(250) not null
        [Column(_name_space, SqlDbType.VarChar, Length = 150)]                                    public string name_space;     //varchar(150) not null
        [Column(_modifier, SqlDbType.Int)]                                                        public int modifier;          //int(4) not null
        [Column(_class_name, SqlDbType.VarChar, Length = 50)]                                     public string class_name;     //varchar(50) not null
        [Column(_table_level, SqlDbType.Int)]                                                     public int table_level;       //int(4) not null
        [Column(_packed, SqlDbType.Bit)]                                                          public bool packed;           //bit(1) not null

#pragma warning restore

        public logDpoClassDpo()
        {
        }

        public logDpoClassDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public logDpoClassDpo(int table_id, int user_id)
        {
           this.table_id = table_id; this.user_id = user_id; 

           this.Load();
           if(!this.Exists)
           {
              this.table_id = table_id; this.user_id = user_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.class_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _table_id, _user_id });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _class_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new logDpoClassDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _class_id = "class_id";
        public const string _table_id = "table_id";
        public const string _user_id = "user_id";
        public const string _path = "path";
        public const string _name_space = "name_space";
        public const string _modifier = "modifier";
        public const string _class_name = "class_name";
        public const string _table_level = "table_level";
        public const string _packed = "packed";

       
        #endregion 



    }
}

