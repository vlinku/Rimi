using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rimi.Page
{
  public class RimiFrenchShopPage : BasePage
  {
    private IWebElement ShopsButton => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[4]"));
    private IWebElement ShopsSearchField => Driver.FindElement(By.CssSelector(".form-field__input.js-shops-autocomplete.tt-input"));
    private IWebElement ClickAnywhere => Driver.FindElement(By.XPath("//html"));
    IReadOnlyCollection<IWebElement> shopResults => Driver.FindElements(By.CssSelector(".shop.js-shop-item"));

    public RimiFrenchShopPage(IWebDriver webdriver) : base(webdriver) { }

    public void SelectShops()
    {
      ShopsButton.Click();
    }

    public void SearchShops(string text)
    {
      ShopsSearchField.Clear();
      ShopsSearchField.SendKeys(text);
      Actions PressEnter = new Actions(Driver);
      PressEnter.SendKeys(Keys.Enter);
      PressEnter.Build().Perform();
    }

    public void waitToLoad()
    {
      ClickAnywhere.Click();
      WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
      IWebElement firstResult = wait.Until(e => e.FindElement(By.CssSelector(".shop.js-shop-item")));
    }

    public void CheckShop(string shop)
    {
      IWebElement firstShopResult = shopResults.ElementAt(0);
      string firstShopResultSelected = firstShopResult.FindElement(By.CssSelector(".shop__top > a")).Text;
      Assert.AreEqual(shop, firstShopResultSelected.Replace("„", "").Replace("“", ""), "Shop names do not match");
    }

  }
}
