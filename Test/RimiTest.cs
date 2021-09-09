using NUnit.Framework;


namespace Rimi.Test
{
  public class RimiTest : BaseTest
  {

    [Test]

    public static void TestDovanuKortelesTaisykles ()
    {
      _rimiHomePage.NavigateToPage(); 
      _rimiHomePage.CloseCookies();
      _rimiHomePage.PasirinktiDaugiauMygtuka();
      _rimiHomePage.Patikrinti9Taisykle("Dovanų kortelė į pinigus nekeičiama.");
    }
     
   [Test]
   public static void RimiPrancuzuParduotuve ()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiParduotuvePage.SelectParduotuves();
      _rimiParduotuvePage.IeskotiParduotuves("Kaunas");
      _rimiParduotuvePage.CheckShop("Rimi Prancūzų");
      
    }

    [Test]
    public static void RimiProductPrice ()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiHomePage.NavigateToEShop();
      _rimiEShopPricePage.stayOnPage();
     _rimiEShopPricePage.EShopSearch("Pienas");

    }

    [Test]

    public static void RimiMilkPriceCheck ()
    {
      _rimiHomePage.NavigateToPage();
      _rimiHomePage.CloseCookies();
      _rimiMilkPricePage.RimiSearchProductOpen();
      _rimiMilkPricePage.RimiSearch("Pienas");
      _rimiMilkPricePage.MilkSelect();
      _rimiMilkPricePage.FirstMilkSelectionGrid();

    }


  }
}
