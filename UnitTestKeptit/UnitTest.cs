using System;
using KeptitClient.Models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using KeptitClient.Persistency;

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

        //[TestMethod]
        //public void TestSubAreaCollection()
        //{
        //    var sac = PersistencyService.LoadSubAreasAsync();
        //    Assert.AreNotEqual(null, sac.Result);
        //    Assert.AreNotEqual(0, sac.Result.Count);
        //}

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

        [TestMethod]
        public void TestGreenkeeperMinutterPrDagMetode()
        {
            //Arrange
            GreenkeeperMinutterPrDag greenkeeperMinutterPrDag = new GreenkeeperMinutterPrDag();

            greenkeeperMinutterPrDag.Minutterialt = 100;
            greenkeeperMinutterPrDag.Date = new DateTime(2017,5,28);

            //act
          int antalminut =  greenkeeperMinutterPrDag.GivTotalMinutOverarbejde();

            //Assert
            Assert.AreEqual(150,antalminut);
        }



        //[TestMethod]
        //[ExpectedException]
        //public void TestPostFinishedTask()
        //{
        //    try
        //    {
        //        FinishedTask ggg = null;
        //        PersistencyService.PostFinishedtask(ggg);
        //    }
        //    catch (Exception)
        //    {
        //        Assert.Fail();
        //    }
        //}
        #endregion
    }
}
