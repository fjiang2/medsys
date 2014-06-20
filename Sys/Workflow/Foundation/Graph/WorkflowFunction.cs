using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using Sys.Security;
using Sys.Xmpp;

namespace Sys.Workflow
{

    class WorkflowFunction : IUserDefinedFunction
    {
        public WorkflowFunction()
        { }

        public VAL Function(string func, VAL parameters, Memory DS)
        {
            int size = parameters.Size;

            VAL L0 = size == 1 ? parameters[0] : null;
            VAL L1 = size == 2 ? parameters[1] : null;
            VAL L2 = size == 2 ? parameters[1] : null;
            CollaborativeActivity activity;

            VAL V1, V2, V3;
            switch (func)
            {

                    /***
                     * 1.activity.from() --> 1st prev activity
                     * 2.activity.from(stateName) --> activity
                     * 
                     * 
                     * 
                     * */
                case "from":
                    if (size == 0 || !(L0.value is CollaborativeActivity))
                        break;

                    activity = (CollaborativeActivity)(L0.value);
                    if (size == 1)
                    {
                        return VAL.Boxing(activity.PrevActivities[0]);
                    }
                    else if (size == 2)
                    {
                        if (L1.value is string)     //stateName
                        {
                            if (activity.Data.PS > L1)
                                return VAL.NewHostType(activity.WorkflowInstance.Activities[L1.Str]);
                            else
                                return new VAL();
                        }
                    }
                    break;

                case "statusof":
                    activity = (CollaborativeActivity)(L0.value);
                    if (size == 1)
                    {
                        return VAL.Boxing(activity.Data.ActivityResult);
                    }
                    else if (size == 2)
                    {
                        if (L1.value is TaskStatus)
                        {
                            if (activity.Data.TaskStatus == (TaskStatus)(L1.value))
                                return VAL.Boxing(activity);
                            else
                                return new VAL();
                        }
                        else if (L1.value is ActivityResult)
                        {
                            if (activity.Data.ActivityResult == (ActivityResult)(L1.value))
                                return VAL.Boxing(activity);
                            else
                                return new VAL();
                        }
                        else       // context
                        {
                        
                        }
                    }
                    break;

              

                case "to" :
                    if (size == 2)
                    {
                        if (parameters[0].IsNull)
                            return new VAL(false);      //use for building transitions

                        V1 = L0["NS"];
                        V2 = L1["Name"];
                        return new VAL(V1 > V2);
                    }
                    break;

                case "sibling":
                    if (size == 2)
                    {

                    }
                    break;

                case "listen":   //state1.listen(state2, event); 
                    if (size == 3)
                    {
                        V1 =L0["Name"];
                        Xmpp.UserProtocol user = new Xmpp.UserProtocol(Account.CurrentUser); 
                        
                        V2 = L1;
                        if (V2["Listeners"].Undefined)
                            V2["Listeners"] = VAL.Array();

                        V3 = new VAL();
                        V3["User"] = user.GetVAL();
                        V3["State"] = V1;
                        V3["Event"] = parameters[2];

                        V2.Add(V3);

                        return parameters[0];
                    }
                    break;


            }

            return null;
        }

    }
}
