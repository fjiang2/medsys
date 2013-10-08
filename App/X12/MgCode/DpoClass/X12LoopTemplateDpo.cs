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


namespace X12.DpoClass
{
    [Revision(7)]
    [Table("X12LoopTemplate", Level.System)]    //Primary Keys = Name;  Identity = ID;
    public class X12LoopTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, CType.Int)]                                                        public int ParentID {get; set;} //int(4) not null
        [Column(_Name, CType.VarChar, Primary = true, Length = 10)]                           public string Name {get; set;} //varchar(10) not null
        [Column(_Sequence, CType.Int)]                                                        public int Sequence {get; set;} //int(4) not null
        [Column(_Description, CType.NVarChar, Length = 100)]                                  public string Description {get; set;} //nvarchar(100) not null
        [Column(_MinRepeat, CType.Int)]                                                       public int MinRepeat {get; set;} //int(4) not null
        [Column(_MaxRepeat, CType.Int)]                                                       public int MaxRepeat {get; set;} //int(4) not null
        [Column(_Required, CType.Bit)]                                                        public bool Required {get; set;} //bit(1) not null
        [Column(_Script, CType.NText, Nullable = true)]                                       public string Script {get; set;} //ntext(16) null

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

