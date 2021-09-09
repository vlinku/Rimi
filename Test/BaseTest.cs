

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Rimi.Drivers;
using Rimi.Page;
using Rimi.Tools;

namespace Rimi.Test
{
  public class BaseTest
  {
    public static IWebDriver driver;
    public static BasicCheckBoxPage _page;
    public static RimiHomePage _rimiHomePage;
    public static RimiParduotuvePage _rimiParduotuvePage;
    public static RimiEShopPricePage _rimiEShopPricePage;
    public static RimiMilkPricePage _rimiMilkPricePage;


    [OneTimeSetUp]
    public static void SetUp()
    {
      driver = CustomDriver.GetChromeDriver();
      _rimiHomePage = new RimiHomePage(driver);
      _rimiParduotuvePage = new RimiParduotuvePage(driver);
      _rimiEShopPricePage = new RimiEShopPricePage(driver);
      _rimiMilkPricePage = new RimiMilkPricePage(driver);

    }

    [TearDown]
    public static void TakeScreeshot()
    {
      if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        MyScreenshot.MakeScreeshot(driver);
    }

    //[OneTimeTearDown]
    //public static void TearDown()
    //{
    //  driver.Quit();
    //}
  }
}

