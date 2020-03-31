

namespace DevHobby.Common
{
    public class EmailService
    {
        //
        //Wysyła wiadomość email
        //

       //temat = Temat wiadomości 
       //wiasomosc = Wiadomość tekstowa 
       //odbiorca = adres email dobiorcy wiadomości 


        public string WyslijWiadomosc(string temat, string wiadomosc, string odbiorca)
        {
            //kod, aby wysłać wiadomość email

            var potwierdzenie = "Wiadmość wysłana: " + temat;            
            LogowanieService.Logowanie(potwierdzenie);

            return potwierdzenie;
        }
    }
}
