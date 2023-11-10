using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class AlgoFilterTests
    {
        #region TestExeption
        [TestMethod]
        public void ExecuteAlgo_ThrowArgumentNullException()
        {
            // Arrange
            AlgoEdge algoTest = new Sobel();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => algoTest.ExecuteAlgo(null), "Please load a picture before");
        }

        #endregion

        #region TestOk

        #region TestOk
        [TestMethod]
        public void ToString_ReturnTheGoodToString()
        {
            // Arrange
            AlgoEdge algoTest = new Sobel();

            // Act & Assert
            Assert.AreEqual(algoTest.Text, algoTest.ToString());
        }
        #endregion

        [TestMethod]
        public void CalculGrayScal_ReturnsGrayScaleImage()
        {
            // Arrange
            byte[] pixelBuffer = new byte[] { 100, 150, 200, 255, 50, 100, 150, 255 };
            AlgoEdge algoTest = new Sobel();

            // Act
            byte[] result = algoTest.CalculGrayScal(pixelBuffer);

            // Assert
            Assert.AreEqual(8, result.Length);
            Assert.AreEqual(159, result[0]); //159.5
            Assert.AreEqual(159, result[1]); //159.5
            Assert.AreEqual(159, result[2]); //159.5
            Assert.AreEqual(255, result[3]);

            Assert.AreEqual(109, result[4]); //109.5
            Assert.AreEqual(109, result[5]); //109.5
            Assert.AreEqual(109, result[6]); //109.5
            Assert.AreEqual(255, result[7]);
        }
        #endregion

    }
}
