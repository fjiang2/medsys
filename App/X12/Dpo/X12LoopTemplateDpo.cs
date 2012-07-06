//
// Machine Generated Code
//   by devel at 6/22/2012 2:14:34 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace X12.Dpo
{
    [Revision(4)]
    [Table("medsys..X12LoopTemplate")]    //Primary Keys = Name;  Identity = ID;
    public class X12LoopTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_ParentID, SqlDbType.Int)]                                                        public int ParentID;          //int(4) not null
        [Column(_Name, SqlDbType.VarChar, Primary = true, Length = 10)]                           public string Name;           //varchar(10) not null
        [Column(_Sequence, SqlDbType.Int)]                                                        public int Sequence;          //int(4) not null
        [Column(_Description, SqlDbType.NVarChar, Length = 100)]                                  public string Description;    //nvarchar(100) not null
        [Column(_MinRepeat, SqlDbType.Int)]                                                       public int MinRepeat;         //int(4) not null
        [Column(_MaxRepeat, SqlDbType.Int)]                                                       public int MaxRepeat;         //int(4) not null
        [Column(_Required, SqlDbType.Bit)]                                                        public bool Required;         //bit(1) not null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null

#pragma warning restore

        public X12LoopTemplateDpo()
        {
        }

        public X12LoopTemplateDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12LoopTemplateDpo(string name)
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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Name });
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
              return new X12LoopTemplateDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _Name = "Name";
        public const string _Sequence = "Sequence";
        public const string _Description = "Description";
        public const string _MinRepeat = "MinRepeat";
        public const string _MaxRepeat = "MaxRepeat";
        public const string _Required = "Required";
        public const string _Script = "Script";

       
        #endregion 



    }
}

