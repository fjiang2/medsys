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
using Sys.Data.Manager;


namespace X12.Dpo
{
    [Revision(4)]
    [Table("X12SegmentInstance", Level.System)]    //Primary Keys = LoopName + Name + Sequence;  Identity = ID;
    public class X12SegmentInstanceDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_LoopName, SqlDbType.VarChar, Primary = true, Length = 8)]                        public string LoopName;       //varchar(8) not null
        [Column(_Name, SqlDbType.VarChar, Primary = true, Length = 10)]                           public string Name;           //varchar(10) not null
        [Column(_Sequence, SqlDbType.Int, Primary = true)]                                        public int Sequence;          //int(4) not null
        [Column(_Description, SqlDbType.VarChar, Length = 100)]                                   public string Description;    //varchar(100) not null
        [Column(_RepeatValue, SqlDbType.Int)]                                                     public int RepeatValue;       //int(4) not null
        [Column(_Required, SqlDbType.Bit)]                                                        public bool Required;         //bit(1) not null
        [Column(_Situational_Rule, SqlDbType.VarChar, Nullable = true, Length = 4000)]            public string Situational_Rule;//varchar(4000) null
        [Column(_TR3_Notes, SqlDbType.VarChar, Nullable = true, Length = 4000)]                   public string TR3_Notes;      //varchar(4000) null
        [Column(_TR3_Example, SqlDbType.VarChar, Nullable = true, Length = 1000)]                 public string TR3_Example;    //varchar(1000) null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null

#pragma warning restore

        public X12SegmentInstanceDpo()
        {
        }

        public X12SegmentInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12SegmentInstanceDpo(string loopname, string name, int sequence)
        {
           this.LoopName = loopname; this.Name = name; this.Sequence = sequence; 

           this.Load();
           if(!this.Exists)
           {
              this.LoopName = loopname; this.Name = name; this.Sequence = sequence;     
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
                return new PrimaryKeys(new string[]{ _LoopName, _Name, _Sequence });
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
              return new X12SegmentInstanceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _LoopName = "LoopName";
        public const string _Name = "Name";
        public const string _Sequence = "Sequence";
        public const string _Description = "Description";
        public const string _RepeatValue = "RepeatValue";
        public const string _Required = "Required";
        public const string _Situational_Rule = "Situational_Rule";
        public const string _TR3_Notes = "TR3_Notes";
        public const string _TR3_Example = "TR3_Example";
        public const string _Script = "Script";

       
        #endregion 



    }
}

