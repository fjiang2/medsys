//
// Machine Generated Code
//   by devel at 7/13/2012 3:21:13 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace PTA.Dpo
{
    [Revision(2)]
    [Table("ptaStudents", Level.System, Pack = false)]    //Primary Keys = Student_ID;  Identity = Student_ID;
    public class ptaStudentDpo : DPObject
    {

#pragma warning disable

        [Column(_Student_ID, SqlDbType.Int, Identity = true, Primary = true)]                     public int Student_ID;        //int(4) not null
        [Column(_Person_ID, SqlDbType.Int)]                                                       public int Person_ID;         //int(4) not null
        [Column(_Address_ID, SqlDbType.Int)]                                                      public int Address_ID;        //int(4) not null
        [Column(_Phone_ID, SqlDbType.Int, Nullable = true)]                                       public int? Phone_ID;         //int(4) null
        [Column(_Grade, SqlDbType.VarChar, Length = 20)]                                          public string Grade;          //varchar(20) not null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Student_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Student_ID });
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
        public const string _Person_ID = "Person_ID";
        public const string _Address_ID = "Address_ID";
        public const string _Phone_ID = "Phone_ID";
        public const string _Grade = "Grade";

       
        #endregion 



    }
}

