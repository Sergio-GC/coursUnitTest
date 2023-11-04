using System.Drawing;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.Test.Helper;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class SobelTests
    {

        string _directoryPath = "images";

        [TestMethod]
        public void ExecuteAlgo_ReturnsResultBitmap()
        {
            // Arrange
            Sobel sobel = new Sobel();
            Bitmap initBitmap = new Bitmap($"{_directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{_directoryPath}/sobel.png");

            // Act
            Bitmap resultBitmap = sobel.ExecuteAlgo(initBitmap);

            // Assert
            Assert.IsNotNull(resultBitmap);
            EqualsHelper.CheckBitmapEquals(expectedBitmap, resultBitmap);
        }
    }
}

