using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class BindDpo<T> : BindRow where T : DPObject, new()
    {
        public event BindDpoHandler BeforeSaving;
        
        private T dpo;
        private FieldInfo[] columnNameFields;

        public BindDpo()
            : this(new T())
        { 
        }

        public BindDpo(T dpo)
            : base(dpo)
        {
            //retrieve all [public const string] fields
            this.columnNameFields = 
                typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .Where(fieldInfo => fieldInfo.FieldType == typeof(string)).ToArray();   

            this.dpo = dpo;
            
            if (!this.dpo.BeforeSavingHooked)
                this.dpo.BeforeSaving += Dpo_BeforeSaving;
        }


        /// <summary>
        /// Update/Copy BindDpo's value from new dpo
        /// </summary>
        /// <param name="dpo"></param>
        public void LoadDpo(T dpo)
        {
            this.dpo.CopyFrom(dpo);
        }

        public T Dpo
        {
            get
            {
                return this.dpo;
            }
            set
            {
                if (value == null)
                    return;

                //Type ty1 = this.dpo.GetType();
                //Type ty2 = value.GetType();

                //if ( ty1 != ty2 && !ty2.IsSubclassOf(ty1))
                //    throw new Sys.SysException("cannot assign {0} value to type of {1}", ty2.FullName, ty1.FullName);

                this.dpo = value;

                if (!this.dpo.BeforeSavingHooked)
                    this.dpo.BeforeSaving += Dpo_BeforeSaving;

            }
        }

        /// <summary>
        /// Clear WinControl fields and DPO
        /// </summary>
        public override void Clear()
        {
             base.Clear();       //clear DataRow and UI  
             dpo.Fill(base.dataRow); //clear DPO fields, notes: value of parimary key cannot be cleared???
        }


        /// <summary>
        ///  Use WinControl field update dataRow, and then update DPO 
        /// </summary>
        protected override void Collect()
        {
            base.Collect();
            dpo.Fill(base.dataRow);     //update DPO field from DataRow
        }

        
        /// <summary>
        /// Use DPO to dataRow, and then update WinControls fields
        /// </summary>
        public override void Fill()
        {
            dpo.Collect(base.dataRow);  //update DataRow from DPO fields
            base.Fill();    //Update UI
        }

        /// <summary>
        /// Collect locator data from UI fields and update dpo, and then load dpo from database
        /// </summary>
        /// <returns></returns>
        public override bool Load()
        {
            Apply();                    //apply controls' values to WHERE of query    
            dpo.Load();                 //load data row based on WHERE
            if (dpo.Exists)
                Fill();                 //show UI
            return dpo.Exists;
        }

     

        #region Save Dpo

        /// <summary>
        /// Save all columns' value of record, it may overwrite some columns' value during multiple users environment.
        /// Use Save() instead, if Locator columns connected
        /// </summary>
        /// <returns></returns>
        public void SaveDpo()
        {
            Apply();
            dpo.Save();
            
            if(dpo.Identity.Length > 0)
                Reset();
        }

        /// <summary>
        /// Save Dpo with update confirmation dialog pop up
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool ConfirmAndSave(string title)
        {
            confirmWindowOn = true;

            this.title = title;
            SaveDpo();

            confirmWindowOn = false;
            return saved;
        }
        
        public bool ConfirmAndSave()
        {
            return ConfirmAndSave(null);
        }

        private bool confirmWindowOn = false;
        private bool saved = true;
        private string title;

        private void default_BeforeSaving(object sender, BindDpoEventArgs e)
        {
            saved = true;

            //don't pop up ConfirmWindow
            if (!confirmWindowOn)
                return;

            if (e.mode == SaveMode.Update)
            {
                if (title == null)
                    title = string.Format("A record of {0}", dpo.TableName);

                if (MessageBox.Show(
                    string.Format("{0} is going to be overwritten, continue?", title),
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    //default allow to overwrite
                    e.confirmed = false;
                    saved = false;
                }
                else
                    saved = true;
            }
        }


    
        protected void Dpo_BeforeSaving(object sender, RowChangedEventArgs e)
        {
            BindDpoEventArgs args;
            if (e.state == ObjectState.Modified)
            {
                args = new BindDpoEventArgs(SaveMode.Update);
                
                if (BeforeSaving != null)
                    BeforeSaving(this, args);
                else
                    this.default_BeforeSaving(this, args);

                e.confirmed = args.confirmed;
            }

            else if (e.state == ObjectState.Added)
            {
                if (!e.saved)  //before adding
                {
                    args = new BindDpoEventArgs(SaveMode.Insert);

                    if (BeforeSaving != null)
                        BeforeSaving(this, args);
                    else
                        this.default_BeforeSaving(this, args);

                    e.confirmed = args.confirmed;
                }
                else   //after saved, update identity window controls
                {
                }
            }

       }

        #endregion


        /// <summary>
        /// Some DPObject may not be defined Primary and Identity to ColumnFields
        /// </summary>
        protected override void UpdatePrimaryIdentity()
        {
            fields.UpdatePrimaryIdentity(dpo.Primary, dpo.Identity);
        }


        protected override BindRow Bind(JWinControl control, string columnName)
        {
            //Check it is valid column name?
            if (this.columnNameFields.Where(fieldInfo => fieldInfo.GetValue(null).Equals(columnName)).Count() != 1)
                throw new JException("Invalid column name [{0}] in {1}", columnName, typeof(T).FullName);
         
            return base.Bind(control, columnName);
        }

        protected override DataField AddField(string columnName)
        {
            ColumnAttribute[] attr = dpo.GetAttributes<ColumnAttribute>();
            if (attr.Length > 0)
                return fields.Add(attr[0].ColumnName, attr[0].DbType);
            else
                return base.AddField(columnName);
        }


        public override string ToString()
        {
            return string.Format("{0}({1},{2})", GetType().Name, dpo.GetType().FullName, dpo);
        }
    }
}
