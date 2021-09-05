using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Rimi.Page
{
  public class RimiParduotuvePage : BasePage
  {
    private const string PageAddress = "https://www.rimi.lt/";
    private IWebElement ParduotuvesMygtukas => Driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/ul/li[4]"));
    private IWebElement ParduotuviuPaieskosLaukas => Driver.FindElement(By.CssSelector(".form-field__input.js-shops-autocomplete.tt-input"));



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
    }


  }
}
