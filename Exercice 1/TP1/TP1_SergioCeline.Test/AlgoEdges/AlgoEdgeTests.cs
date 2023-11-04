using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class AlgoEdgeTests
    {
        #region TestExeption

        #endregion

        #region CalculGrayScal

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
