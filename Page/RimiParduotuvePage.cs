using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using System.Collections.Generic;
using System.Linq;


namespace Rimi.Page
{
  public class RimiParduotuvePage : BasePage
  {
    
    private IWebElement ParduotuvesMygtukas => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[4]"));
    private IWebElement ParduotuviuPaieskosLaukas => Driver.FindElement(By.CssSelector(".form-field__input.js-shops-autocomplete.tt-input"));
    private IWebElement ClickAnywhere => Driver.FindElement(By.XPath("//html"));
    

    IReadOnlyCollection<IWebElement> shopResults => Driver.FindElements(By.CssSelector(".shop.js-shop-item"));

    public RimiParduotuvePage(IWebDriver webdriver) : base(webdriver) { }


    public void SelectParduotuves()
    {
      ParduotuvesMygtukas.Click();


    }

    public void IeskotiParduotuves(string text)
    {
      ParduotuviuPaieskosLaukas.Clear();
      ParduotuviuPaieskosLaukas.SendKeys(text);
      Actions PressEnter = new Actions(Driver);
      PressEnter.SendKeys(Keys.Enter);
      PressEnter.Build().Perform();
      
    }

    

    public void CheckShop(string shop)
    {
     // Thread.Sleep(2000);
      ClickAnywhere.Click();
      GetWait().Until(ExpectedConditions.ElementToBeClickable(shopResults.ElementAt(0)));
      IWebElement firstShopResult = shopResults.ElementAt(0);
      string firstShopResultSelected = firstShopResult.FindElement(By.CssSelector(".shop__top > a")).Text;
      Assert.AreEqual(shop, firstShopResultSelected.Replace("„", "").Replace("“", ""), "Shop names do not match");
    }


  }
}
