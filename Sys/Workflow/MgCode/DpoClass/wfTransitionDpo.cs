//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:47 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;
using Tie;

namespace Sys.Workflow.DpoClass
{
    [Revision(12)]
    [Table("sys01303", Level.System)]    //Primary Keys = S1_Name + S2_Name + Workflow_Name;  Identity = ID;
    public class wfTransitionDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             [NonValized] public int ID;                //int(4) not null
        [Column(_Workflow_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                 [NonValized] public string Workflow_Name;  //nvarchar(50) not null
        [Column(_S1_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                       public string S1_Name;        //nvarchar(50) not null
        [Column(_S2_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                       public string S2_Name;        //nvarchar(50) not null
        [Column(_Directional, SqlDbType.Bit)]                                                     public bool Directional;      //bit(1) not null
        [Column(_Expression, SqlDbType.NVarChar, Nullable = true, Length = 512)]                  [NonValized] public string Expression;     //nvarchar(512) null

#pragma warning restore

        public wfTransitionDpo()
        {
        }

        public wfTransitionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfTransitionDpo(string s1_name, string s2_name, string workflow_name)
        {
           this.S1_Name = s1_name; this.S2_Name = s2_name; this.Workflow_Name = workflow_name; 

           this.Load();
           if(!this.Exists)
           {
              this.S1_Name = s1_name; this.S2_Name = s2_name; this.Workflow_Name = workflow_name;     
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
                return new PrimaryKeys(new string[]{ _S1_Name, _S2_Name, _Workflow_Name });
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
              return new wfTransitionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Workflow_Name = "Workflow_Name";
        public const string _S1_Name = "S1_Name";
        public const string _S2_Name = "S2_Name";
        public const string _Directional = "Directional";
        public const string _Expression = "Expression";

       
        #endregion 



    }
}

