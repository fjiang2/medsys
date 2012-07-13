using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Security;
using System.IO;
using Sys.SmartList.Dpo;
using Sys;

namespace Sys.SmartList
{

    public class Configuration : CommandDpo
    {

        public Configuration()
        {
        }

        public Configuration(DataRow dataRow)
            : base(dataRow)
        {
        }

        public SecurityLevel AccessLevel
        {
            get { return (SecurityLevel)this.Access_Level; }
            set { this.Access_Level = (int)value; }
        }


        internal DataViewMode DataViewMode
        {
            get { return (DataViewMode)this.ViewMode; }
            set { this.ViewMode = (int)value; }
        }

     

        

        public Configuration(TreeRowNode NodeSelected)
            : base(NodeSelected.DataRow)
        {
        
            TreeRowNode parentNode = (TreeRowNode)NodeSelected.Parent;
            while (string.IsNullOrEmpty(this.Sql_Command))
            {
                if (parentNode == null)
                    return;

                this.Sql_Command = parentNode.DataRow.IsNull<string>(_Sql_Command, "");
                this.Header_Footer = parentNode.DataRow.IsNull<string>(_Header_Footer, "");
                parentNode = (TreeRowNode)parentNode.Parent;
            }

            
        }

      


        public string[] GetStringHeader()
        {
            if (header.HostValue == null)
                return null;

            return (string[])header.HostValue;
        }

        private VAL header = new VAL();
        public VAL Header
        {
            get
            {
                return header;
            }
            set
            {
                VAL v = new VAL();
                if (Header_Footer != "")
                {
                    VAL properties = Tie.Script.Evaluate(Header_Footer, new Memory());
                    header = properties["Header"];
                    if (v.Defined)
                    {
                        for (int i = 0; i < header.Size; i++)
                        if (header[0].Str == "" && Label != header[1].Str)
                            header[0].Str = Label;
                    }
                }

                if (header.Undefined)
                    return;

                VAL x = value;
                if (x.IsNull)
                    return;

                for (int i = 0; i < x.Size; i++)
                {
                    string parameterName = x[i][0].Str;
                    object obj = x[i][1].value;
                    if (obj == null)
                        continue;

                    for (int j = 0; j < header.Size; j++)
                    {
                        header[j].value = header[j].Str.Replace("@" + parameterName, obj.ToString());
                    }

                }
                return;
            }
        }


        public RepxItem RepxItem
        {
            get
            {
                var list = new RepxItemList(this);
                if (list.Count > 0)
                    return list[0];
                else
                    return null;
            }
        }


    }
}
