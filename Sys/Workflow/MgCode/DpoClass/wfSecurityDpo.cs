//Machine Generated Code by devel at 4/1/2012 6:24:01 PM
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Workflow.DpoClass
{
    public class wfSecurity : DPObject
    {

#pragma warning disable

        public int ID;		//int(4) not null
        public int ParentID;		//int(4) null
        public int OrderBy;		//int(4) null
        public string Label;		//nvarchar(50) null


#pragma warning restore

        public wfSecurity()
        {
        }

        public wfSecurity(DataRow dataRow)
            :base(dataRow)
        {
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
                return new PrimaryKeys(new string[]{ _ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[] { _ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return null;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _OrderBy = "OrderBy";
   
        #endregion 


    }
}

