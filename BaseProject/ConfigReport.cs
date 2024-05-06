using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
        public static class ConfigReport
        {
            public static ExtentTest childTest;
            public static ExtentTest parentTest;
            public static string reportName;
            public static void SetSuccessMessage(string message_success, bool screenshot = true)
            {
                if (message_success != string.Empty)
                {
                    childTest.Log(Status.Pass, message_success);
                    if (screenshot)
                    {
                        TakeScreenShot(Const.LabelScreenshot);
                    }
                }
            }
            public static void SetFailureMessage(string message_failure, bool skipExecution, bool screenshot = true)
            {
                if (message_failure != string.Empty)
                {
                    childTest.Log(Status.Fail, message_failure);
                    if (screenshot)
                    {
                        TakeScreenShot(Const.LabelScreenshot);
                    }
                }
                if (skipExecution)
                {
                    throw new Exception(message_failure);
                }
            }
            public static void TakeScreenShot(string label)
            {
                childTest.Log(Status.Info, "<font color = Purple>" + label + "</font>", ScreenShot.GetScreenShot().Build());
            }
            public static void TakeErrorScreenShot(string label)
            {
                childTest.Log(Status.Info, "<font color = Red>" + label + "</font>", ScreenShot.GetScreenShot().Build());
            }
            public static void AddScenario()
            {
                string mainfile = File.ReadAllText(Strings.WorkspaceDefaultPath + "Reports\\" + reportName);
                string newMainfile = mainfile.Replace("Steps", "Scenarios");
                newMainfile = newMainfile.Replace("step", "scenario");
                newMainfile = newMainfile.Replace("scenario-filter", "step-filter");
                File.Delete(Strings.WorkspaceDefaultPath + "Reports\\" + reportName);
                File.WriteAllText(Strings.WorkspaceDefaultPath + "Reports\\" + reportName, newMainfile);
            }
            public static void Print(string label, string text)
            {
                childTest.Log(Status.Info, "<b> <font color = black>" + label + "</font> </b>" + text);
            }

            public static void Scenario(string scenarioName)
            {
                childTest = parentTest.CreateNode(scenarioName);
            }
            public static void Case(string text)
            {
                childTest.Log(Status.Info, "<b> <font color = black>" + text + "</font> </b>");
            }
        }
    }
