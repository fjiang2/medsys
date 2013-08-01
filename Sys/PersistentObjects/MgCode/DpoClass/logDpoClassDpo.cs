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
    [Revision(6)]
    [Table("sys00305", Level.System, Pack = false)]    //Primary Keys = table_id + user_id;  Identity = class_id;
    public class logDpoClassDpo : DPObject
    {

#pragma warning disable

        [Column(_class_id, CType.Int, Identity = true)]                                       public int class_id {get; set;} //int(4) not null
        [Column(_table_id, CType.Int, Primary = true)]                                        public int table_id {get; set;} //int(4) not null
        [Column(_user_id, CType.Int, Primary = true)]                                         public int user_id {get; set;} //int(4) not null
        [Column(_path, CType.NVarChar, Length = 250)]                                         public string path {get; set;} //nvarchar(250) not null
        [Column(_name_space, CType.VarChar, Length = 150)]                                    public string name_space {get; set;} //varchar(150) not null
        [Column(_modifier, CType.Int)]                                                        public int modifier {get; set;} //int(4) not null
        [Column(_class_name, CType.VarChar, Length = 50)]                                     public string class_name {get; set;} //varchar(50) not null
        [Column(_table_level, CType.Int)]                                                     public int table_level {get; set;} //int(4) not null
        [Column(_packed, CType.Bit)]                                                          public bool packed {get; set;} //bit(1) not null
        [Column(_has_provider, CType.Bit)]                                                    public bool has_provider {get; set;} //bit(1) not null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _table_id, _user_id });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _class_id });
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
        public const string _has_provider = "has_provider";

       
        #endregion 



    }
}

