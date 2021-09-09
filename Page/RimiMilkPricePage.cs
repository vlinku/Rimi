using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    
    private IWebElement EurosPrice => Driver.FindElement(By.XPath("//*[@id='main']/section/div[1]/div/div[2]/section[1]/div/div[1]/div[2]/div[1]/div[1]/span"));
    private IWebElement EuroCentsPrice => Driver.FindElement(By.XPath("//*[@id='main']/section/div[1]/div/div[2]/section[1]/div/div[1]/div[2]/div[1]/div[1]/div/sup"));
    
    
    // //input[contains(@class, 'form-field__input')] - Xpath class ;  //input[@id='email'] - Xpath id;  //input[@name='email'] - name;
    
    
    public RimiMilkPricePage(IWebDriver webdriver) : base(webdriver) { }

    public void RimiSearchProductOpen ()
    {
      RimiOpenSearch.Click();
    }
    
    public void RimiSearch (string text)
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
      firstSelectionResult.Click();
    }


    //public void checkPrice() 
    //{
    //  Assert.IsTrue(EurosPrice && EuroCentsPrice  , firstShopResultSelected, "Shop names do not match"); 
    //} 
    

  }
}
