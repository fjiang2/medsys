//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.Data.Manager
{
    public sealed class ClassTableName : TableName
    {
        private Level level = Level.Fixed;
        private bool pack = true;
        private bool hasProvider = true;

        public ClassTableName(DataProvider provider, string databaseName, string tableName)
            : base(provider, databaseName, tableName)
        {

        }


        public Level Level
        {
            get { return this.level; }
        }

        public bool Pack
        {
            get { return this.pack; }
        }

        public bool HasProvider
        {
            get { return this.hasProvider; }
        }

        public void SetProperties(Level level, bool pack, bool hasProvider)
        {
            this.level = level;
            this.pack = pack;
            this.hasProvider = hasProvider;
        }

      

        public string SubNamespace
        {
            get { return ident.Identifier(this.DatabaseName.Name); }
        }


        public string ClassName
        {
            get { return toClassName(this.tableName); }
        }


        private static string toClassName(string tableName)
        {
            string className = ident.Identifier(tableName);

            //remove plural
            if (className.EndsWith("s"))
                className = className.Substring(0, className.Length - 1);

            //Add "Dpo"
            className += Setting.DPO_CLASS_SUFFIX_CLASS_NAME;

            return className;

        }
    }
}
