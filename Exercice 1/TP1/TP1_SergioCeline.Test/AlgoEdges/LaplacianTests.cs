using System.Drawing;
using System.Text.Json;
using TP1_SergioCeline.AlgoEdges;
using static TP1_SergioCeline.Test.AlgoEdges.LaplacianTests;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class LaplacianTests
    {
        private TestConfig testConfig;

        [TestInitialize]
        public void Initialize()
        {
            string json = File.ReadAllText("testImageConfig.json");
            testConfig = JsonSerializer.Deserialize<TestConfig>(json);
        }


        [TestMethod]
        public void Algo_WithValidBitmap_ReturnsResultBitmap()
        {
            string _directoryPath = testConfig.ImageDirectoryPath;

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
