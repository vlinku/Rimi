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
  public class RimiEShopPricePage : BasePage
  {
    private const string PageAddress = "https://www.rimi.lt/e-parduotuve";

    
    private IWebElement SearchEShop => Driver.FindElement(By.CssSelector(".js-search-header"));

    

    public RimiEShopPricePage(IWebDriver webdriver) : base(webdriver) { }

    //public void NavigateToPage()
    //{
    //  if (Driver.Url != PageAddress)
    //    Driver.Url = PageAddress;

    //}

    public void stayOnPage()
    {
      Driver.SwitchTo().Window(PageAddress);
    }

    // sukurti atskira metoda, kuris ateina tik i kita puslapi. Tada kai ateina, tada jau kurti nauja metoda, kuris klikins search ir t.t.



    public void EShopSearch(string text)
    {

      SearchEShop.Click();
      //SearchEShop.Clear();
      //SearchEShop.SendKeys(text);
      //Actions PressEnter = new Actions(Driver);
      //PressEnter.SendKeys(Keys.Enter);
      //PressEnter.Build().Perform();

    }


  }
}
