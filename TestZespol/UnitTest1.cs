using Zespol;

namespace TestZespol
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKonstruktorZespolu()
        {
            KierownikZespolu kierownik = new();
            string nazwa = "Grupa IT";
            //Act
            Zespol.Zespol zespol = new(nazwa,kierownik);
            //Assert
            Assert.AreEqual(nazwa, zespol.NazwaZespolu);
        }
        [TestMethod]
        public void TestKonstruktorZespolu2()
        {
            Zespol.Zespol zespol = new();
            Assert.IsNotNull(zespol.CzlonkowieZespolu);
        }
        [TestMethod]
        public void TestWtyjatkuDlaPesela()
        {
            CzlonekZespolu cz = new();
            Assert.ThrowsException<PeselException>(() => cz.Pesel = "4567");
        }
        [TestMethod]
        public void TestEqualsOsoba()
        {
            CzlonekZespolu cz = new() { Pesel = "11111111111" };
            CzlonekZespolu cz2 = cz.Clone() as CzlonekZespolu;
            Assert.AreEqual(cz, cz2);
        }
    }
}