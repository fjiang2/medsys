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


namespace Sys.Workflow.DpoClass
{
    [Revision(14)]
    [Table("sys01303", Level.System)]    //Primary Keys = S1_Name + S2_Name + Workflow_Name;  Identity = ID;
    public class wfTransitionDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Workflow_Name, CType.NVarChar, Primary = true, Length = 50)]                 public string Workflow_Name {get; set;} //nvarchar(50) not null
        [Column(_S1_Name, CType.NVarChar, Primary = true, Length = 50)]                       public string S1_Name {get; set;} //nvarchar(50) not null
        [Column(_S2_Name, CType.NVarChar, Primary = true, Length = 50)]                       public string S2_Name {get; set;} //nvarchar(50) not null
        [Column(_Directional, CType.Bit)]                                                     public bool Directional {get; set;} //bit(1) not null
        [Column(_Expression, CType.NVarChar, Nullable = true, Length = 512)]                  public string Expression {get; set;} //nvarchar(512) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _S1_Name, _S2_Name, _Workflow_Name });
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

