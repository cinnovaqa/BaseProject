using BaseProject.Lab;
using BaseProject.Login;
using BaseProject.MAP;
using NUnit.Framework;



namespace BaseProject
{
    public class ProjectTestCases : BaseTest
    {
        [TestCase(), Description("Verify Patient Appointment"), Order(1), Category("MOMS")]
        public void Cin_MOMs_01()
        {
            ConfigReport.Scenario(Strings.Cin_MOMs_01_SCN1);
            ControlUtils.ClickElement(MapPage.AddPatientButton);
            softAssert.IsTrue(MapPage.AddPatientHeaderPresent(), Strings.MessagePatientAppointmentPageOpenedPass, Strings.MessagePatientAppointmentPageOpenedFail);

            ConfigReport.Case("Lab information");
            ControlUtils.ClickElement(MapPage.RequestedLab)
                ;
            ControlUtils.EnterText(MapPage.RequestedLab, Const.RequestedLab);
            ControlUtils.ClickElement(MapPage.SelectRequestedLab);
            softAssert.IsFalse(ControlUtils.IsElementEnabled(MapPage.PhysicianNextButton), Strings.MessageNextButtonDisabledPass, Strings.MessageNextButtonDisabledFail);
            ControlUtils.ClickElement(MapPage.LabOrder);
            ControlUtils.ClickElement(MapPage.SelectPanelTwo);
            softAssert.IsTrue(ControlUtils.IsElementEnabled(MapPage.PhysicianNextButton), Strings.MessageNextButtonEnabledPass, Strings.MessageNextButtonEnabledFail);
            ConfigReport.TakeScreenShot(Strings.LabelLabInformation);

            ConfigReport.Case("Physician Information");
            ControlUtils.ClickElement(MapPage.PhysicianFirstName);
            ControlUtils.EnterText(MapPage.PhysicianFirstName, Const.PhysicianFirstName);
            ControlUtils.ClickElement(MapPage.PhysicianLastName);
            ControlUtils.EnterText(MapPage.PhysicianLastName, Const.PhysicianLastName);
            ControlUtils.ClickElement(MapPage.PhysicianClinicName);
            ControlUtils.EnterText(MapPage.PhysicianClinicName, Const.PhysicianClinic);
            ControlUtils.ClickElement(MapPage.PhysicianNPINumber);
            ControlUtils.EnterText(MapPage.PhysicianNPINumber, Const.PhysicianNPINumber);
            ConfigReport.TakeScreenShot(Strings.LabelPhysicianInformation);
            ControlUtils.ClickElement(MapPage.PhysicianNextButton);
            softAssert.IsTrue(MapPage.SecondTabPresent(), Strings.MessageRedirectionToPatientInfoPass, Strings.MessageRedirectionToPatientInfoFail);

            ConfigReport.Case("Patient Information");
            ControlUtils.ClickElement(MapPage.PatientFirstName);
            ControlUtils.EnterText(MapPage.EnterPatientFirstName, Const.PatientFirstName);
            ControlUtils.ClickElement(MapPage.PatientLastName);
            ControlUtils.EnterText(MapPage.EnterPatientLastName, Const.PatientLastName);
            ControlUtils.ClickElement(MapPage.SelectCalendarField(Const.Zero));
            ControlUtils.EnterText(MapPage.SetCurrentDate(Const.Zero), MapPageFlows.GetCurrentDate());
            ControlUtils.ClickElement(MapPage.GenderSelection(Const.Male));
            ControlUtils.EnterText(MapPage.PatientEmail, Const.PatientEmail);
            ControlUtils.EnterText(MapPage.PatientPhone, Const.PatientPhone);
            ConfigReport.TakeScreenShot(Strings.LabelPatientInformation);
            ControlUtils.Click(MapPage.PatientNextButton);
            softAssert.IsTrue(MapPage.ThirdTabPresent(), Strings.MessageRedirectionToScheduleTimePass, Strings.MessageRedirectionToScheduleTimeFail);

            ConfigReport.Case("Appointment Information");
            ControlUtils.ClickElement(MapPage.SelectCalendarField(Const.One));
            ControlUtils.EnterText(MapPage.SetCurrentDate(Const.One), MapPageFlows.GetCurrentDate());
            ControlUtils.PressEnterKey();
            ControlUtils.ClickElement(MapPage.PatientAppointmentTime);
            var list = MapPage.PatientSelectTime;
            ControlUtils.ClickElement(list[Const.Four]);
            string selectedTime = MapPage.PatientSelectedTime.Text;
            ControlUtils.ClickElement(MapPage.FinishAppointment);
            ConfigReport.TakeScreenShot(Strings.LabelAppointmentInformation);
            softAssert.IsTrue(MapPage.AppointmentInMAPPresent(Const.PatientFirstName, Const.PatientLastName, selectedTime), string.Format(Strings.MessageAppointmentSchedulePass, Const.MAP), string.Format(Strings.MessageAppointmentScheduleFail, Const.MAP));
            ControlUtils.PressEnterKey();

            ConfigReport.Case("Appointment in Lab Collections");
            OpenNewTab();
            NavigateTo(Const.URLLAB);
            LoginFlow.Login(Const.Email_LaB, Const.Password_Lab);
            softAssert.IsTrue(LabPage.CollectionsTabPresent(), string.Empty, Strings.MessageCollectionTabNotPresent);
            ControlUtils.ClickElement(LabPage.CollectionsTab);
            softAssert.IsTrue(LabPage.CollectionsDashboardPresent(), string.Empty, Strings.MessageCollectionDashboardOpenedFail);
            softAssert.IsTrue(LabPage.AppointmentInCollectionPresent(Const.PatientFirstName, Const.PatientLastName, selectedTime), string.Format(Strings.MessageAppointmentSchedulePass, Const.LAB), string.Format(Strings.MessageAppointmentScheduleFail, Const.LAB));
            CloseBrowserLastWindow();
            SwitchToFirstWindow();
            var rowNumber = MapPageFlows.GetRowPositionInTable(MapPage.QueueTableRows, Const.PatientFirstName);
            var columnNumber = MapPageFlows.GetColumnPositionInTable(MapPage.QueueHeader, Const.Edit);
            ControlUtils.ClickElement(MapPage.EditPatientAppointment(rowNumber, columnNumber));
            ControlUtils.ClickElement(MapPage.RemovePatient);
            softAssert.IsTrue(MapPage.RemovePatientDialogPresent());
            ControlUtils.ClickElement(MapPage.RemovePatientConfirmation);

        }
        [TestCase(), Description("Verify Appointment Deletion"), Order(2), Category("MOMS")]
        public void Cin_MOMs_02()
        {
            ConfigReport.Scenario(Strings.Cin_MOMs_02_SCN1);
            var selectedTime = MapPageFlows.CreatePatientAppointment();
            var PatientCountBeforeRemoval = MapPage.PatientCountInTable;
            ConfigReport.TakeScreenShot(Strings.LabelMAPDashboardView);
            var rowNumber = MapPageFlows.GetRowPositionInTable1(MapPage.QueueTableRows, selectedTime);
            var columnNumber = MapPageFlows.GetColumnPositionInTable(MapPage.QueueHeader, Const.Edit);
            ControlUtils.ClickElement(MapPage.EditPatientAppointment(rowNumber, columnNumber));
            ControlUtils.ClickElement(MapPage.RemovePatient);
            softAssert.IsTrue(MapPage.RemovePatientDialogPresent(), Strings.MessageRemovePatientDialogPresent, Strings.MessageRemovePatientDialogNotPresent);
            ControlUtils.ClickElement(MapPage.RemovePatientConfirmation);
            softAssert.IsTrue(MapPage.PatientRemovedAlertPresent(), Strings.MessagePatientRemovedPass, Strings.MessagePatientRemovedFail);
            softAssert.IsFalse(MapPage.AppointmentInMAPPresent(Const.PatientFirstName, Const.PatientLastName, selectedTime), string.Empty, string.Empty, false, false);
            softAssert.AreEqual(MapPageFlows.TableCount(), PatientCountBeforeRemoval.Count - Const.One, Strings.MessagePatientRemovedFromDashboardPass, Strings.MessagePatientRemovedFromDashboardFail);

            ConfigReport.Scenario(Strings.Cin_MOMs_02_SCN2);
            OpenNewTab();
            NavigateTo(Const.URLLAB);
            LoginFlow.VerifyLogin(Const.Email_LaB, Const.Password_Lab);
            softAssert.IsTrue(LabPage.CollectionsTabPresent(), string.Empty, Strings.MessageCollectionTabNotPresent);
            ControlUtils.ClickElement(LabPage.CollectionsTab);
            softAssert.IsTrue(LabPage.CollectionsDashboardPresent(), string.Empty, Strings.MessageCollectionDashboardOpenedFail);
            softAssert.IsFalse(LabPage.AppointmentInCollectionPresent(Const.PatientFirstName, Const.PatientLastName, selectedTime), Strings.MessagePatientRemovedFromCollectionPass, Strings.MessagePatientRemovedFromCollectionPass);
            SwitchToFirstWindow();

        }
    }

}

