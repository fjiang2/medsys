//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:50 AM
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
    [Revision(5)]
    [Table("X12ElementTemplate", Level.System)]    //Primary Keys = RefDes;  Identity = ID;
    public class X12ElementTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_SegmentName, SqlDbType.VarChar, Length = 8)]                                     public string SegmentName;    //varchar(8) not null
        [Column(_RefDes, SqlDbType.VarChar, Primary = true, Length = 8)]                          public string RefDes;         //varchar(8) not null
        [Column(_DeNum, SqlDbType.VarChar, Length = 10)]                                          public string DeNum;          //varchar(10) not null
        [Column(_Description, SqlDbType.NVarChar, Length = 100)]                                  public string Description;    //nvarchar(100) not null
        [Column(_Condition, SqlDbType.Char, Length = 1)]                                          public string Condition;      //char(1) not null
        [Column(_RepeatValue, SqlDbType.Int)]                                                     public int RepeatValue;       //int(4) not null
        [Column(_DataType, SqlDbType.VarChar, Length = 10)]                                       public string DataType;       //varchar(10) not null
        [Column(_MinLength, SqlDbType.Int)]                                                       public int MinLength;         //int(4) not null
        [Column(_MaxLength, SqlDbType.Int)]                                                       public int MaxLength;         //int(4) not null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _RefDes });
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

