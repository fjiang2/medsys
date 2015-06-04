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

namespace Sys.Data
{
    public class DatabaseName : IComparable<DatabaseName>, IComparable, IDataPath
    {
        private ServerName serverName;
        private string name;

        public DatabaseName(ServerName serverName, string databaseName)
        {
            this.serverName = serverName;
            this.name = databaseName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Path
        {
            get { return this.name; }
        }
        
        public ServerName ServerName
        {
            get { return this.serverName; }
        }

        public ConnectionProvider Provider
        {
            get { return this.serverName.Provider; }
        }

        public int CompareTo(object obj)
        {
            return CompareTo((DatabaseName)obj);
        }

        public int CompareTo(DatabaseName n)
        {
            if (this.serverName.CompareTo(n.serverName) == 0)
               return this.name.CompareTo(n.name);

            return this.serverName.CompareTo(n.serverName);
        }


        public override int GetHashCode()
        {
            return name.GetHashCode() + this.serverName.GetHashCode() * 324819;
        }

        public override bool Equals(object obj)
        {
            DatabaseName dname = (DatabaseName)obj;
            return this.name.Equals(dname.name) && this.serverName.Equals(dname.serverName);
        }


        public override string ToString()
        {
            return string.Format("{0}\\{1}", this.serverName, this.name);
        }
    }
}
