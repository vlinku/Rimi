using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace Rimi.Tools
{
  public class MyScreenshot
  {
    public static void MakeScreeshot(IWebDriver Driver)
    {
      Screenshot myBrowserScreenshot = Driver.TakeScreenshot();
      string screenshotDirectory = Path.GetDirectoryName(
                                   Path.GetDirectoryName(
                                   Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
      string screenshotFolder = Path.Combine(screenshotDirectory, "screenshots");
      Directory.CreateDirectory(screenshotFolder);
      string screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH_mm_ss}.png";
      string screenshotPath = Path.Combine(screenshotFolder, screenshotName);
      myBrowserScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
    }
  }
}
