using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BaseProject
{
    public class ControlUtils : Driver
    {
        public static void ClickElement(IWebElement element)
        {
            Thread.Sleep(Const.HalfSecond);
            element.Click();
            Thread.Sleep(Const.HalfSecond);
        }
        public static void Click(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Instance;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public static void EnterText(IWebElement element, string textToEnter)
        {
            element.SendKeys(textToEnter);
            Thread.Sleep(Const.HalfSecond);
        }
        public static bool CheckElementPresent(By by, int timeoutInSeconds)
        {
            var element = Instance.FindElement(@by, timeoutInSeconds);
            if (element == null)
            {
                return false;
            }
            return true;
        }
        public static IWebElement WaitForElement(IWebElement element)
        {
            DefaultWait<IWebDriver> fluentWait = new(Instance)
            {
                Timeout = TimeSpan.FromSeconds(Const.TwoMinute),

                PollingInterval = TimeSpan.FromSeconds(2)
            };

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                                            typeof(ElementClickInterceptedException),
                                            typeof(ElementNotVisibleException),
                                            typeof(ElementNotSelectableException),
                                            typeof(ElementNotInteractableException));

            IWebElement result = fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

            return result;
        }
        public static void PressEnterKey()
        {
            Thread.Sleep(Const.HalfSecond);
            Actions action = new(Instance);
            action.SendKeys(Keys.Enter).Build().Perform();
        }
        public static bool IsElementEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public static bool CheckElementDisabled(IWebElement element)
        {
            if (!element.Enabled)
            {
                return true;
            }
            return false;
        }
        public static string GetElementText(IWebElement element)
        {
            string text = string.Empty;
            try
            {
                if (element.Text != null)
                {
                    return element.Text;
                }
            }
            catch (Exception)
            {

            }
            return text;
        }
    }
}
