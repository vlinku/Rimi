using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Rimi.Page
{
  public class RimiParduotuvePage : BasePage
  {
    private const string PageAddress = "https://www.rimi.lt/";
    private IWebElement ParduotuvesMygtukas => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[4]"));
    private IWebElement ParduotuviuPaieskosLaukas => Driver.FindElement(By.CssSelector(".form-field__input.js-shops-autocomplete.tt-input"));
    private IWebElement ClickAnywhere => Driver.FindElement(By.XPath("//html"));
    IReadOnlyCollection<IWebElement> shopResults => Driver.FindElements(By.CssSelector(".shop__name.js-shop-map-link"));

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
      Thread.Sleep(2000);
      IWebElement firstShopResult = shopResults.ElementAt(0);
      //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      ClickAnywhere.Click();
      // WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
      //firstShopResult = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".shop__name.js-shop-map-link")));
      string firstShopResultSelected = firstShopResult.FindElement(By.CssSelector(".shop__name.js-shop-map-link")).Text;
      Assert.AreEqual(shop, firstShopResultSelected, "Shop names do not match");
    }

  }
}
