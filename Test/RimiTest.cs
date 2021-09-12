using NUnit.Framework;


namespace Rimi.Test
{
  public class RimiTest : BaseTest
  {

    [Test]

    public static void TestGiftCardRule()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiHomePage.CheckButtonExpandMenu();
      _rimiHomePage.Check9Rule("Dovanų kortelė į pinigus nekeičiama.");
    }

    [Test]
    public static void RimiFrenchShopTest()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiParduotuvePage.SelectShops();
      _rimiParduotuvePage.SearchShops("Kaunas");
      _rimiParduotuvePage.CheckShop("Rimi Prancūzų");
    }

    [Test]
    public static void RimiEShopBreadTest()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiHomePage.NavigateToEShop();
      _rimiEShopPricePage.EShopSearch("Duona");
      _rimiEShopPricePage.VegetarianBread();
      _rimiEShopPricePage.AssertBreadPrice("1,69 €");

    }

    [Test]
    public static void RimiMilkPriceTest()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiMilkPricePage.RimiSearchProductOpen();
      _rimiMilkPricePage.RimiSearch("Pienas");
      _rimiMilkPricePage.MilkSelect();
      _rimiMilkPricePage.FirstMilkSelectionGrid();
      _rimiMilkPricePage.checkPrice(2, 100);
    }

    [Test]
    public static void RimiEShopDropDownListTest()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiHomePage.NavigateToEShop();
      _rimiEShopProducList.DropDownSelection();
      _rimiEShopProducList.CheckFruitName("Bananai");

    }


  }
}
