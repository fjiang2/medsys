using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tie;

namespace SqlCompare
{
    static class Context
    {
        public const string MAXROWS = "maxrows";
        public const string DATAREADER = "DataReader";

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
                .Where(row => row[1].ty != VALTYPE.nullcon && row[1].ty != VALTYPE.voidcon)
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


        internal static VAL functions(string func, VAL parameters, Memory DS)
        {
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
            else
            {
                stdio.WriteLine("undefined function:{0}", func);
                return new VAL(1);
            }

        }
    }
}
