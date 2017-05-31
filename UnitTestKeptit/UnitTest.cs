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

        [TestMethod]
        public void TestGreenkeeperMinutterPrDagMetode_100_Minutter()
        {
            // Arrange
            GreenkeeperMinutterPrDag greenkeeperMinutterPrDag = new GreenkeeperMinutterPrDag();

            greenkeeperMinutterPrDag.Minutterialt = 100;
            greenkeeperMinutterPrDag.Date = new DateTime(2017, 5, 28);

            // Act
            int antalminut = greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            // Assert
            Assert.AreEqual(150, antalminut);
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
