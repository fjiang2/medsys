using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;

namespace Sys.ViewManager.Forms
{
    public class TieScript
    {
        Tie.Script script;
        public delegate void ExecuteHandler(string src);
        public delegate VAL EvaluteHandler(string src);

        private string src;

        public TieScript()
        {
            script = new Script(Guid.NewGuid().ToString(), 1024 * 8, true);
        }

        public TieScript(string moduleName)
        {
            script = new Script(moduleName, 1024 * 8, true);
        }


        public string SourceCode
        {
            get { return src; }
        }

        public Memory DS
        {
            get { return script.DS; }
            set { script.DS = value; }
        }

        public void Dispose()
        {
            script.Dispose();
        }

        public void Execute(string src)
        {
            this.src = src;
            Execute(script.Execute);
        }

        public void ExecuteAndStop(string src, int stopLine)
        {
            script.DebugStart(src);
            script.DebugContinue(stopLine, BreakPoint);
        }

        private void BreakPoint(int breakpoint, int cursor, string info, Memory DS2)
        {
            string ret = TieEditor.Show(src, info, cursor);
        }

        public void VolatileExecute(string src)
        {
            this.src = src;
            Execute(script.VolatileExecute);
        }



        public VAL Evaluate(string src)
        {
            this.src = src;
            return Evalute(script.ResidentEvaluate);
        }

        public VAL VolatileEvaluate(string src)
        {
            this.src = src;
            return Evalute(script.VolatileEvaluate);
        }

        private void Execute(ExecuteHandler handler)
        {
#if DEBUG_SCRIPT
            handler(src);
#else
        L1:
            try
            {
                handler(src);
            }
            catch (PositionException e1)
            {
                string ret = TieEditor.Show(e1);
                if (ret != null)
                {
                    src = ret;
                    goto L1;
                }

            }
            catch (Exception e2)
            {
                string msg = Message(e2);
                string ret = TieEditor.Show(src, msg, 0);
                if (ret != null)
                {
                    src = ret;
                    goto L1;
                }

            }
#endif
        }

        private VAL Evalute(EvaluteHandler handler)
        {
        L1:

            try
            {
                return handler(src);
            }
            catch (PositionException e1)
            {
                string ret = TieEditor.Show(e1);
                if (ret != null)
                {
                    src = ret;
                    goto L1;
                }

            }
            catch (Exception e2)
            {
                string msg = Message(e2);
                string ret = TieEditor.Show(src, msg, 0);
                if (ret != null)
                {
                    src = ret;
                    goto L1;
                }

            }

            return new VAL();
        }

        public static string Message(Exception e)
        {
            string error = e.Message;
#if DEBUG
            Exception inner = e.InnerException;
            while (inner != null)
            {
                error += "\n\r -- ";
                error += inner.Message;
                inner = inner.InnerException;
            }


            ////Get a StackTrace object for the exception     
            //StackTrace st = new StackTrace(e, true);      

            ////Get the first stack frame     
            //StackFrame[] frames = st.GetFrames();
            //foreach(StackFrame frame in frames)
            //{
            //    string methodName = frame.GetMethod().Name;
            //    string fileName = frame.GetFileName();
            //    int line = frame.GetFileLineNumber();      
            //    int col = frame.GetFileColumnNumber(); 
            //    error += string.Format("\n\rmethod {0} at {1} line:{2} col:{3}", methodName, fileName, line, col);
            //}

            error += "\n\r";
            error += e.StackTrace;

#endif
            return error;
        }

    }


}
