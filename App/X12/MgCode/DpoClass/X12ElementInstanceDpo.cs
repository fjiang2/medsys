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
    [Table("X12ElementInstance", Level.System)]    //Primary Keys = ElementTemplate_ID + SegmentInstance_ID;  Identity = ID;
    public class X12ElementInstanceDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_ElementTemplate_ID, CType.Int, Primary = true)]                              public int ElementTemplate_ID {get; set;} //int(4) not null
        [Column(_SegmentInstance_ID, CType.Int, Primary = true)]                              public int SegmentInstance_ID {get; set;} //int(4) not null
        [Column(_Usage, CType.Int)]                                                           public int Usage {get; set;}  //int(4) not null
        [Column(_Description, CType.VarChar, Nullable = true, Length = 4000)]                 public string Description {get; set;} //varchar(4000) null
        [Column(_Situational_Rule, CType.VarChar, Nullable = true, Length = 4000)]            public string Situational_Rule {get; set;} //varchar(4000) null
        [Column(_Code_Definition, CType.Int)]                                                 public int Code_Definition {get; set;} //int(4) not null
        [Column(_Script, CType.NText, Nullable = true)]                                       public string Script {get; set;} //ntext(16) null

#pragma warning restore

        public X12ElementInstanceDpo()
        {
        }

        public X12ElementInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12ElementInstanceDpo(int elementtemplate_id, int segmentinstance_id)
        {
           this.ElementTemplate_ID = elementtemplate_id; this.SegmentInstance_ID = segmentinstance_id; 

           this.Load();
           if(!this.Exists)
           {
              this.ElementTemplate_ID = elementtemplate_id; this.SegmentInstance_ID = segmentinstance_id;     
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
                return new PrimaryKeys(new string[]{ _ElementTemplate_ID, _SegmentInstance_ID });
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
              return new X12ElementInstanceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ElementTemplate_ID = "ElementTemplate_ID";
        public const string _SegmentInstance_ID = "SegmentInstance_ID";
        public const string _Usage = "Usage";
        public const string _Description = "Description";
        public const string _Situational_Rule = "Situational_Rule";
        public const string _Code_Definition = "Code_Definition";
        public const string _Script = "Script";

       
        #endregion 



    }
}

