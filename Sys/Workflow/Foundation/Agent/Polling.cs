using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sys.Workflow
{
    class Polling
    {
        private static Polling instance = null;
        private Dictionary<string, Agent> agents = new Dictionary<string, Agent>();
        private object theLock = new object();

        Timer timer;
        private Polling()
        {
            timer = new Timer(this.Job, null, Timeout.Infinite, Timeout.Infinite);
        }


        public static Polling Instance
        {
            get
            {
                if (instance == null)
                    instance = new Polling();

                return instance;
            }
        }

        public void AddAgent(string name, Agent agent)
        {
            lock (theLock)
            {
                if (agents.ContainsKey(name))
                    agents.Remove(name);

                agents.Add(name, agent);
            }

            if (agents.Count > 0)
                Start();
        }

        public void RemoveAgent(string name)
        {
            lock (theLock)
            {
                if (agents.ContainsKey(name))
                    agents.Remove(name);
            }

            if (agents.Count == 0)
                Stop();
        }


        public void Start()
        {
            timer.Change(0, 1000);
        }

        public void Stop()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }


        private int sec = 1;
        private void Job(object state)
        {
            lock (theLock)
            {
                foreach (Agent agent in agents.Values)
                {
                    if (sec % agent.Timeout != 0)
                        continue;

                    agent.Run();
                }

                //Garbage Collection
                string[] keys = new string[agents.Count];
                agents.Keys.CopyTo(keys, 0);
                foreach (string key in keys)
                {
                    Agent agent = agents[key];
                    if (!agent.Alive)
                        RemoveAgent(key);
                }
            }

            sec++;
            if (sec > 60 * 36000) sec = 0;
        }
    }
}
