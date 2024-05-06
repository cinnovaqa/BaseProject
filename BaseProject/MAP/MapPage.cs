using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.MAP
{
    public class MapPage : Driver
    {
        #region---------------Locators----------------------------
        public static readonly string AddPatientButton_Identifier = "//button[contains(@class,'add-button')]";
        public static readonly string AddPatientHeader_Identifier = "//div/h4[contains(@class,'card-title')]";
        public static readonly string RequestedLab_Identifier = "//input[contains(@formcontrolname,'laboratory_name')]";
        public static readonly string LabOrder_Identifier = "//div/ng-select[contains(@formcontrolname,'test_uniq_id')]";
        public static readonly string PhysicianFirstName_Identifier = "//label[contains(text(),'Physician First Name')]//preceding::input[contains(@formcontrolname,'first_name')]";
        public static readonly string PhysicianLastName_Identifier = "//label[contains(text(),'Physician Last Name')]//preceding::input[contains(@formcontrolname,'last_name')]";
        public static readonly string PhysicianClinicName_Identifier = "//label[contains(text(),'Practice Name')]//preceding::input[contains(@formcontrolname,'clinic_or_practice_name')]";
        public static readonly string PhysicianNPINumber_Identifier = "//label[contains(text(),'NPI Number')]//preceding::input[contains(@formcontrolname,'npi_number')]";
        public static readonly string PhysicianNextButton_Identifier = "//div[ (contains(@id,'step1'))]//button[@type='submit']";
        public static readonly string SelectPanelTwo_Identifier = "//div[@role='listbox']//div/div[2]";
        public static readonly string SelectRequestedLab_Identifier = "//button[contains(@class,'dropdown-item')]/span";
        public static readonly string SecondTab_Identifier = "//a[@href='#step2' and (@class='active')]";
        public static readonly string PatientFirstName_Identifier = "//input[contains(@formcontrolname,'first_name') and contains (@class,'ng-valid')]//following::label[text()='First Name']";
        public static readonly string PatientLastName_Identifier = "//input[contains(@formcontrolname,'first_name') and contains (@class,'ng-valid')]//following::label[text()='Last Name']";
        public static readonly string EnterPatientFirstName_Identifier = "//input[contains(@formcontrolname,'first_name') and contains (@class,'ng-invalid')]";
        public static readonly string EnterPatientLastName_Identifier = "//input[contains(@formcontrolname,'last_name') and contains (@class,'ng-invalid')]";
        public static readonly string SelectCalendarField_Identifier = "//input[contains(@data-mat-calendar,'mat-datepicker-{0}')]";
        public static readonly string SetCurrentDate_Identifier = "//input[contains(@data-mat-calendar,'mat-datepicker-{0}')]";
        public static readonly string GenderSelection_Identifier = "//input[@type='radio']//following-sibling::label[@for='{0}']";
        public static readonly string PatientEmail_Identifier = "//input[@formcontrolname='email']";
        public static readonly string PatientPhone_Identifier = "//input[@formcontrolname='phone']";
        public static readonly string PatientNextButton_Identifier = "//div[ (contains(@id,'step2'))]//button[@type='submit']";
        public static readonly string ThirdTab_Identifier = "//a[@href='#step3' and (@class='active')]";
        public static readonly string PatientSelectTime_Identifier = "//ng-select[@formcontrolname='scheduled_time']//div[@role='option'] [not (contains(@class,'ng-option-disabled'))]";
        public static readonly string PatientAppointmentTime_Identifier = "//div[@class='ng-select-container' ]//span[contains(@class,'ng-arrow-wrapper')]";
        public static readonly string FinishAppointment_Identifier = "//div[ (contains(@id,'step3'))]//button[@type='submit'][text()='Finish']";
        public static readonly string AppointmentQueue_Identifier = "//*[contains(@class,'card-title')][text()='Your Queue']";
        public static readonly string AppointmentInQueue_Identifier = "//tbody/tr/td[contains(@class,'patient-name')]/span[text()='{0}']//preceding::td/span[text()='{1}']";
        public static readonly string RemovePatient_Identifier = "//button[contains(@class,'button-remove')]";
        public static readonly string QueueHeader_Identifier = "//table//tr/th";
        public static readonly string QueueTableRows_Identifier = "//tbody/tr";
        public static readonly string TableValue_Identifier = "//table//tbody/tr[{0}]/td[{1}]";
        public static readonly string RemovePatientDialog_Identifier = "//div[contains(@class,'modal-dialog')]//h3[text()='Remove Patient']";
        public static readonly string RemovePatientConfirmation_Identifier = "//div[contains(@class,'modal-dialog')]//h3[text()='Remove Patient']//following::button[text()='Remove Patient']";
        public static readonly string PatientRemovedAlert_Identifier = "//div[@role='alert'][contains(@aria-label,'removed')]";
        public static readonly string PatientCountInTable_Identifier = "//tbody/tr[contains(@class,'ng-star-inserted')]//td[@class='patient-name']";
        public static readonly string PatientSelectedTime_Identifier = "//label[text()='Appointment Time']//parent::div//div[text()='Select Time']//following::div[1]";

        #endregion

        public static IWebElement AddPatientButton
        {
            get { return Instance.FindElement(By.XPath(AddPatientButton_Identifier), Const.SixSeconds); }
        }

        public static bool AddPatientHeaderPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(AddPatientHeader_Identifier), Const.SixSeconds);
        }
        public static IWebElement RequestedLab
        {
            get { return Instance.FindElement(By.XPath(RequestedLab_Identifier), Const.SixSeconds); }
        }
        public static IWebElement LabOrder
        {
            get { return Instance.FindElement(By.XPath(LabOrder_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PhysicianFirstName
        {
            get { return Instance.FindElement(By.XPath(PhysicianFirstName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PhysicianLastName
        {
            get { return Instance.FindElement(By.XPath(PhysicianLastName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PhysicianClinicName
        {
            get { return Instance.FindElement(By.XPath(PhysicianClinicName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PhysicianNPINumber
        {
            get { return Instance.FindElement(By.XPath(PhysicianNPINumber_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PhysicianNextButton
        {
            get { return Instance.FindElement(By.XPath(PhysicianNextButton_Identifier), Const.SixSeconds); }
        }
        public static IWebElement SelectPanelTwo
        {
            get { return Instance.FindElement(By.XPath(SelectPanelTwo_Identifier), Const.SixSeconds); }
        }
        public static IWebElement SelectRequestedLab
        {
            get { return Instance.FindElement(By.XPath(SelectRequestedLab_Identifier), Const.SixSeconds); }
        }
        public static bool SecondTabPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(SecondTab_Identifier), Const.SixSeconds);
        }
        public static IWebElement PatientFirstName
        {
            get { return Instance.FindElement(By.XPath(PatientFirstName_Identifier),30); }
        }
        public static IWebElement PatientLastName
        {
            get { return Instance.FindElement(By.XPath(PatientLastName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement EnterPatientFirstName
        {
            get { return Instance.FindElement(By.XPath(EnterPatientFirstName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement EnterPatientLastName
        {
            get { return Instance.FindElement(By.XPath(EnterPatientLastName_Identifier), Const.SixSeconds); }
        }
        public static IWebElement SelectCalendarField(int number)
        {
            string xpath = string.Format(SelectCalendarField_Identifier, number);
            { return Instance.FindElement(By.XPath(xpath), Const.SixSeconds); }
        }
        public static IWebElement SetCurrentDate(int number)
        {
            string xpath = string.Format(SetCurrentDate_Identifier, number);
            { return Instance.FindElement(By.XPath(xpath), Const.SixSeconds); }
        }
        public static IWebElement GenderSelection(string gender)
        {
            string xpath = string.Format(GenderSelection_Identifier, gender);
            return Instance.FindElement(By.XPath(xpath), Const.SixSeconds);
        }
        public static IWebElement PatientEmail
        {
            get { return Instance.FindElement(By.XPath(PatientEmail_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PatientPhone
        {
            get { return Instance.FindElement(By.XPath(PatientPhone_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PatientNextButton
        {
            get { return Instance.FindElement(By.XPath(PatientNextButton_Identifier), Const.SixSeconds); }
        }
        public static bool ThirdTabPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(ThirdTab_Identifier), Const.SixSeconds);
        }
        public static IList<IWebElement> PatientSelectTime
        {
            get { return Instance.FindElements(By.XPath(PatientSelectTime_Identifier), Const.SixSeconds); }
        }
        public static IWebElement PatientAppointmentTime
        {
            get { return Instance.FindElement(By.XPath(PatientAppointmentTime_Identifier), Const.SixSeconds); }
        }
        public static IWebElement FinishAppointment
        {
            get { return Instance.FindElement(By.XPath(FinishAppointment_Identifier), Const.SixSeconds); }
        }
        public static IWebElement AppointmentQueue
        {
            get { return Instance.FindElement(By.XPath(AppointmentQueue_Identifier), Const.SixSeconds); }
        }
        public static bool AppointmentInMAPPresent(string patientFirstName, string patientLastName, string time)
        {
            string xpath = string.Format(AppointmentInQueue_Identifier, patientFirstName + " " + patientLastName, time);
            return ControlUtils.CheckElementPresent(By.XPath(xpath), Const.SixSeconds);
        }
        public static IWebElement RemovePatient
        {
            get { return Instance.FindElement(By.XPath(RemovePatient_Identifier), Const.SixSeconds); }
        }
        public static IList<IWebElement> QueueHeader
        {
            get { return Instance.FindElements(By.XPath(QueueHeader_Identifier)); }

        }
        public static IList<IWebElement> QueueTableRows
        {
            get { return Instance.FindElements(By.XPath(QueueTableRows_Identifier)); }

        }
        public static IWebElement EditPatientAppointment(int rowNumber, int columnNumber)
        {
            string xpath = string.Format(TableValue_Identifier, rowNumber, columnNumber);
            return Instance.FindElement(By.XPath(xpath), Const.SixSeconds);
        }
        public static bool RemovePatientDialogPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(RemovePatientDialog_Identifier), Const.SixSeconds);
        }
        public static IWebElement RemovePatientConfirmation
        {
            get { return Instance.FindElement(By.XPath(RemovePatientConfirmation_Identifier), Const.SixSeconds); }
        }
        public static bool PatientRemovedAlertPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(PatientRemovedAlert_Identifier), Const.SixSeconds);
        }
        public static IList<IWebElement> PatientCountInTable
        {
            get { return Instance.FindElements(By.XPath(PatientCountInTable_Identifier), Const.SixSeconds); }

        }
        public static IWebElement PatientSelectedTime
        {
            get { return Instance.FindElement(By.XPath(PatientSelectedTime_Identifier), Const.SixSeconds); }
        }
        public static bool PatientCountInTablePresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(PatientCountInTable_Identifier), Const.SixSeconds);
        }

    }
}



