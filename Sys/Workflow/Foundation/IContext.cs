using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Workflow
{
 
    public interface IContext
    {
        void UpdateWorkflowContext(VAL workflowContext, VAL activityContext);
    }
}
