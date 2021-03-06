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


namespace PTA.DpoClass
{
    [Revision(12)]
    [Table("ptaStudents", Level.Application, Pack = false)]    //Primary Keys = Student_ID;  Identity = ;
    public class ptaStudentDpo : DPObject
    {

#pragma warning disable

        [Column(_Student_ID, CType.Int, Primary = true)]                                      public int Student_ID {get; set;} //int(4) not null
        [Column(_Address_ID, CType.Int, Nullable = true)]                                     public int? Address_ID {get; set;} //int(4) null
        [Column(_Phone_ID, CType.Int, Nullable = true)]                                       public int? Phone_ID {get; set;} //int(4) null
        [Column(_Grade, CType.VarChar, Length = 20)]                                          public string Grade {get; set;} //varchar(20) not null

#pragma warning restore

        public ptaStudentDpo()
        {
        }

        public ptaStudentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ptaStudentDpo(int student_id)
        {
           this.Student_ID = student_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Student_ID = student_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Student_ID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Student_ID });
            }
        }



        public override IIdentityKeys Identity
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
              return new ptaStudentDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Student_ID = "Student_ID";
        public const string _Address_ID = "Address_ID";
        public const string _Phone_ID = "Phone_ID";
        public const string _Grade = "Grade";

       
        #endregion 



    }
}

