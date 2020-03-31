using DevHobby.BLL;
using DevHobby.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevHobby.BLL.Tests
{
    [TestClass()]
    public class DostawcaTests
    {
        [TestMethod()]
        public void ZlozZamowienieTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt: Informatyka - 0001\r\nIlość: 15\r\nInstrukcje: Standardowa dostawa");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15);


            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Widomosc, wartoscAktualna.Widomosc);
        }


        [TestMethod()]
        public void ZlozZamowienie3parametryTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt: Informatyka - 0001\r\nIlość: 15\r\nData dostawy: 2020-04-22\r\nInstrukcje: Standardowa dostawa");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2020, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)));


            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Widomosc, wartoscAktualna.Widomosc);
        }


        [TestMethod()]
        public void ZlozZamowienie4parametryTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt: Informatyka - 0001\r\nIlość: 15\r\nData dostawy: 2020-04-22\r\nInstrukcje: testowe instrukcje");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2020, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)), "testowe instrukcje");


            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Widomosc, wartoscAktualna.Widomosc);
        }


        [TestMethod()]
        public void ZlozZamowienieBrakDatyTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt: Informatyka - 0001\r\nIlość: 15\r\nInstrukcje: testowe instrukcje");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, instukcje: "testowe instrukcje");


            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Widomosc, wartoscAktualna.Widomosc);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZlozZamowienie_NullProdukt_ExceptionTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var wartoscOczekiwana = true;

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(null, 15);


            // Assert (potwierdź test)
            // oczekiwany wyjątek
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZlozZamowienie_Ilosc_ExceptionTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = true;

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 0);


            // Assert (potwierdź test)
            // oczekiwany wyjątek
        }


        [TestMethod()]
        public void ZlozZamowienie_DolaczAdresTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Tekst zamówienia Dołączamy adres");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, Dostawca.DolaczAdres.Tak, Dostawca.WyslijKopie.Nie);


            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Widomosc, wartoscAktualna.Widomosc);
        }


        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            dostawca.DostawcaId = 2;
            dostawca.NazwaFirmy = "DevHobby";
            var wartoscOczekiwana = "Dostawca: DevHobby";

            //ACT (działaj)
            var wartoscAktualna = dostawca.ToString();


            // Assert (potwierdź test)            
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }


        [TestMethod()]
        public void ZwrocTekstTest()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();            
            var wartoscOczekiwana = @"Wstawiam \r\n nowa linia";

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZwrocTekst();
            Console.WriteLine(wartoscAktualna);

            // Assert (potwierdź test)            
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }
    }
}


namespace DevHobby.BLL.Testy
{
    [TestClass]
    public class DostawcaTests
    {
        [TestMethod]
        public void WyslijEmailWitamy_PrawidłowaNazwaFirmy_Sukces()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "DevHobby";
            var wartoscOczekiwana = "Wiadmość wysłana: Witaj DevHobby";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);

        }


        [TestMethod]
        public void WyslijEmailWitamy_PustaNazwaFirmy_Sukces()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "";
            var wartoscOczekiwana = "Wiadmość wysłana: Witaj";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);

        }


        [TestMethod]
        public void WyslijEmailWitamy_NullNazwaFirmy_Sukces()
        {
            //Arrange (zaranzuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = null;
            var wartoscOczekiwana = "Wiadmość wysłana: Witaj";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdź test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);

        }
    }
}
