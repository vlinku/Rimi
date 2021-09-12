using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Rimi.Page
{
  public class RimiMilkPricePage : BasePage
  {
    private IWebElement RimiOpenSearch => Driver.FindElement(By.CssSelector(".header-search__toggle.js-header-search-toggle.gtm"));
    private IWebElement RimiSearchMilk => Driver.FindElement(By.Id("header_search_query"));
    IReadOnlyCollection<IWebElement> MilkResults => Driver.FindElements(By.CssSelector(".search-results__item"));
    IWebElement firstResult => MilkResults.ElementAt(0).FindElement(By.CssSelector(".search-results__link"));

    IReadOnlyCollection<IWebElement> MilkSelectionGrid => Driver.FindElements(By.CssSelector(".product-grid__item"));
    IWebElement firstSelectionResult => MilkSelectionGrid.ElementAt(0).FindElement(By.CssSelector(".card__url.js-gtm-eec-product-click"));

    private string EurosPrice => Driver.FindElement(By.CssSelector(".price > span")).Text;
    private string EuroCentsPrice => Driver.FindElement(By.CssSelector(".price > div > sup")).Text;


    public RimiMilkPricePage(IWebDriver webdriver) : base(webdriver) { }

    public void RimiSearchProductOpen()
    {
      RimiOpenSearch.Click();
    }

    public void RimiSearch(string text)
    {
      RimiSearchMilk.Clear();
      RimiSearchMilk.SendKeys(text);
      Actions PressEnter = new Actions(Driver);
      PressEnter.SendKeys(Keys.Enter);
      PressEnter.Build().Perform();
    }

    public void MilkSelect()
    {
      firstResult.Click();
    }

    public void FirstMilkSelectionGrid()
    {
      GetWait().Until(ExpectedConditions.ElementToBeClickable(firstSelectionResult));
      firstSelectionResult.Click();
    }

    public void checkPrice(int Euro, int Cents)
    {
      Assert.IsTrue(Euro > Int32.Parse(EurosPrice), "Euro price do not match");
      Assert.IsTrue(Cents > Int32.Parse(EuroCentsPrice), "Euro cents price do not match");
    }


  }
}
