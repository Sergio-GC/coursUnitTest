using System.Drawing;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.Test.Helper;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class PrewittTests
    {

        string _directoryPath = "images";

        [TestMethod]
        public void ExecuteAlgo_ReturnsResultBitmap()
        {
            // Arrange
            Prewitt prewitt = new Prewitt();
            Bitmap initBitmap = new Bitmap($"{_directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{_directoryPath}/prewitt.png");

            // Act
            Bitmap resultBitmap = prewitt.ExecuteAlgo(initBitmap);

            // Assert
            Assert.IsNotNull(resultBitmap);
            EqualsHelper.CheckBitmapEquals(expectedBitmap, resultBitmap);
        }
    }
}

