using System.Drawing;
using System.Windows.Forms;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class SobelTests
    {

        string directoryPath = "D:\\Ecole\\semestre7\\TestUnitaire\\Exercices\\Exercice 1\\TP1\\TP1_SergioCeline.Test\\images\\";

        [TestMethod]
        [DeploymentItem(@"images/init.png")]
        [DeploymentItem(@"images/sobel.png")]
        public void Algo_ShouldReturnBitmap()
        {
            // Arrange
            Sobel sobel = new Sobel();
            Bitmap initBitmap = new Bitmap($"{directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{directoryPath}/sobel.png");

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

