using System.Drawing;
using TP1_SergioCeline.AlgoEdges;

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
            Assert.AreEqual(initBitmap.Width, resultBitmap.Width);
            Assert.AreEqual(initBitmap.Height, resultBitmap.Height);

            for (int i = 0; i < expectedBitmap.Width; i++)
            {
                for (int j = 0; j < expectedBitmap.Height; j++)
                {
                    Assert.AreEqual(expectedBitmap.GetPixel(i, j), resultBitmap.GetPixel(i, j));
                }
            }
        }
    }
}

