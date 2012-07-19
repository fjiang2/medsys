using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using Sys.ViewManager.Forms;
using Sys.Platform.Scheduler;
using Sys.Data;
using Sys.Platform.DpoClass;

namespace Sys.Platform.Forms
{
    public partial class SchedulerForm : BaseForm
    {
        public SchedulerForm()
        {
            InitializeComponent();



         
        }

        public static void FillResources(SchedulerStorage storage, int count)
        {
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
            try
            {
                int cnt = count;
                for (int i = 1; i <= cnt; i++)
                {
                    Resource resource = storage.CreateResource(i);
                    resource.Caption = "xxx";
                    resources.Add(resource);
                }
            }
            finally
            {
                storage.EndUpdate();
            }
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            schedulerControl1.Start = DateTime.Today;

            AppointmentMappingInfo mappings = this.schedulerStorage1.Appointments.Mappings;
            mappings.Start = "xStartTime";
            mappings.End = "xEndTime";
            mappings.Subject = "xSubject";
            mappings.AllDay = "xAllDay";
            mappings.Description = "xDescription";
            mappings.Label = "xLabel";
            mappings.Location = "xLocation";
            mappings.RecurrenceInfo = "xRecurrenceInfo";
            mappings.ReminderInfo = "xReminderInfo";
           // mappings.ResourceId = "xResourceId";
            mappings.Status = "xStatus";
            mappings.Type = "xType";

            int count = schedulerStorage1.Resources.Count;
            //Resource resource = schedulerStorage1.Resources[0];

            TaskList eventList = new TaskList( new SqlExpr(Task._User_ID) == this.account.User_ID);

            schedulerStorage1.BeginUpdate();
            this.schedulerStorage1.Appointments.DataSource = eventList;
            schedulerStorage1.EndUpdate();
        }
    }
}
