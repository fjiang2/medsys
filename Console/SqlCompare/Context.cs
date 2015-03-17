﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tie;
using Sys.Data;

namespace SqlCompare
{
    static class Context
    {
        public const string MAXROWS = "maxrows";
        public const string DATAREADER = "DataReader";
        public const string THESIDE = "$TheSide";

        public static Memory DS = new Memory();

        static Context()
        {
            Script.FunctionChain.Add(functions);

            DS.Add(MAXROWS, new VAL(100));
            DS.Add(DATAREADER, new VAL(false));
        }

        public static void Execute(string statement)
        {
            Script.Execute(statement, DS);
        }

        public static VAL Evaluate(string expression)
        {
            return Script.Evaluate(expression, DS);
        }

        public static T GetValue<T>(VAR variable, T defaultValue = default(T))
        {
            VAL val = DS[variable];

            if (val.Defined && val.HostValue is T)
                return (T)val.HostValue;
            else
                return defaultValue;
        }

        public static void ToConsole()
        {
            ((VAL)DS)
                .Where(row => row[1].ty != VALTYPE.nullcon && row[1].ty != VALTYPE.voidcon && !row[0].Str.StartsWith("$"))
                .Select(row => new { Variable = (string)row[0], Value = row[1] })
                .ToConsole();
        }

        public static VAL binding
        {
            get
            {
                return DS["binding"];
            }
        }


        static VAL functions(string func, VAL parameters, Memory DS)
        {
            int size = parameters.Size;
            VAL L0 = size > 0 ? parameters[0] : null;
            VAL L1 = size > 1 ? parameters[1] : null;
            VAL L2 = size > 2 ? parameters[2] : null;


            switch (func)
            {
                //export("tablename", "where", "script.sql");
                //export("tablename", "script.sql");
                case "export":
                    {
                        string tableName = null;
                        string where = null;
                        string fileName = null;

                        if (size == 2 && L0.ty == VALTYPE.stringcon && L1.ty == VALTYPE.stringcon)
                        {
                            tableName = L0.Str;
                            fileName = L1.Str;
                        }
                        if (size == 3 && L0.ty == VALTYPE.stringcon && L2.ty == VALTYPE.stringcon)
                        {
                            tableName = L0.Str;
                            where = L1.Str;
                            fileName = L2.Str;
                        }

                        if (tableName != null && fileName != null)
                        {
                            Side theSide = (Side)DS[THESIDE].HostValue;
                            TableName tname = new TableName(theSide.DatabaseName, tableName);
                            using (var writer = new StreamWriter(fileName))
                            {
                                if (where != null)
                                {
                                    theSide.GenerateRows(writer, tname, where);
                                    stdio.WriteLine("insert clauses (SELECT * FROM {0} WHERE {1}) generated to {2}", tname, where, fileName);
                                }
                                else
                                {
                                    theSide.GenerateRows(writer, tname, null);
                                    stdio.WriteLine("insert clauses (SELECT * FROM {0}) generated to {1}", tname, fileName);
                                }
                            }

                            return new VAL();
                        }
                    }
                    break;

                default:
                    var query = DS[func];
                    if (query.ty == VALTYPE.stringcon)
                    {
                        VAL val = VAL.Array(0);
                        for (int i = 0; i < parameters.Size; i++)
                        {
                            VAL parameter = parameters[i];
                            string name = parameter.GetName();

                            if (name == null)
                            {
                                stdio.WriteLine("require parameter name at arguments({0}), run func(id=20,x=2);", i + 1);
                                return new VAL(2);
                            }
                            val.Add(name, parameter);
                        }

                        VAL result = VAL.Array(0);
                        result.Add(query);
                        result.Add(val);
                        return result;
                    }
                    break;
            }
            
            return null;

        }
    }
}