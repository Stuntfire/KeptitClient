using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestKeptit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //tjekker om ting1 = ting2
            //Assert.AreEqual(ting1, ting2);

            //hvis det fejler så består den unit-testen.
            //Assert.Fail()
        }
    }
}
