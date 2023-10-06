namespace TP1_SergioCeline.AlgoEdges
{
    public class Sobel : AlgoEdge
    {
        private double[,] Sobel3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -2,  0,  2, },
                  { -1,  0,  1, }, };
            }
        }

        private double[,] Sobel3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                  {  0,  0,  0, },
                  { -1, -2, -1, }, };
            }
        }
        public Sobel() : base("Sobel") { }
        public override Bitmap algo(Bitmap init)
        {
            Bitmap resultBitmap = ConvolutionFilterXY(init,
                                                 Sobel3x3Horizontal,
                                                   Sobel3x3Vertical,
                                                        1.0, 0, true);

            return resultBitmap;
        }
    }
}

using NUnit.Framework;
using System.Drawing;
using TP1_SergioCeline.AlgoEdges;

namespace TP1_SergioCeline.UnitTests
{
    [TestFixture]
    public class SobelTests
    {
        [Test]
        public void Algo_ShouldReturnBitmap()
        {
            // Arrange
            Sobel sobel = new Sobel();
            Bitmap init = new Bitmap(100, 100);

            // Act
            Bitmap result = sobel.algo(init);

            // Assert
            Assert.IsInstanceOf<Bitmap>(result);
        }
    }
}