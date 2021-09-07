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

  }
}
