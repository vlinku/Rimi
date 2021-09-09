using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Rimi.Page
{
  public class RimiHomePage : BasePage
  {
    private const string PageAddress = "https://www.rimi.lt/";
    private IWebElement cookieButton => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
    private IWebElement SelectDaugiau => Driver.FindElement(By.XPath("//html/body/header/div[1]/div/div/div[2]/ul/li[1]/div"));
    private IWebElement SelectDovanuKortele => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[1]/ul/li[2]"));

    private IWebElement Korteles9Taisykle => Driver.FindElement(By.XPath("/html/body/main/section/div/div/div/ol/li[9]"));

    private IWebElement EShop => Driver.FindElement(By.CssSelector(".header__ecom-link.gtm"));

    public RimiHomePage(IWebDriver webdriver) : base(webdriver) { }

    public void NavigateToPage()
    {
      if (Driver.Url != PageAddress)
        Driver.Url = PageAddress;

    }

    public void CloseCookies()
    {
      GetWait().Until(ExpectedConditions.ElementIsVisible(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));
      cookieButton.Click();
    }

    
    public void Patikrinti9Taisykle(string result)
    {
      Assert.IsTrue(Korteles9Taisykle.Text.Contains(result) , "Rule is incorrect!");
    }
    public void PasirinktiDaugiauMygtuka()
    {
      SelectDaugiau.Click();
      SelectDovanuKortele.Click();
    }

    public void NavigateToEShop() 
    {
      EShop.Click(); 
    }

  }
}
