using System.Drawing;
using System.Text.Json;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class SobelTests
    {
        private TestConfig testConfig;

        [TestInitialize]
        public void Initialize()
        {
            string json = File.ReadAllText("testImageConfig.json");
            testConfig = JsonSerializer.Deserialize<TestConfig>(json);
        }


        [TestMethod]
        public void Algo_ShouldReturnBitmap()
        {
            string _directoryPath = testConfig.ImageDirectoryPath;

            // Arrange
            Sobel sobel = new Sobel();
            Bitmap initBitmap = new Bitmap($"{_directoryPath}/init.png");
            Bitmap expectedBitmap = new Bitmap($"{_directoryPath}/sobel.png");


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

