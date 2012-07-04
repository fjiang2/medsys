using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DevExpress.XtraNavBar;
using Sys.ViewManager.Forms;
using Sys.ViewManager.Modules;

namespace Sys.ViewManager.Manager
{
    class TaskItem : NavBarItem, IComparer<TaskItem>, IComparer  
    {
        TaskData task;

        public TaskItem(TaskData task)
        {
            this.task = task;

            FormClass dpo = new FormClass(task.FormClass);
            if (!dpo.Exists)
            {
                BaseForm form = task.NewFormInstance();
                this.Caption = task.caption == null ? form.Text : task.caption;
                this.LargeImage = this.SmallImage = form.IconImage;

                dpo.Form_Class = task.FormClass;
                dpo.Label = form.Text;
                dpo.IconImage = form.IconImage;
                dpo.Save();
            }
            else
            {
                this.Caption = task.caption == null ? dpo.Label : task.caption;
                this.LargeImage = this.SmallImage = dpo.IconImage;
            }

        }

        public int Compare(TaskItem x, TaskItem y)
        {
            return task.Compare(x.task, y.task);
        }

        int IComparer.Compare(object x, object y)
        {
            TaskItem t1;
            TaskItem t2;
            if (x is NavBarItemLink)
            {
                t1 = (TaskItem)(((NavBarItemLink)x).Item);
                t2 = (TaskItem)(((NavBarItemLink)y).Item);
            }
            else
            {
                t1 = (TaskItem)x;
                t2 = (TaskItem)y;
            }
            return Compare(t1, t2);
        }

    }
}
