using DevHobby.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Tests
{
    [TestClass()]
    public class ProduktTests
    {
        [TestMethod()]
        public void PowiecWitajTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.ProduktId = 1;
            produkt.NazwaProduktu = "Biurko";
            produkt.Opis = "Czerwone biurko";
            produkt.DostawcaProduktu.NazwaFirmy = "DevHobby";
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko Dostępny od : ";

            // ACR (działaj)
            var aktualna = produkt.PowiecWitaj();


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void PowiecWitaj_SparametryzowanyKonstruktorTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt(1, "Biurko", "Czerwone biurko");
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko Dostępny od : ";

            // ACR (działaj)
            var aktualna = produkt.PowiecWitaj();


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }



        [TestMethod()]
        public void ProduktNullTest()
        {
            // Arrange (zaranżuj test)
            Produkt produkt = null;
            string oczekiwana = null;

            // ACR (działaj)
            var aktualna = produkt?.DostawcaProduktu?.NazwaFirmy;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void Konwersja_CaliNaMetrTest()
        {
            // Arrange (zaranżuj test)
            var oczekiwana = 194.35;

            // ACR (działaj)
            var aktualna = 5 * Produkt.CaliNaMetr;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void MinimalnaCena_DomyslnaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            var oczekiwana = 10.50m;

            // ACR (działaj)
            var aktualna = produkt.MinimalnaCena;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void MinimalnaCena_KrzesloTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt(1, "Krzesło obrotowe", "Opis");
            var oczekiwana = 120.99m;

            // ACR (działaj)
            var aktualna = produkt.MinimalnaCena;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void NazwaProduktu_FormatTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.NazwaProduktu = "  Krzesło obrotowe  ";
            var oczekiwana = "Krzesło obrotowe";

            // ACR (działaj)
            var aktualna = produkt.NazwaProduktu;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void NazwaProduktu_ZaKrotkaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krz";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być dłuższa niż 4 znaki";


            // ACR (działaj)
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }


        [TestMethod()]
        public void NazwaProduktu_ZaDlugaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzesło obrotowe zbyt długa nazwa ";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być któtsza niż 30 znaków";


            // ACR (działaj)
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }


        [TestMethod()]
        public void NazwaProduktu_PrawidlowaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzesło obrotowe";
            string oczekiwana = "Krzesło obrotowe";
            string oczekiwanaWiadomosc = null;


            // ACR (działaj)
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }


        [TestMethod()]
        public void Kategoria_wartoscDomyslnaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            string oczekiwana = "Informatyka";

            // ACR (działaj)
            var aktualna = produkt.Kategoria;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void Kategoria_nowaWartoscTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.Kategoria = "Geografia";
            string oczekiwana = "Geografia";

            // ACR (działaj)
            var aktualna = produkt.Kategoria;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void Numer_wartoscDomyslnaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            var oczekiwana = 1;

            // ACR (działaj)
            var aktualna = produkt.Numer;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void Numer_nowaWartoscTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.Numer = 400;
            var oczekiwana = 400;

            // ACR (działaj)
            var aktualna = produkt.Numer;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void KodProduktu_wartoscDomyslnaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            var oczekiwana = "Informatyka - 0001";

            // ACR (działaj)
            var aktualna = produkt.KodProduktu;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }


        [TestMethod()]
        public void KodProduktu_nowaWartoscTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.Kategoria = "Historia";
            produkt.Numer = 10;
            var oczekiwana = "Historia - 0010";

            // ACR (działaj)
            var aktualna = produkt.KodProduktu;


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void ObliczSegurowanaCenaTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt(1, "Biurko", "opis");
            produkt.Koszt = 200m;
            var oczekiwana = 220m;


            // ACR (działaj)
            var aktualna = produkt.ObliczSegurowanaCena(10);


            // Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}