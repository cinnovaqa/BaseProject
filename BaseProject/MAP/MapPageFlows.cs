using OpenQA.Selenium;


namespace BaseProject.MAP
{
    public class MapPageFlows
    {
        public static string GetCurrentDate()
        {
            DateTime currentDate = DateTime.Today;
            string formattedDate = currentDate.ToString("MMMM dd, yyyy");
            return formattedDate;
        }
        public static int GetColumnPositionInTable(IList<IWebElement> headerList, string headerName)
        {
            int columnNumber = 0;
            for (int i = 0; i < headerList.Count; i++)
            {
                if (headerList[i].Text.Contains(headerName))
                {
                    columnNumber = i + 1;
                    i = headerList.Count;
                }
            }
            return columnNumber;
        }
        public static int GetRowPositionInTable(IList<IWebElement> RowList, string patientName)
        {
            int rowNumber = 0;
            for (int i = 0; i < RowList.Count; i++)
            {
                if (RowList[i].Text.Contains(patientName))
                {
                    rowNumber = i + 1;
                    i = RowList.Count;
                }
            }
            return rowNumber;
        }
        public static int GetRowPositionInTable1(IList<IWebElement> RowList, string selectedTime)
        {
            int rowNumber = 0;
            for (int i = 0; i < RowList.Count; i++)
            {
                if (RowList[i].Text.Contains(selectedTime))
                {
                    rowNumber = i + 1;
                    i = RowList.Count;
                }
            }
            return rowNumber;
        }
        public static int TableCount()
        {
            int count;
            try
            {
                count = MapPage.PatientCountInTable.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        public static string CreatePatientAppointment()
        {
            ControlUtils.ClickElement(MapPage.AddPatientButton);
            ControlUtils.ClickElement(MapPage.RequestedLab);
            ControlUtils.EnterText(MapPage.RequestedLab, Const.RequestedLab);
            ControlUtils.ClickElement(MapPage.SelectRequestedLab);
            ControlUtils.ClickElement(MapPage.LabOrder);
            ControlUtils.ClickElement(MapPage.SelectPanelTwo);
            ControlUtils.ClickElement(MapPage.PhysicianFirstName);
            ControlUtils.EnterText(MapPage.PhysicianFirstName, Const.PhysicianFirstName);
            ControlUtils.ClickElement(MapPage.PhysicianLastName);
            ControlUtils.EnterText(MapPage.PhysicianLastName, Const.PhysicianLastName);
            ControlUtils.ClickElement(MapPage.PhysicianClinicName);
            ControlUtils.EnterText(MapPage.PhysicianClinicName, Const.PhysicianClinic);
            ControlUtils.ClickElement(MapPage.PhysicianNPINumber);
            ControlUtils.EnterText(MapPage.PhysicianNPINumber, Const.PhysicianNPINumber);
            ControlUtils.ClickElement(MapPage.PhysicianNextButton);
            ControlUtils.ClickElement(MapPage.PatientFirstName);
            ControlUtils.EnterText(MapPage.EnterPatientFirstName, Const.PatientFirstName);
            ControlUtils.ClickElement(MapPage.PatientLastName);
            ControlUtils.EnterText(MapPage.EnterPatientLastName, Const.PatientLastName);
            ControlUtils.ClickElement(MapPage.SelectCalendarField(Const.Zero));
            ControlUtils.EnterText(MapPage.SetCurrentDate(Const.Zero), GetCurrentDate());
            ControlUtils.ClickElement(MapPage.GenderSelection(Const.Male));
            ControlUtils.EnterText(MapPage.PatientEmail, Const.PatientEmail);
            ControlUtils.EnterText(MapPage.PatientPhone, Const.PatientPhone);
            ControlUtils.Click(MapPage.PatientNextButton);
            ControlUtils.ClickElement(MapPage.SelectCalendarField(Const.One));
            ControlUtils.EnterText(MapPage.SetCurrentDate(Const.One), GetCurrentDate());
            ControlUtils.PressEnterKey();
            ControlUtils.ClickElement(MapPage.PatientAppointmentTime);
            var list = MapPage.PatientSelectTime;
            ControlUtils.ClickElement(list[Const.Four]);
            string selectedTime = MapPage.PatientSelectedTime.Text;
            ControlUtils.ClickElement(MapPage.FinishAppointment);
            MapPage.AppointmentInMAPPresent(Const.PatientFirstName, Const.PatientLastName, selectedTime);
            return selectedTime;
        }
      


    }
}

