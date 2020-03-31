using System;

namespace DevHobby.Common
{
    //klasa zapewnia logowanie
     

    public static class LogowanieService
    {
        //Loguje akce
        //akcja=akcja do logowania

        public static string Logowanie(string akcja)
        {
            var tekstDoZalogowania = "Akcja: " + akcja;
            Console.WriteLine(tekstDoZalogowania);

            return tekstDoZalogowania;       

        }
    }
}
