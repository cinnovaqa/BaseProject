
namespace BaseProject
{
    public static class Strings
    {
        public static string WorkspaceDefaultPath = Driver.ReturnWorkspacePath();

        #region ####################  Test Cases  ####################
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {

            { "Cin_MOMs_01" ,   "Verify Patient Appointment Creation from MAP"},
            { "Cin_MOMs_02" ,   "Verify Appointment Deletion"}

        };
        #endregion
        #region ####################  Test Cases Scenario ####################

        public static readonly string Cin_MOMs_01_SCN1 = "Patient Appointment Creation from MAP";
        public static readonly string Cin_MOMs_02_SCN1 = "Appointment Deletion from MAP Dashboard";
        public static readonly string Cin_MOMs_02_SCN2 = "Appointment Deletion from Lab Collections";

        #endregion
        #region ####################  Labels ####################

        public static readonly string LabelMAPDashboardView = "Dashboard view before patient removal:";
        public static readonly string LabelAppointmentInformation = "Appointement Information is attached:";
        public static readonly string LabelLabInformation = "Lab Information is attached:";
        public static readonly string LabelPhysicianInformation = "Physician Information is attached:";
        public static readonly string LabelPatientInformation = "Patient Information is attached:";
        #endregion
        #region ####################  Report Messages ####################
        public static string MessageTimeOutException = "Web driver time out has been occurred after " + Const.SixSeconds + " seconds";
        public static string MessagePatientAppointmentPageOpenedPass = "Patient appointment page is opened successfully";
        public static string MessagePatientAppointmentPageOpenedFail = "Patient appointment page is not opened ";
        public static string MessageNextButtonDisabledPass = "Next button is disabled before entering mandatory information";
        public static string MessageNextButtonDisabledFail = "Next button should not be enabled before entering mandatory information";
        public static string MessageNextButtonEnabledPass = "Next button is enabled after entering mandatory information";
        public static string MessageNextButtonEnabledFail = "Next button is disabled after entering mandatory information";
        public static string MessageRedirectionToPatientInfoPass = "User is successfully redirected to the Patient Info tab";
        public static string MessageRedirectionToPatientInfoFail = "User is not redirected to the Patient Info tab";
        public static string MessageRedirectionToScheduleTimePass = "User is successfully redirected to the Shedule Time tab";
        public static string MessageRedirectionToScheduleTimeFail = "User is not redirected to the Shedule Time tab";
        public static string MessageAppointmentSchedulePass = "Appointment is visible in {0} dashboard after schedule";
        public static string MessageAppointmentScheduleFail = "Appointment is not visible in {0} dashboard after schedule";
        public static string MessageRemovePatientDialogPresent = "Remove patient dialogue is appeared";
        public static string MessageRemovePatientDialogNotPresent = "Remove patient dialogue is not appeared";
        public static string MessageCollectionDashboardOpenedPass = "Collection dashboard is opened successfully";
        public static string MessageCollectionDashboardOpenedFail = "Collection dashboard is not opened successfully";
        public static string MessageCollectionTabPresent = "Collection tab is present in side bar";
        public static string MessageCollectionTabNotPresent = "Collection tab is not present in side bar";
        public static string MessagePatientRemovedPass = "Patient has been removed successfully";
        public static string MessagePatientRemovedFail = "Patient is not removed";
        public static string MessagePatientRemovedFromDashboardPass = "Patient is successfully removed from the dashboard";
        public static string MessagePatientRemovedFromDashboardFail = "Patient is not removed from the dashboard";
        public static string MessagePatientRemovedFromCollectionPass = "Patient is successfully removed from the Collections";
        public static string MessagePatientRemovedFromCollectionFail = "Patient is not removed from the Collections";
        #endregion
    }
}
