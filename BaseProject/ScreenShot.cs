using AventStack.ExtentReports;
using OpenQA.Selenium;


namespace BaseProject
{
    public static class ScreenShot
    {
        public static MediaEntityBuilder mediaEntity;
        public static MediaEntityBuilder CaptureScreenshot()
        {
            var screenshot = ((ITakesScreenshot)Driver.Instance).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String((screenshot));
        }
        public static MediaEntityBuilder GetScreenShot()
        {
            return mediaEntity = CaptureScreenshot();
        }
    }
}
