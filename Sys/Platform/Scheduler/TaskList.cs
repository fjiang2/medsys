using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using Sys.Data;
using Sys.Platform.Dpo;
using System.Data;

namespace Sys.Platform.Scheduler
{


    public class TaskList : DPList<Task>
    {

        public TaskList()
        { 
        }

        public TaskList(SqlExpr where)
            : base(new TableReader<Task>(where))
        {
        }

    
     
   

      

    }
}
