using System;
using KeptitClient.Models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using KeptitClient.Persistency;
using KeptitClient.Models;
using KeptitClient.ViewModels;

namespace UnitTestKeptIt
{
    [TestClass]
    public class UnitTest1
    {
        //tjekker om ting1 = ting2
        //Assert.AreEqual(ting1, ting2);

        //hvis det fejler så består den unit-testen.
        //Assert.Fail()
        #region PersistencyServiceTests
        [TestMethod]
        public void TestGreenkeeperCollection()
        {
            var gkc = PersistencyService.LoadGreenkeeperAsync();
            Assert.AreNotEqual(null, gkc.Result);
            Assert.AreNotEqual(0, gkc.Result.Count);
        }

        [TestMethod]
        public void TestAreaCollection()
        {
            var ac = PersistencyService.LoadAreasAsync();
            Assert.AreNotEqual(null, ac.Result);
            Assert.AreNotEqual(0, ac.Result.Count);
        }

        [TestMethod]
        public void TestGreenTaskCollection()
        {
            var gtc = PersistencyService.LoadGreenTaskAsync();
            Assert.AreNotEqual(null, gtc.Result);
            Assert.AreNotEqual(0, gtc.Result.Count);
        }

        [TestMethod]
        public void TestFinishedTaskCollection()
        {
            var ftc = PersistencyService.LoadFinishedtaskAsync();
            Assert.AreNotEqual(null, ftc.Result);
            Assert.AreNotEqual(0, ftc.Result.Count);
        }


        #endregion

        #region GreenkeeperMinutterPrDagTests
        // Instantiere klassen GreenkeeperMinutterPrDag så den ikke skal skrives i hver testmetode.
        GreenkeeperMinutterPrDag greenkeeperMinutterPrDag = new GreenkeeperMinutterPrDag();

        // test 100 minutter lørdag i metoden GivTotalMinutOverarbejde
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Overarbejde_Metode_Loerdag()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 100;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 27);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            // Assert
            Assert.AreEqual(150, antalminut);
        }

        // test 100 minutter søndag i metoden GivTotalMinutOverarbejde
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Overarbejde_Soendag()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 444;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 28);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            // Assert
            Assert.AreEqual(666, antalminut);
        }

        // test 444 minutter mandag i metoden GivTotalMinutOverarbejde. Giver 0 fordi 444 er 7.4 timer og ikke overarbejde.
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Overarbejde_Mandag()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 444;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 29);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            // Assert
            Assert.AreEqual(0, antalminut);
        }

        // test 445 minutter mandag i metoden GivTotalMinutOverarbejde. Giver 1 fordi 445 er 7.416 timer og giver 1 minut i overarbejde.
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Overarbejde_Mandag2()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 445;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 29);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            // Assert
            Assert.AreEqual(1, antalminut);
        }

        // test 444 minutter mandag i metoden GivTotalMinutNormal. Giver det samme antal minutter.
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Normal_Mandag()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 444;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 29);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutNormal();

            // Assert
            Assert.AreEqual(444, antalminut);
        }

        // test 445 minutter mandag i metoden GivTotalMinutNormal. Giver max 444 minutter ellers er det overarbejde og ryger ind i den anden metode først.
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Normal_Mandag2()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 445;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 29);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutNormal();

            // Assert
            Assert.AreEqual(444, antalminut);
        }

        // test 0 minutter mandag i metoden GivTotalMinutNormal.
        [TestMethod]
        public void TestGreenkeeperMinutterPrDag_Normal_Mandag3()
        {
            // Arrange
            greenkeeperMinutterPrDag.Minutterialt = 0;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 29);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutNormal();

            // Assert
            Assert.AreEqual(0, antalminut);
        }




        [TestMethod]
        public void TestGivTotalMinutOverarbejde() // 
        {
            // arrange
            GreenkeeperInfo overArbejde = new GreenkeeperInfo(14, 48); // 888 minutter ialt

            // act
            int actualValue = overArbejde.GivTotalMinutOverarbejde();
        
            // assert
            Assert.AreEqual(666, actualValue);
        }

        #endregion
    }
}
