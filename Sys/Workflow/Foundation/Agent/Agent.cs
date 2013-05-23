using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Workflow
{
    public class Agent 
    {
        public delegate void AgentFinshied(Agent agent);

        /// <summary>
        /// time out in seconds
        /// </summary>
        private int timeout = 60; //1 minutes

        /// <summary>
        /// thread is alive, work not finshed yet
        /// </summary>
        private bool alive = true;

        /// <summary>
        /// thread is doing work, do not the same work again
        /// </summary>
        private bool doing = false;

        protected Agent(CollaborativeActivity activity, int timeout)
        {
            this.activity = activity;
            this.timeout = timeout;
        }

        /// <summary>
        /// timeout in seconds
        /// </summary>
        public int Timeout
        {
            get
            {
                return this.timeout;
            }
        }

        /// <summary>
        ///  thread is alive, work not finshed yet
        /// </summary>
        public bool Alive
        {
            get
            {
                return this.alive;
            }
        }

       /// <summary>
        /// return true if Job is done
       /// </summary>
       /// <returns></returns>
        public virtual bool DoJob()
        {
            return true;
        }

        public void Run()
        {
          if (alive && !doing)
          {
              doing = true;
              alive = ! DoJob();
                
              if(!alive)
                Finished(this);

             doing = false;
          }
        }

        public void Dispose()
        {
            if (activity == null)
                return;

            if (activity.Form == null)
                return;

            if (activity.Form.IsDisposed)
                return;

            activity.Form.Close();
        }

        /// <summary>
        /// callback when thread is finished.
        /// </summary>
        public AgentFinshied Finished;
        protected CollaborativeActivity activity;
      
    }
}
