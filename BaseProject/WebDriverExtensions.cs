using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SoftAssertion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using System.Linq;

namespace BaseProject
{

    public static class WebDriverExtensions
    {
        private static readonly IDictionary<int, AssertFailed> checkAssert = new Dictionary<int, AssertFailed>();
        private static int _counter = 0;
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                    return wait.Until(drv => drv.FindElement(by));
                }
            }
            catch (WebDriverTimeoutException)
            {
                Driver.exceptionMessage = "<b>Reason: </b> " + Strings.MessageTimeOutException;
                return null;
            }
            return driver.FindElement(by);
        }
        public static IList<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                    return wait.Until(drv => drv.FindElements(by));
                }
            }
            catch (WebDriverTimeoutException)
            {
                Driver.exceptionMessage = "<b>Reason: </b> " + Strings.MessageTimeOutException;
                return null;
            }
            return driver.FindElements(by);
        }
        public static void AreEqual(this SoftAssert softAssert, object expected, object actual, string success_message, string failure_message, bool abortExecution = false, bool screenshot = true)
        {
            try
            {
                _counter++;
                Assert.AreEqual(expected, actual);
                ConfigReport.SetSuccessMessage(success_message, screenshot);
            }
            catch (AssertionException ex)
            {
                checkAssert.Add(_counter, new AssertFailed(ex.Message));
                ConfigReport.SetFailureMessage(failure_message, abortExecution, screenshot);
            }
        }
        public static void IsTrue(this SoftAssert softAssert, bool expression, string success_message, string failure_message, bool abortExecution = false, bool screenshot = true)
        {
            try
            {
                _counter++;
                softAssert.IsTrue(expression);
                if (expression.Equals(true))
                {
                    ConfigReport.SetSuccessMessage(success_message, screenshot);
                }
                else
                {
                    ConfigReport.SetFailureMessage(failure_message, abortExecution, screenshot);
                }
            }
            catch (AssertionException ex)
            {
                checkAssert.Add(_counter, new AssertFailed(ex.Message));
                ConfigReport.SetFailureMessage(failure_message, abortExecution, screenshot);
            }
        }
        public static void IsFalse(this SoftAssert softAssert, bool expression, string success_message, string failure_message, bool abortExecution = false, bool screenshot = true)
        {
            try
            {
                _counter++;
                softAssert.IsFalse(expression);
                if (expression == false)
                {
                    expression = true;
                    ConfigReport.SetSuccessMessage(success_message, screenshot);
                }
                else
                {
                    ConfigReport.SetFailureMessage(failure_message, abortExecution, screenshot);
                }
            }
            catch (AssertionException ex)
            {
                checkAssert.Add(_counter, new AssertFailed(ex.Message));
                ConfigReport.SetFailureMessage(failure_message, abortExecution, screenshot);
            }
        }
    }
       
}


