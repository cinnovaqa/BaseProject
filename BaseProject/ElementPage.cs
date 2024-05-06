using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class ElementPage : Driver
    {
        #region####################### Locators##########################
        public static readonly string Company_Identifier = "//li[@id='menu-item-66']";
        public static readonly string Services_Identifier = "//li[@id='menu-item-65']";
        #endregion

        public static IWebElement Company
        {
             get { return Instance.FindElement(By.XPath(Company_Identifier), Const.SixSeconds); }
        }
        public static IWebElement Services
        {
            get { return Instance.FindElement(By.XPath(Services_Identifier), Const.SixSeconds); }
        }
        public static bool GoogleTextFieldPresent()
        {
            return ControlUtils.CheckElementPresent(By.XPath(Services_Identifier), Const.SixSeconds);
        }
    }
}

