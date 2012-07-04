using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.Foundation.Dpo;
using Tie;
using System.Reflection;


namespace Sys.Modules
{
    public class TieModule
    {
        public TieModule()
        {
        }

        public static void Load(Assembly assembly, Memory DS)
        {
            var dpo = new ScriptDpo(assembly.GetName().Name);
            string moduleName = dpo.Module;
            string code = dpo.Script;

            Script script = new Script(moduleName);
            script.DS = DS;

            script.Execute(code);

        }
    }
}
