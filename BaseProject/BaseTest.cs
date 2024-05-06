using NUnit.Framework;

using SoftAssertion;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualBasic;
using System.Security.Policy;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using BaseProject.Login;


namespace BaseProject
{
    public class BaseTest : Driver
    {
        public static DateTime today = DateTime.Now;
        public static SoftAssert softAssert = new SoftAssert();
        public static AventStack.ExtentReports.ExtentReports extent;
        public static string projectFilePath;
        public static string fileName;

        [OneTimeSetUp()]
        public virtual void OneTimeSetUp()
        {
            Initialize();
            {
                NavigateTo(Const.URLMAP);
            }
            LoginFlow.Login(Const.Email_Map,Const.Password_Map);
        }
        [OneTimeSetUp()]
        public void ExtentStart()
        {
            DateTime time = DateTime.Now;
            fileName = "Screenshot_" + time + ".png";
            Directory.CreateDirectory(Strings.WorkspaceDefaultPath.ToString() + "Reports");
            ConfigReport.reportName = "Automation Report_" + time.ToString("dd-MM-yy-h-mm-ss") + ".html";
            var reportPath = Strings.WorkspaceDefaultPath + "Reports\\" + ConfigReport.reportName;
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.Config.CSS = "css-string";
            htmlReporter.Config.Encoding = "utf-8";
            extent.AddSystemInfo(Const.CompanyName, Const.CompanyValue);
            extent.AddSystemInfo(Const.BrowserName, Const.BrowserValue);
            extent.AddSystemInfo(Const.UserName, Const.UserValue);
            extent.AddSystemInfo(Const.SiteLink, Const.SiteLink);
            extent.AddSystemInfo(Const.Email, Const.EmailValue);
            htmlReporter.Config.DocumentTitle = "Automation";
            htmlReporter.Config.TimelineEnabled = false;
            htmlReporter.Config.ReportName = "QA Automation Test Cases Report";
        }
        [SetUp]
        public void BeforeTest()
        {
            string key = TestContext.CurrentContext.Test.MethodName;
            if (Strings.dictionary.ContainsKey(key))
            {
                string description = Strings.dictionary[key];
                ConfigReport.parentTest = extent.CreateTest(TestContext.CurrentContext.Test.MethodName, "<h5>" + "<b>" + description + "</b>" + "</h5>");
            }
        }

        [OneTimeTearDown()]
        public virtual void OneTimeTearDown()
        {
            try
            {
                extent.Flush();
                ConfigReport.AddScenario();
            }
            finally
            {
                Close();
            }
        }

        [TearDown()]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var errorMessage = TestContext.CurrentContext.Result.Message;
                ScreenShot.mediaEntity = ScreenShot.CaptureScreenshot();
                ConfigReport.childTest.Log(Status.Fail, "<details>" + "<summary>" + "<font color = CornflowerBlue>" + "<u>" + "<h6>" + "view exception" + "</h6>" + "</font>" + "</u>" + "</summary>" + errorMessage + "</details>", ScreenShot.mediaEntity.Build());
            }
            NavigateTo(Const.URLMAP);

        }

    }
}
