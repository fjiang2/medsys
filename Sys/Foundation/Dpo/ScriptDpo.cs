//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:11 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Foundation.Dpo
{
    [Revision(10)]
    [Table("sys01102", Level.System)]    //Primary Keys = Module;  Identity = ;
    public class ScriptDpo : DPObject
    {

#pragma warning disable

        [Column(_Module, SqlDbType.VarChar, Primary = true, Length = 128)]                        public string Module;         //varchar(128) not null
        [Column(_Library, SqlDbType.NVarChar, Length = 50)]                                       public string Library;        //nvarchar(50) not null
        [Column(_Script, SqlDbType.NText)]                                                        public string Script;         //ntext(16) not null
        [Column(_Notes, SqlDbType.NVarChar, Nullable = true, Length = 256)]                       public string Notes;          //nvarchar(256) null
        [Column(_Released, SqlDbType.Bit)]                                                        public bool Released;         //bit(1) not null

#pragma warning restore

        public ScriptDpo()
        {
        }

        public ScriptDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ScriptDpo(string module)
        {
           this.Module = module; 

           this.Load();
           if(!this.Exists)
           {
              this.Module = module;     
           }
        }
        


        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Module });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        

        public static string TABLE_NAME
        { 
            get
            {
              return new ScriptDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Module = "Module";
        public const string _Library = "Library";
        public const string _Script = "Script";
        public const string _Notes = "Notes";
        public const string _Released = "Released";

       
        #endregion 



    }
}

