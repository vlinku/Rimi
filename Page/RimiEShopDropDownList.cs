using NUnit.Framework;
using OpenQA.Selenium;


namespace Rimi.Page
{
 public class RimiEShopDropDownList : BasePage
  {

    private IWebElement ClickProductsDropDown => Driver.FindElement(By.XPath("//a[@aria-controls='desktop_category_menu' and @id ='desktop_category_menu_button']"));
    private IWebElement DropDownFruits => Driver.FindElement(By.XPath("//button[@aria-owns='desktop_category_menu_2']"));
    private IWebElement DropDownFruits2List => Driver.FindElement(By.XPath("//button[@aria-owns='desktop_category_menu_2_1']"));
    private IWebElement DropDownSelectFruit => Driver.FindElement(By.XPath("//a[@role='menuitem' and @class ='trigger' and @href='/e-parduotuve/lt/produktai/vaisiai-darzoves-ir-geles/vaisiai-ir-uogos/bananai/c/SH-15-3-14']"));
    //
   
    private string FruitName => Driver.FindElement(By.CssSelector(".section-header__wrapper > div > a > h3")).Text;

    public RimiEShopDropDownList(IWebDriver webdriver) : base(webdriver) { }

    public void DropDownSelection()
    {
      ClickProductsDropDown.Click();
      DropDownFruits.Click();
      DropDownFruits2List.Click();
      DropDownSelectFruit.Click();

  }

    public void CheckFruitName (string InsertFruitName)
    {
      Assert.AreEqual(InsertFruitName, FruitName, "Asserted fruit name`s do not match");
      //
    }
    
  }

}
