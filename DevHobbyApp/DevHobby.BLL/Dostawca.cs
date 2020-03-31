using DevHobby.Common;
using System;
using System.Text;

namespace DevHobby.BLL
{
    /// <summary>
    /// Zarządza dostawcami od których kupujemy produkty
    /// </summary>
    

    public class Dostawca
    {
        public enum DolaczAdres { Tak, Nie };
        public enum WyslijKopie { Tak, Nie };

        #region Pola i właściwości
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }

        #endregion
       
        #region Metody
        /// <summary>
        /// Wysyła wiadomość email aby powitać nowego dostawce
        /// </summary>
        /// <param name="wiadomosc">Wiadomość do wysłania</param>
        /// <returns></returns>
        public string WyslijEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailService();
            var temat = ("Witaj " + this.NazwaFirmy).Trim();
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;
        }
                      

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>        
        /// <param name="ilosc">Ilość produktu do zamówienia</param>
        /// <param name="data">Data dostawy zamówienia</param>
        /// <param name="instukcje">Instrukcje dostawy</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data = null, string instukcje = "Standardowa dostawa")
        {
            if (produkt == null)
                throw new ArgumentNullException(nameof(produkt));       //wyrzucenie wyjątku

            if (ilosc <= 0)
                throw new ArgumentOutOfRangeException(nameof(ilosc));

            if (data <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(data));

            var sukces = false;

            var tekstZamowieniaBuilder = new StringBuilder("Zamówienie z DevHobby.pl" + Environment.NewLine +
                                                           "Produkt: " + produkt.KodProduktu + Environment.NewLine +
                                                           "Ilość: " + ilosc);

            if (data.HasValue)                                              //zwraca false gdy data ma wartośc null
            {
                tekstZamowieniaBuilder.Append(Environment.NewLine + "Data dostawy: " + data.Value.ToString("d"));   //ten format ustawia że chce dostać tylko date bez godziny
            }

            if (!String.IsNullOrWhiteSpace(instukcje))                       //sprawdza czy nie ma spacji albo czy string nie jest nullem 
            {
                tekstZamowieniaBuilder.Append(Environment.NewLine + "Instrukcje: " + instukcje);
            }

            var tekstZamowienia = tekstZamowieniaBuilder.ToString();

            var emailService = new EmailService();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadmość wysłana: "))
                sukces = true;

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }


        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość produktu do zamówienia</param>
        /// <param name="dolaczAdres">True, jeśli zawiera adres wysyłki</param>
        /// <param name="wyslijKopie">True, jeśli wysyłamy kopie wiadomości email</param>
        /// <returns>Flaga sukcesu i tekst zamówienia</returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DolaczAdres dolaczAdres, WyslijKopie wyslijKopie)
        {
            var tekstZamowienia = "Tekst zamówienia";

            if (dolaczAdres == DolaczAdres.Tak)
                tekstZamowienia += " Dołączamy adres";

            if (wyslijKopie == WyslijKopie.Tak)
                tekstZamowienia += " Wysyłamy kopię";

            var wynikOperacji = new WynikOperacji(true, tekstZamowienia);
            return wynikOperacji;
        }


        public override string ToString()
        {
            string dostawcaInfo = "Dostawca: " + this.NazwaFirmy; ;

            //jeżeli jest znak "?" to gdy wartość dostawcaInfo jest null do nie wykonuję się instrukcja .ToLower(); tylko odrazu zwraca wartość null do zmiennej wynik
            
            string wynik = dostawcaInfo?.ToLower();
            wynik = dostawcaInfo?.ToUpper();
            wynik = dostawcaInfo?.Replace("Dostawca", "Odbiorca");

            var dlugosc = dostawcaInfo?.Length;
            var index = dostawcaInfo?.IndexOf(":");
            var start = dostawcaInfo?.StartsWith("Dosta");
            var stop = dostawcaInfo?.EndsWith("ca");
            var trim = dostawcaInfo?.Trim();

            //if (!String.IsNullOrWhiteSpace(dostawcaInfo))         //tutaj sprawdzał czy nie jest nullem albo nie ma spracji
            //{
            //    string wynik = dostawcaInfo.ToLower();
            //    wynik = dostawcaInfo.ToUpper();
            //    wynik = dostawcaInfo.Replace("Dostawca", "Odbiorca");

            //    var dlugosc = dostawcaInfo.Length;
            //    var index = dostawcaInfo.IndexOf(":");
            //    var start = dostawcaInfo.StartsWith("Dosta");
            //    var stop = dostawcaInfo.EndsWith("ca");
            //    var trim = dostawcaInfo.Trim();
            //}

            return dostawcaInfo;
        }


        public string ZwrocTekst()
        {
            var tekst = @"Wstawiam \r\n nowa linia";
            return tekst;
        }


        public string ZwrocTekstDwieLinie()
        {
            var tekst = "Pierwsza linia" + Environment.NewLine + 
                "Druga linia";
            var tekst2 = "Pierwsza linia\r\nDruga linia";

            var tekst3 = @"Pierwsza linia
Druga linia";
            
            return tekst;
        }

        #endregion
    }
}
