using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;
using DevExpress.XtraEditors;
using Tie;
using Sys.ViewManager.DevEx;

namespace Sys.ViewManager.Forms
{
    public class BindRow : RowAdapter
    {

        public BindRow(PersistentObject dpo)
            :this(dpo, dpo.Locator)
        {
        }

        public BindRow(PersistentObject dpo, Locator locator)
            : this(dpo.TableName, locator, dpo.NewRow)
        {
        }

        public BindRow(TableName from, Locator locator, DataRow dataRow)
            : base(from, locator, dataRow)
        {
        }

        /// <summary>
        /// Load rest of data from database, based on partial data in the wincontrol fields
        /// </summary>
        /// <returns></returns>
        public override bool Load()
        {
            Apply();                    //apply controls' values to WHERE of query    
            bool found = base.Load();   //load data row based on WHERE
            if (found)
                Fill();            //show UI
            return found;
        }


        protected virtual void UpdatePrimaryIdentity()
        {
            this.fields.UpdatePrimaryIdentity(this.TableName);
        }

        /// <summary>
        /// 1.Save all connected columns' value, it saves only column connected to UI. 
        /// 2.Update DataRow.
        /// 3.Make sure Locator columns must be connected to UI.
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            Apply();
            UpdatePrimaryIdentity();
            return base.Save();
        }

        /// <summary>
        /// Delete a record based on wincontrols fields
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            Apply();
            return base.Delete();
        }


        /// <summary>
        /// Clear all wincontrol fields
        /// </summary>
        public override void Clear()
        {
            try
            {
                base.Clear();
            }
            catch (Exception)
            {

            }
            Fill();
        }


        /// <summary>
        ///  Use WinControl value to update DataRow, just like Button [Apply] clicked 
        /// </summary>
        public virtual void Apply()
        {
            Collect();
        }

        /// <summary>
        /// Use DataRow to update WinControl fields, just like butoon [Reset] clicked
        /// </summary>
        public void Reset()
        {
            Fill();
        }


        protected virtual BindRow Bind(JWinControl control, string columnName)
        {
            base.Bind(control);
            return this;
        }

        protected virtual DataField AddField(string columnName)
        {
            return fields.Add(this.dataRow.Table.Columns[columnName]);
        }
    
        //------------------------------------------------------------------------------------------------

        public BindRow Bind(RichTextBox textBox, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JRichTextBox(textBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(TextBoxBase textBox, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JTextBox(textBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(CheckBox checkBox, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JCheckBox(checkBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(CheckEdit checkBox, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JCheckEdit(checkBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(RadioButton radioButton, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JRadioButton(radioButton, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(System.Windows.Forms.ComboBox comboBox, string columnName)
        {
            DataField field = AddField(columnName);
            JComboBox control = new JComboBox(comboBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(System.Windows.Forms.ComboBox comboBox, string columnName, DataTable dataTable)
        {
            DataField field = AddField(columnName);
            JComboBox control = new JComboBox(comboBox, field, dataTable);
            return Bind(control, columnName);
        }

        public BindRow Bind(System.Windows.Forms.ComboBox comboBox, string columnName, DataTable dataTable, string displayMember, string valueMember)
        {
            DataField field = AddField(columnName);
            JComboBox control = new JComboBox(comboBox, field, dataTable, displayMember, valueMember);
            return Bind(control, columnName);
        }

        public BindRow Bind(DevExpress.XtraEditors.DateEdit dateEdit, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JDateEdit(dateEdit, field);
            return Bind(control, columnName);

        }

        public BindRow Bind(DevExpress.XtraEditors.SpinEdit spinEdit, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JSpinEdit(spinEdit, field);
            return Bind(control, columnName);

        }

        public BindRow Bind(DevExpress.XtraEditors.TimeEdit timeEdit, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JTimeEdit(timeEdit, field);
            return Bind(control, columnName);

        }

        public BindRow Bind(DevExpress.XtraEditors.LookUpEdit lookUpEdit, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JLookUpEdit(lookUpEdit, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(DevExpress.XtraEditors.ImageComboBoxEdit combo, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JImageComboBoxEdit(combo, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(DevExpress.XtraEditors.LookUpEdit lookUpEdit, string columnName, TableReader tableReader)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JLookUpEdit(lookUpEdit, field, tableReader);
            return Bind(control, columnName);
        }

        public BindRow Bind(DateTimePicker dateTimePicker, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JDateTimePicker(dateTimePicker, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(DevExpress.XtraEditors.RadioGroup radioGroup, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JRadioGroup(radioGroup, field);
            return Bind(control, columnName);
        }

        public BindRow Bind<T>(DevExpress.XtraEditors.RadioGroup radioGroup, string columnName) where T: struct
        {
            radioGroup.LoadEnum<T>();
            return Bind(radioGroup, columnName);
        }

        public BindRow Bind(PictureBox pictureBox, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JPictureBox(pictureBox, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(DomainUpDown domainUpDown, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JDomainUpDown(domainUpDown, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(MemoExEdit edit, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JMemoExEdit(edit, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(Label label, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JLabel(label, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(Control control, string property, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl x = new JControl(control, property, field);
            return Bind(x, columnName);
        }


        /// <summary>
        /// fill Property of Windows Control by function fill(columnValue), collect column value from Windows Control by function collect(propertyValue)
        /// </summary>
        /// <typeparam name="TColumnValue">type of Table's column</typeparam>
        /// <typeparam name="TControlValue">type of Control's Property bound</typeparam>
        /// <param name="control"></param>
        /// <param name="property">Windows Control's Property name</param>
        /// <param name="fill">convert column value from database into value Windows Control needed</param>
        /// <param name="collect">convert value from Windows Control into value saved in the database</param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public BindRow Bind<TColumnValue, TControlValue>(Control control, string property, 
            Func<TColumnValue, TControlValue> fill, Func<TControlValue, TColumnValue> collect, 
            string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl x = new JControl<TColumnValue, TControlValue>(control, property, fill, collect, field);
            return Bind(x, columnName);
        }

        /// <summary>
        /// Generic Control binding, user defined methods void Fill(control, value); and type Collect(control);
        /// </summary>
        /// <typeparam name="TControl">Windows Control Type</typeparam>
        /// <typeparam name="TColumn">Column Value Type</typeparam>
        /// <param name="control">control bound</param>
        /// <param name="fill">action of fill value into control</param>
        /// <param name="collect">function of collect value</param>
        /// <param name="columnName">Column name</param>
        /// <returns></returns>
        public BindRow Bind<TControl, TColumn>(TControl control, Action<TControl, TColumn> fill, Func<TControl, TColumn> collect, string columnName) 
        {
            DataField field = AddField(columnName);
            JWinControl x = new JGenericControl<TControl, TColumn>(control, fill, collect, field);
            return Bind(x, columnName);
        }


        public BindRow Bind(VAL val, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JVal(val, field);
            return Bind(control, columnName);
        }

        public BindRow Bind(object obj, string columnName)
        {
            DataField field = AddField(columnName);
            JWinControl control = new JHostObject(obj, field);
            return Bind(control, columnName);
        }

     
    }
}

