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
    [Table("X12ElementTemplate", Level.System)]    //Primary Keys = RefDes;  Identity = ID;
    public class X12ElementTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_SegmentName, CType.VarChar, Length = 8)]                                     public string SegmentName {get; set;} //varchar(8) not null
        [Column(_RefDes, CType.VarChar, Primary = true, Length = 8)]                          public string RefDes {get; set;} //varchar(8) not null
        [Column(_DeNum, CType.VarChar, Length = 10)]                                          public string DeNum {get; set;} //varchar(10) not null
        [Column(_Description, CType.NVarChar, Length = 100)]                                  public string Description {get; set;} //nvarchar(100) not null
        [Column(_Condition, CType.Char, Length = 1)]                                          public string Condition {get; set;} //char(1) not null
        [Column(_RepeatValue, CType.Int)]                                                     public int RepeatValue {get; set;} //int(4) not null
        [Column(_DataType, CType.VarChar, Length = 10)]                                       public string DataType {get; set;} //varchar(10) not null
        [Column(_MinLength, CType.Int)]                                                       public int MinLength {get; set;} //int(4) not null
        [Column(_MaxLength, CType.Int)]                                                       public int MaxLength {get; set;} //int(4) not null
        [Column(_Script, CType.NText, Nullable = true)]                                       public string Script {get; set;} //ntext(16) null

#pragma warning restore

        public X12ElementTemplateDpo()
        {
        }

        public X12ElementTemplateDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12ElementTemplateDpo(string refdes)
        {
           this.RefDes = refdes; 

           this.Load();
           if(!this.Exists)
           {
              this.RefDes = refdes;     
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
                return new PrimaryKeys(new string[]{ _RefDes });
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
              return new X12ElementTemplateDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _SegmentName = "SegmentName";
        public const string _RefDes = "RefDes";
        public const string _DeNum = "DeNum";
        public const string _Description = "Description";
        public const string _Condition = "Condition";
        public const string _RepeatValue = "RepeatValue";
        public const string _DataType = "DataType";
        public const string _MinLength = "MinLength";
        public const string _MaxLength = "MaxLength";
        public const string _Script = "Script";

       
        #endregion 



    }
}

