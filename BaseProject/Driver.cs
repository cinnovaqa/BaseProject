using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string exceptionMessage;
        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300.00);
        }
        public static void Close()
        {
            Instance.Quit();
            Process[] chromeInstances = Process.GetProcesses();
            foreach (Process p in chromeInstances)
            {
                if (p.ProcessName.Contains("chromedriver"))
                {
                    p.Kill();
                }
            }
        }
        public static void NavigateTo(string location)
        {
            Instance.Navigate().GoToUrl(location);
        }
        public static string ReturnWorkspacePath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
        }
        public static void OpenNewTab()
        {
            Instance.SwitchTo().NewWindow(WindowType.Tab);
        }
        public static void SwitchToFirstWindow()
        {
            Instance.SwitchTo().Window(Instance.WindowHandles.First());
        }
        public static void SwitchToLastWindow()
        {
            Instance.SwitchTo().Window(Instance.WindowHandles.Last());
        }
        public static void CloseBrowserLastWindow()
        {
            Instance.SwitchTo().Window(Instance.WindowHandles.Last()).Close();
        }
    }
}
