//
// Machine Packed Data
//   by devel at 5/9/2012 6:30:59 AM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.DataManager;
using Sys.Workflow.Dpo;

namespace Sys.Workflow.Package
{
	public class wfStateDpoPackage : BasePackage<wfStateDpo>
	{

		public wfStateDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new wfStateDpo();
			dpo.ID = 1;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S1";
			dpo.Index = 5;
			dpo.Label = "State 1";
			dpo.Description = "";
			dpo.Ty = 1;
			dpo.Offset = 0.0;
			dpo.Duration = 120.0;
			dpo.Metadata = @"function(workflowInstance, state, task, context)
{
    task.Summary = ""State 1"";
//    task.Category1 = context.SO;
//    task.Category2 = context.TaskCard;
}";
			dpo.Dependency = @"function(from, activity, context)
{ 
  if(activity.FromStartState())
     return true;

  return false;

}";
			dpo.Preaction = @"function(activity, context) //Customer Approval
{
	context.S10.Listener= {Account.CurrentUser};
}


";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 2;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S10";
			dpo.Index = 6;
			dpo.Label = "State 10";
			dpo.Description = "";
			dpo.Ty = 3;
			dpo.Offset = 432.0;
			dpo.Duration = 168.0;
			dpo.Dependency = @"function(from, activity, context)
{ 
   return from.IsCompletedState(""S8"") && conext.S7.Yes;
}
";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 3;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S2";
			dpo.Index = 1;
			dpo.Label = "State 2";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 120.0;
			dpo.Duration = 48.0;
			dpo.Dependency = @"function(from, activity, context)
{ 
   if(from.IsCompletedState(""S1""))
      return true;

   if(from.IsCompletedState(""S7""))
      return !context(""S7"").Yes;     

   return false;  

}
";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 4;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S3";
			dpo.Index = 4;
			dpo.Label = "State 3";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 144.0;
			dpo.Duration = 72.0;
			dpo.Dependency = "function(from, activity, context)\n{ \n   return from.IsCompletedState(\"S1\") ;\n}\n";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = @"function(form, activity, task)
{
  task.Category1 = activity.WorkflowInstance.Context.SO;
  task.Category2 = activity.WorkflowInstance.Context.TaskCard;


}
//function(form, activity) {   this.listen(base.S8,""base.S8.Context.Yes"");   return {}; }";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 5;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S4";
			dpo.Index = 9;
			dpo.Label = "State 4";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 120.0;
			dpo.Duration = 48.0;
			dpo.Dependency = "function(from, activity, context)\n{ \n   return from.IsCompletedState(\"S1\");\n}\n";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "//function(form, activity) {   Notify(\"IM\");   return {}; } ";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 6;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S5";
			dpo.Index = 3;
			dpo.Label = "State 5";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 264.0;
			dpo.Duration = 96.0;
			dpo.Dependency = @"function(from, activity, context)
{ 
   return from.IsCompletedState(""S2"") && from.IsCompletedState(""S3"");
}
";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.AfterAction = @"function(activity, context) 
{
  // activity.Monitor(new Aeroframe.Model.CustomerApprovalAgent(activity, 30));
}


";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 7;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S6";
			dpo.Index = 7;
			dpo.Label = "State 6";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 218.0;
			dpo.Duration = 80.0;
			dpo.Dependency = @"function(from, activity, context)
{ 
   return from.IsCompletedState(""S3"") || from.IsCompletedState(""S4"");
}
";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 8;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S7";
			dpo.Index = 2;
			dpo.Label = "State 7";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 408.0;
			dpo.Duration = 96.0;
			dpo.Dependency = @"function(from, activity, context)
{ 
   return from.IsCompletedState(""S5"") && from.IsCompletedState(""S9"");
}
";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = @"function(form, activity, task)
{
   var context = activity.WorkflowInstance.Context;
   context.S7.Yes = true;
//function(form, activity) {   return {Yes: form.Yes}; }
   
}";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 9;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S8";
			dpo.Index = 8;
			dpo.Label = "State 8";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 312.0;
			dpo.Duration = 96.0;
			dpo.Dependency = "function(from, activity, context)\n{ \n   return from.IsCompletedState(\"S6\");\n}\n";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

			dpo = new wfStateDpo();
			dpo.ID = 10;
			dpo.Workflow_Name = "W1";
			dpo.Name = "S9";
			dpo.Index = 0;
			dpo.Label = "State 9";
			dpo.Description = "";
			dpo.Ty = 2;
			dpo.Offset = 168.0;
			dpo.Duration = 24.0;
			dpo.Dependency = "function(from, activity, context)\n{ \n   return from.IsCompletedState(\"S2\");\n}\n";
			dpo.Preaction = "";
			dpo.Action = @"function(activity, context)
{
var form = new Afs.Workflow.Forms.ActivityForm(this.Name);    
form.Text=""(Task Triggered)"";    
return form;
}

";
			dpo.Postaction = "";
			dpo.Channel = 1;
			list.Add(dpo);

		}

	}
}
