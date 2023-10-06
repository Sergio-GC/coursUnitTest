using System.Drawing;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class LaplacianTests
    {
        string _directoryPath = "D:\\Ecole\\semestre7\\TestUnitaire\\Exercices\\Exercice 1\\TP1\\TP1_SergioCeline.Test\\images\\";

        [TestMethod]
        public void Algo_WithValidBitmap_ReturnsResultBitmap()
        {
            // Arrange
            Bitmap initBitmap = new Bitmap($"{_directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{_directoryPath}/Laplacian.png");
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
                    Assert.AreEqual(expectedBitmap.GetPixel(i, j), resultBitmap.GetPixel(i, j));
                }
            }

        }
    }
}
