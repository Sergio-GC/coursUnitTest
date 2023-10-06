using System.Drawing;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class SobelTests
    {
        [TestMethod]
        public void Algo_ShouldReturnBitmap()
        {
            // Arrange
            Sobel sobel = new Sobel();
            Bitmap initBitmap = new Bitmap(10, 10);
            Bitmap expectedBitmap = new Bitmap(10, 10);

            // Act
            Bitmap resultBitmap = sobel.algo(initBitmap);

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

