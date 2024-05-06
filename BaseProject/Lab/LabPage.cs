using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Lab
{
    public class LabPage : Driver
    {
        public static readonly string CollectionsTab_Identifier = "//div[contains(@class,'side-nav-inner')]//span[contains(@class,'title')][text()='Collections']";
        public static readonly string CollectionsDashboard_Identifier = "//div[contains(@class,'queue-list-header')]//h4[contains(@class,'card-title')][text()='Collections']";
       // public static readonly string AppointmentInCollectionPresent_Identifier = "//tbody/tr/td[contains(@class,'patient-name')]/span[text()='{0}']";
        public static readonly string AppointmentInCollectionPresent_Identifier = "//tbody/tr/td[contains(@class,'patient-name')]/span[text()='{0}']//preceding::td/span[text()='{1}']";


        public static IWebElement CollectionsTab
        {
            get { return Instance.FindElement(By.XPath(CollectionsTab_Identifier), Const.SixSeconds); }
        }
        public static bool CollectionsTabPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(CollectionsTab_Identifier), Const.SixSeconds);
        }
        public static bool CollectionsDashboardPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(CollectionsDashboard_Identifier), Const.SixSeconds);
        }
        public static bool AppointmentInCollectionPresent(string patientFirstName, string patientLastName,string time)
        {
            string xpath = string.Format(AppointmentInCollectionPresent_Identifier, patientFirstName + " " + patientLastName,time);
            return ControlUtils.CheckElementPresent(By.XPath(xpath), Const.SixSeconds);
        }











    }
}
