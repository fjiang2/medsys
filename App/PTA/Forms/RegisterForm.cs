using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using App.Data.Dpo;
using App.Data;
using PTA.Dpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Sys.BusinessRules;

namespace PTA.Forms
{
    public partial class RegisterForm : BaseForm
    {
        BindDpo<PersonDpo> bdStudentDemography;
        BindDpo<PersonDpo> bdAdultDemography;

        BindDpo<AddressDpo> bdAddress;
        BindDpo<PhoneDpo> bdPhone;

        BindDpo<ptaAdultDpo> bdAdult;
        BindDpo<ptaStudentDpo> bdStudent;

        int adultId = 0;
        int studentId = 0;
        int addressId = 0;
        int phoneId = 0;

        AdultDpo adult = new AdultDpo();
        StudentDpo student = new StudentDpo();

        public RegisterForm()
        {
            InitializeComponent();

            bdStudentDemography = new BindDpo<PersonDpo>(student.Person);
            bdStudentDemography.Bind(this.txtStudent_FirstName, PersonDpo._First_Name);
            bdStudentDemography.Bind(this.txtStudent_LastName, PersonDpo._Last_Name);

            bdAdultDemography = new BindDpo<PersonDpo>(adult.Person);
            bdAdultDemography.Bind(this.txtAdult_FirstName, PersonDpo._First_Name);
            bdAdultDemography.Bind(this.txtAdult_LastName, PersonDpo._Last_Name);


            bdAddress = new BindDpo<AddressDpo>(adult.Address);
            bdAddress.Bind(this.txtStreetNumber, AddressDpo._Street_Number);
            bdAddress.Bind(this.txtStreetName, AddressDpo._Street_Name);
            bdAddress.Bind(this.txtApartment, AddressDpo._Apartment);
            bdAddress.Bind(this.txtCity, AddressDpo._City);
            bdAddress.Bind(this.txtState, AddressDpo._State);
            bdAddress.Bind(this.txtZipCode, AddressDpo._Postal_Code);

            bdPhone = new BindDpo<PhoneDpo>(adult.Phone);
            bdPhone.Bind(this.txtCellPhone, PhoneDpo._Mobile);
            bdPhone.Bind(this.txtHomePhone, PhoneDpo._Phone);

            bdStudent = new BindDpo<ptaStudentDpo>(student);
            bdStudent.Bind<RegisterForm, int>(this, (form, value) => form.studentId = value, form => form.studentId, ptaStudentDpo._Student_ID);
            bdStudent.Bind<RegisterForm, int>(this, (form, value) => form.addressId = value, form => form.addressId, ptaStudentDpo._Address_ID);
            bdStudent.Bind(this.txtGrade, ptaStudentDpo._Grade);

            // Adult
            bdAdult = new BindDpo<ptaAdultDpo>(adult);
            bdAdult.Bind(this.txtEmail, ptaAdultDpo._Email);
            bdAdult.Bind(this.txtProfession, ptaAdultDpo._Profession);
            bdAdult.Bind<RegisterForm, int>(this, (form, value) => form.adultId = value, form => form.adultId, ptaAdultDpo._Adult_ID);
            bdAdult.Bind<RegisterForm, int>(this, (form, value) => form.addressId = value, form => form.addressId, ptaAdultDpo._Address_ID);
            bdAdult.Bind<RegisterForm, int>(this, (form, value) => form.phoneId = value, form => form.phoneId, ptaAdultDpo._Home_Phone_ID);

            foreach (CheckedListBoxItem item in this.clAvailability.Items)
            {
                bdAdult.Bind<CheckedListBoxItem, bool>(item, FillCheckedListBoxItem, CollectCheckedListBoxItem, (string)item.Value);
                item.CheckState = CheckState.Unchecked;
            }

            foreach (CheckedListBoxItem item in this.clInterest.Items)
            {
                bdAdult.Bind<CheckedListBoxItem, bool>(item, FillCheckedListBoxItem, CollectCheckedListBoxItem, (string)item.Value);
                item.CheckState = CheckState.Unchecked;
            }

            bdAdult.Bind(this.txtOther, ptaAdultDpo._Other);
        }


        public override void RuleDefinition(ValidateProvider provider)
        {
            this.txtStudent_FirstName.Required(provider, "First name of student required");
            this.txtStudent_LastName.Required(provider, "Last name of student required");

            this.txtAdult_FirstName.Required(provider, "First name of adult required");
            this.txtAdult_LastName.Required(provider, "Last name of adult required");
            this.txtHomePhone.Required(provider, "Home phone is required");

            this.clAvailability.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                foreach (CheckedListBoxItem item in this.clAvailability.Items)
                    if (item.CheckState == CheckState.Checked)
                        return;
                validator.error("You must check at least one.");
                return;
                
            });

            this.clInterest.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                foreach (CheckedListBoxItem item in this.clInterest.Items)
                    if (item.CheckState == CheckState.Checked)
                        return;

                validator.error("You must check at least one interest.");
                return;

            });
        }

        private static void FillCheckedListBoxItem(CheckedListBoxItem control,  bool value)
        {
            control.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
        }

        private bool CollectCheckedListBoxItem(CheckedListBoxItem control)
        {
            return control.CheckState == CheckState.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.RuleValidated())
                return;

            bdStudentDemography.SaveDpo();
            this.studentId = bdStudentDemography.Dpo.Person_ID;

            bdAdultDemography.SaveDpo();
            this.adultId = bdAdultDemography.Dpo.Person_ID;

            bdAddress.SaveDpo();
            this.addressId = bdAddress.Dpo.Address_ID;

            bdPhone.SaveDpo();
            this.phoneId = bdPhone.Dpo.Phone_ID;

            bdStudent.SaveDpo();
           
            bdAdult.SaveDpo();
        }
    }
}
