using NUnit.Framework;
using System.Drawing;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class LaplacianTests
    {
        [TestMethode]
        public void Algo_WithValidBitmap_ReturnsResultBitmap()
        {
            // Arrange
            Bitmap initBitmap = new Bitmap(10, 10);
            Bitmap expectedBitmap = new Bitmap(10, 10);
            Laplacian laplacian = new Laplacian();

            // Act
            Bitmap resultBitmap = laplacian.algo(initBitmap);

            // Assert
            Assert.IsNotNull(resultBitmap);
            Assert.AreEqual(initBitmap.Width, resultBitmap.Width);
            Assert.AreEqual(initBitmap.Height, resultBitmap.Height);

            for (int i = 0; i < expectedBitmap.Width; i++)
            {
                for (int j = 0; j < expectedBitmap.Height; j++)
                {
                    Assert.AreEqual(expectedBitmap.Scan0[i, j], resultBitmap.Scan0[i, j]);
                }
            }

        }
    }
}
