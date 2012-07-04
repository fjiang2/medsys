using System;
using System.IO;
using Microsoft.CSharp; 
using System.CodeDom.Compiler;
using System.Reflection;

namespace Sys
{
  public class Compiler
  {
      string script;
      
      CompilerParameters compilerParameters;

      public Compiler(string script)
      {
          this.script = script;

          this.compilerParameters = new CompilerParameters();
          AddReference("System.dll");
          AddReference("System.Data.dll");
      }
      

      public void AddReference(string assemblyName)
      {
          compilerParameters.ReferencedAssemblies.Add(assemblyName);
      }


      public Assembly Compile(string assemblyName, string logFile)
      {
          CSharpCodeProvider csc = new CSharpCodeProvider();
            
          compilerParameters.OutputAssembly = assemblyName;
          compilerParameters.GenerateExecutable = false;

          CompilerResults compilerResults = csc.CompileAssemblyFromSource(compilerParameters, script);
          string message = "";
          foreach (CompilerError compilerError in compilerResults.Errors)
          {
              message = message +
                          "Line number " + compilerError.Line +
                          ", Error Number: " + compilerError.ErrorNumber +
                          ", " + compilerError.ErrorText + ";\n\n";

          }

          if (logFile != "")
          {

              StreamWriter sw = System.IO.File.CreateText(logFile);
              sw.WriteLine(script);
              sw.WriteLine(message);
              sw.Close();
          }

          if (compilerResults.Errors.Count != 0)
          {
              throw new ApplicationException(message);
          }

          Assembly assembly = Assembly.LoadFrom(assemblyName);
          return assembly;
      }

     
  }
}
 
