﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tie;
using System.Reflection;
using Sys.Data;

namespace Sys
{
    public class Const
    {
       // public static string CONNECTION_STRING = "data source=localhost\\SQLSERVER2008;initial catalog=medsys;integrated security=SSPI;packet size=4096";
        public static string CONNECTION_STRING = "data source=localhost\\SQLEXPRESS;initial catalog=medsys;integrated security=SSPI;packet size=4096";

 
        public static string DB_DEFAULT = "";
        public static string DB_SYSTEM = DB_DEFAULT;
        public static string DB_SYSTEM_TABLE_PREFIX = "sys";
        public static int DB_SYSTEM_ID = 1;
        public static int DB_DEFAULT_ID = 2;

        public static int POLICY_DATAPOOL_MAXCOUNT      = 10;
        public static string COMPUTER_NAME = "";

        public static int Revision = 1;

       
    }

}