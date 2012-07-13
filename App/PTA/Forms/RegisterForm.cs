using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.DataManager.Dpo;
using Sys.DataManager;
using PTA.Dpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace PTA.Forms
{
    public partial class RegisterForm : BaseForm
    {
        BindDpo<PersonDpo> bdStudentDemography;
        BindDpo<PersonDpo> bdAdultDemography;

        BindDpo<appAddressDpo> bdAddress;
        BindDpo<appPhoneDpo> bdPhone;

        BindDpo<ptaAdultDpo> bdAdult;
        BindDpo<ptaStudentDpo> bdStudent;

        int adultId = 0;
        int studentId = 0;
        int addressId = 0;
        int phoneId = 0;

        public RegisterForm()
        {
            InitializeComponent();

            bdStudentDemography = new BindDpo<PersonDpo>();
            bdStudentDemography.Connect(this.txtStudent_FirstName, appPersonDpo._First_Name);
            bdStudentDemography.Connect(this.txtStudent_LastName, appPersonDpo._Last_Name);

            bdAdultDemography = new BindDpo<PersonDpo>();

            bdAddress = new BindDpo<appAddressDpo>();
            bdPhone = new BindDpo<appPhoneDpo>();

            bdStudent = new BindDpo<ptaStudentDpo>();
            //bdStudent.Connect(this.txtStudent_FirstName, );

            // Adult
            bdAdult = new BindDpo<ptaAdultDpo>();
            bdAdult.Connect(this.txtEmail, ptaAdultDpo._Email);
            bdAdult.Connect(this.txtProfession, ptaAdultDpo._Profession);
            bdAdult.Connect<RegisterForm, int>(this, (form, value) => form.adultId = value, form => form.adultId, ptaAdultDpo._Person_ID);
            bdAdult.Connect<RegisterForm, int>(this, (form, value) => form.studentId = value, form => form.studentId, ptaAdultDpo._Student_Id);
            bdAdult.Connect<RegisterForm, int>(this, (form, value) => form.addressId = value, form => form.addressId, ptaAdultDpo._Address_ID);
            bdAdult.Connect<RegisterForm, int>(this, (form, value) => form.phoneId = value, form => form.phoneId, ptaAdultDpo._Phone_ID);
            
            foreach (CheckedListBoxItem item in this.clAvailability.Items)
                bdAdult.Connect<CheckedListBoxItem, bool>(item, FillCheckedListBoxItem, CollectCheckedListBoxItem, (string)item.Value);

            foreach (CheckedListBoxItem item in this.clInterest.Items)
                bdAdult.Connect<CheckedListBoxItem, bool>(item, FillCheckedListBoxItem, CollectCheckedListBoxItem, (string)item.Value);

            bdAdult.Connect(this.txtOther, ptaAdultDpo._Other);
        }

        private static void FillCheckedListBoxItem(CheckedListBoxItem control,  bool value)
        {
            control.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
        }

        private bool CollectCheckedListBoxItem(CheckedListBoxItem control)
        {
            return control.CheckState == CheckState.Checked;
        }
    }
}
