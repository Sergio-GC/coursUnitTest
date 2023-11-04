using System.Drawing;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.Test.Helper;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class LaplacianTests
    {
        string _directoryPath="images";

        [TestMethod]
        public void ExecuteAlgo_ReturnsResultBitmap()
        {
            // Arrange
            Bitmap initBitmap = new Bitmap($"{_directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{_directoryPath}/Laplacian.png");
            Laplacian laplacian = new Laplacian();

            // Act
            Bitmap resultBitmap = laplacian.ExecuteAlgo(initBitmap);

            // Assert
            Assert.IsNotNull(resultBitmap);
            EqualsHelper.CheckBitmapEquals(expectedBitmap, resultBitmap);

        }
    }
}
