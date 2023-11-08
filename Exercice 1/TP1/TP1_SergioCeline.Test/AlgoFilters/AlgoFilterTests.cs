using System.Drawing;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.Test.AlgoFilters
{
    [TestClass]
    public class ManagerTests
    {
        #region TestExeption
        [TestMethod]
        public void ExecuteAlgo_ThrowArgumentNullException()
        {
            // Arrange
            AlgoFilter algoTest = new Rainbow();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => algoTest.ExecuteAlgo(null), "Please load a picture before");
        }

        #endregion

        #region TestOk
        [TestMethod]
        public void ToString_ReturnTheGoodToString()
        {
            // Arrange
            AlgoFilter algoTest = new Rainbow();

            // Act & Assert
            Assert.AreEqual(algoTest.Text, algoTest.ToString());
        }
        #endregion


    }
}
