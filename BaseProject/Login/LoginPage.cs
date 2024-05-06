using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class LoginPage : Driver
    {
        #region---------------Locators----------------------------
        public static readonly string Email_Identifier = "//input[@id='email']";
        public static readonly string Password_Identifier = "//input[@id='password']";
        public static readonly string LoginButton_Identifier = "//button[@type='submit']";
        public static readonly string SuccessAlert_Identifier = "//div[@role='alert'][@aria-label='Success!']";
        public static readonly string MaPDashboardHeader_Identifier = "//div[contains(@class,'list-header')]";
        public static readonly string LogOut_Identifier = "//div[contains(@class,'header-container')]//li/a[text()='Log Out']";

        #endregion

        public static IWebElement Email
        {
            get { return Instance.FindElement(By.XPath(Email_Identifier), Const.SixSeconds); }
        }
        public static IWebElement Password
        {
            get { return Instance.FindElement(By.XPath(Password_Identifier), Const.SixSeconds); }
        }
        public static IWebElement LoginButton
        {
            get { return Instance.FindElement(By.XPath(LoginButton_Identifier), Const.SixSeconds); }
        }
        public static IWebElement DashboardHeader
        {
            get { return Instance.FindElement(By.XPath(MaPDashboardHeader_Identifier), Const.SixSeconds); }
        }
        public static bool LogOut()
        {
            return ControlUtils.CheckElementPresent(By.XPath(LogOut_Identifier), Const.SixSeconds);
        }



    }
}
