using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Rimi.Page
{
  public class RimiEShopBreadPage : BasePage
  {
    
    private IWebElement SearchEShop => Driver.FindElement(By.XPath("//input[@id='search-input' and @name = 'query']"));
    private IWebElement ClickProductsBE => Driver.FindElement(By.XPath("//div[@data-facet-name = 'Produktai BE']"));

    private IWebElement ClickVegetarians => Driver.FindElement(By.XPath("//li[@data-gtm-click-name= 'Tinka vegetarams']"));

    IReadOnlyCollection<IWebElement> VegetarianSelectionGrid => Driver.FindElements(By.CssSelector(".button.-with-right-icon.-cart.gtm.-small"));
    IWebElement firstVegetarianResult => VegetarianSelectionGrid.ElementAt(0).FindElement(By.XPath("//button[@data-gtm-event-category = 'addToBasket']"));
   
    public RimiEShopBreadPage(IWebDriver webdriver) : base(webdriver) { }

    public void EShopSearch(string Text)
    {
      SearchEShop.Click();
      SearchEShop.SendKeys(Text);
      Actions PressEnter = new Actions(Driver);
      PressEnter.SendKeys(Keys.Enter);
      PressEnter.Build().Perform();
    }

    public void VegetarianBread ()
    {
      

      ClickProductsBE.Click();
  
      ClickVegetarians.Click();
      GetWait().Until(ExpectedConditions.StalenessOf(firstVegetarianResult));
      firstVegetarianResult.Click();
    }

    public void AssertBreadPrice (string Price)
    {
      string BreadPrice = Driver.FindElement(By.CssSelector(".button.header__cart.js-header-cart.gtm > span")).Text;
    
      Assert.AreEqual(Price, BreadPrice, "Bread price do not match");

    }



  }
}
