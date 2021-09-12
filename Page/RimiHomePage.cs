using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Rimi.Page
{
  public class RimiHomePage : BasePage
  {
    private const string PageAddress = "https://www.rimi.lt/";
    private IWebElement SelectExpandMenu => Driver.FindElement(By.XPath("//html/body/header/div[1]/div/div/div[2]/ul/li[1]/div"));
    private IWebElement SelectGiftCard => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[1]/ul/li[2]"));

    private IWebElement Cards9Rule => Driver.FindElement(By.XPath("/html/body/main/section/div/div/div/ol/li[9]"));

    private IWebElement EShop => Driver.FindElement(By.CssSelector(".header__ecom-link.gtm"));

    public RimiHomePage(IWebDriver webdriver) : base(webdriver) { }

    public void NavigateToPage()
    {
      if (Driver.Url != PageAddress)
        Driver.Url = PageAddress;

    }

    public void CloseCookies()
    {
      Cookie myCookie = new Cookie("CookieConsent", 
        "{stamp:%27AiTpWRI9P6CvNrDXXdPvcUgT54mwMgkxVW8roehFL1tEQq6Cs3z/ow==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:6%2Cutc:1631444204870%2Cregion:%27lt%27}",
        "www.rimi.lt", 
        "/", 
        DateTime.Now.AddDays(7));
      Driver.Manage().Cookies.AddCookie(myCookie);
      Driver.Navigate().Refresh();
    }
    
    public void Check9Rule(string result)
    {
      Assert.IsTrue(Cards9Rule.Text.Contains(result) , "Rule is incorrect!");
    }

    public void CheckButtonExpandMenu()
    {
      SelectExpandMenu.Click();
      SelectGiftCard.Click();
    }

    public void NavigateToEShop() 
    {
      EShop.Click();
      Driver.SwitchTo().Window(Driver.WindowHandles[1]);
    }

  }
}
