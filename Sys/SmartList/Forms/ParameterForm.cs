using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;
using System.Reflection;
using Sys.ViewManager.Forms;
using Sys.Data;


namespace Sys.SmartList.Forms
{
    public partial class ParameterForm : BaseForm
    {
        public const string _Controls = "Controls";
        public const string _Parameters = "Parameters";
        public const string _Title = "Title";

        Memory memory = null;
        VAL controls = null;
        VAL parameters = null;
        DevExpress.XtraEditors.TimeEdit timeEdit = new DevExpress.XtraEditors.TimeEdit(); 

        Dictionary<Control, string> parameterControls = new Dictionary<Control, string>();

        public ParameterForm()
        {
            InitializeComponent();
        }

        private void ParameterForm_Load(object sender, EventArgs e)
        {
            Assembly assembly1 = typeof(ToolStripButton).Assembly;
            Assembly assembly2 = this.timeEdit.GetType().Assembly;


            HostType.Register(typeof(ComboBoxStyle),true);

            for (int i = 0; i < controls.Size; i++)
            {
                VAL Control = controls[i];

                string Class = Control["Class"].Str;
                VAL position = Control["Position"];

                Assembly assembly = this.GetType().Assembly;
                if(Class.StartsWith("DevExpress"))
                    assembly = assembly2;
                else if(Class.StartsWith("System.Windows"))
                    assembly = assembly1;

                Control control = (Control)Reflector.NewInstance(assembly, Class, new object[] { });

                VAL p = Control["Return"];
                if (p.Defined)
                    parameterControls.Add(control, p.Str);


                HostType.SetObjectProperties(control, Control); 

                if (position[0].Intcon > tableLayoutPanel1.RowCount)
                    tableLayoutPanel1.RowCount = position[0].Intcon;

                if (position[1].Intcon > tableLayoutPanel1.ColumnCount)
                    tableLayoutPanel1.ColumnCount = position[1].Intcon;

                this.tableLayoutPanel1.Controls.Add(control, position[1].Intcon, position[0].Intcon);
            
            }

        }

        private object SearchValue(string name)
        {
            foreach (KeyValuePair<Control, string> kvp in parameterControls)
            {
                if (name == kvp.Key.Name)
                {
                    string returnProperty = kvp.Value;

                    PropertyInfo propertyInfo = kvp.Key.GetType().GetProperty(returnProperty);
                    return propertyInfo.GetValue(kvp.Key, null);
                }
            }

            return null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            VAL v = new VAL();
            if (parameters.IsNull)
            {
                
                foreach (KeyValuePair<Control, string> kvp in parameterControls)
                {
                    string var = kvp.Key.Name;
                    string returnProperty = kvp.Value;
                    
                    PropertyInfo propertyInfo = kvp.Key.GetType().GetProperty(returnProperty);
                    object value = propertyInfo.GetValue(kvp.Key, null);
                    
                    v[var] = VAL.Boxing(value);
                    memory.Add(var, v[var]);
                }

            }
            else
            {
                for (int i = 0; i < parameters.Size; i++)
                {
                    string var = parameters[i].Str;
                    object value = SearchValue(var);

                    if (value != null)
                        v[var] = VAL.Boxing(value);
                    else
                        v[var] = Script.Evaluate(var, memory);

                    memory.Add(var, v[var]);    //for disply history input
                }
             
            }

            memory.Add(_Parameters, v);
            this.DialogResult = DialogResult.Yes; 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            memory.Remove(_Parameters);
            this.DialogResult = DialogResult.No;
            this.Close();
        }

   

        private void ParameterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        public override object MaintenanceEntry
        {
            set
            {

                object[] v = (object[])value;
                
                VAL setting = (VAL)v[0];
                memory = (Memory)v[1];

                controls = setting[_Controls];
                parameters = setting[_Parameters];

                VAL title = setting[_Title];
                if (title.Defined)
                    this.Text = title.Str;
                
            }
        }



        public static SQLCommand SetSqlParameters(SQLCommand cmd, Memory memory, Memory DS2)
        {

            VAL x = memory[_Parameters];
            if (x.Undefined)
                return cmd;

            for (int i = 0; i < x.Size; i++)
            {
                string parameterName = x[i][0].Str;
                object obj = x[i][1].value;
                cmd.AddParameter("@" + parameterName, obj);

                DS2.Add(parameterName, x[i][1]);
            }

            return cmd;
        }

    

    

  
 
    }
}