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
    public static IWebDriver Driver;
    public static RimiHomePage _rimiHomePage;
    public static RimiFrenchShopPage _rimiParduotuvePage;
    public static RimiEShopBreadPage _rimiEShopPricePage;
    public static RimiMilkPricePage _rimiMilkPricePage;
    public static RimiEShopDropDownList _rimiEShopProducList;


    [OneTimeSetUp]
    public static void SetUp()
    {
      Driver = CustomDriver.GetChromeDriver();
      _rimiHomePage = new RimiHomePage(Driver);
      _rimiParduotuvePage = new RimiFrenchShopPage(Driver);
      _rimiEShopPricePage = new RimiEShopBreadPage(Driver);
      _rimiMilkPricePage = new RimiMilkPricePage(Driver);
      _rimiEShopProducList = new RimiEShopDropDownList(Driver);

    }

    [TearDown]
    public static void TakeScreeshot()
    {
      if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        MyScreenshot.MakeScreeshot(Driver);
    }

    [OneTimeTearDown]
    public static void TearDown()
    {
      Driver.Quit();
    }
  }
}

