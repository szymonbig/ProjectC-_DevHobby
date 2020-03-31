using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.Common.Tests
{
    [TestClass()]
    public class LogowanieServiceTests
    {
        [TestMethod()]
        public void LogowanieTest()
        {
            //Arrange (zaaranżuj test)
           
            var oczekiwana = "Akcja: Test Akcja";

            //ACT (działaj)
            var aktualna = LogowanieService.Logowanie("Test Akcja");

            //Assert (potwierdź test)
            Assert.AreEqual(oczekiwana, aktualna);
            
        }
    }
}