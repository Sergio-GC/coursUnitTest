using System.Drawing;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.Test.AlgoFilters
{
    [TestClass]
    public class BlackWhiteTest
    {
        [TestMethod]
        public void Algo_Normal()
        {
            string initFileName = "init.png";
            string expectedFileName = "blacWhite.png";
            
            StreamReader initstreamReader = new StreamReader(initFileName);
            StreamReader expectedStreamReader = new StreamReader(expectedFileName);
            
            Bitmap init = new Bitmap(initstreamReader.BaseStream);
            Bitmap expected = new Bitmap(expectedStreamReader.BaseStream); 

            Bitmap actual =  (new BlackWhite()).algo(init);
            Assert.AreEqual(expected, actual);
        }
    }
}