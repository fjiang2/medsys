using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sys.OS
{
    public class Callback 
    {
        public delegate void WorkDoneCallback(object result);
        public delegate void WorkDoingCallback(object middleResult);
        public delegate object DoWorkDelegate(object args);


        public event WorkDoneCallback WorkDone;
        public event WorkDoingCallback WorkDoing;
        public bool WorkCancelled = false;

        protected Control sender;

        public Callback(Control sender)
        {
            this.sender = sender;
        }


        public void StartWork()
        {
            DoWorkDelegate work = new DoWorkDelegate(DoWorkFunction);
            work.BeginInvoke(sender, new AsyncCallback(WorkDoneFunction), new object[] { work });
        }

        public void StartWork(DoWorkDelegate work)
        {
            work.BeginInvoke(sender, new AsyncCallback(WorkDoneFunction), new object[] { work });
        }

        protected void WorkDoingFunction(object middleResult)
        {
            if (WorkDoing != null)
            {
                if (!sender.IsDisposed)
                    sender.Invoke(WorkDoing, new object[] { middleResult });
            }
        }

        protected virtual object DoWorkFunction(object args)
        {
            try
            {
                object result = null;

                while (true)
                {
                    if (WorkCancelled)
                        break;

                    // doing something......
                    object middleResult = null;

                    WorkDoingFunction(middleResult);
                }


                return result;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {

            }
        }

        private void WorkDoneFunction(IAsyncResult ar)
        {
            object[] o = (object[])ar.AsyncState;
            DoWorkDelegate work = (DoWorkDelegate)o[0];

            object result = work.EndInvoke(ar);

            if (result == null)
                return;

            if (WorkDone != null)
            {
                if (!sender.IsDisposed)
                    sender.Invoke(WorkDone, new object[] { result});
            }

        }




        ///--------------------------------------------------------
        public void ExampleUsage(System.Windows.Forms.Form form)
        {
            Callback callback = new Callback(form);
            callback.WorkDoing += ExampleWorkDoing;
            callback.WorkDone += ExampleWorkDone;

            callback.StartWork(ExampleDoWork);
        }

        public object ExampleDoWork(object args)
        {
            //reference in CallBack.DoWorkFunction
            return null;
        }

        public void ExampleWorkDoing(object middleResult)
        {
        }

        public void ExampleWorkDone(object result)
        {
        }
    }
}
