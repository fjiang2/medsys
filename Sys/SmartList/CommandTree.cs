using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;

namespace Sys.SmartList
{
    class CommandTree
    {


        public static ImageList ImageList
        {
            get
            {
                ImageList list = new ImageList();
                list.Images.Add(global::Sys.SmartList.Properties.Resources.folder);
                list.Images.Add(global::Sys.SmartList.Properties.Resources.application_view_list);
                list.Images.Add(global::Sys.SmartList.Properties.Resources.report);
                //list.Images.Add(global::Sys.SmartList.Properties.Resources.application_form_edit);
                list.Images.Add(TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE, global::Sys.SmartList.Properties.Resources.BreakpointHS);

                return list;
            }
        }

        public static string[] Items
        {
            get
            {
                return new string[] { "Folder", "Item", "Report" };
            }
        }
      
    }
}
