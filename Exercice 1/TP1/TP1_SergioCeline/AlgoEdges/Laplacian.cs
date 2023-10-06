namespace TP1_SergioCeline.AlgoEdges
{
    public class Laplacian : AlgoEdge
    {
        private double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }
        public Laplacian() : base("Laplacian 5x5 of Gaussian 5x5") { }
        public override Bitmap algo(Bitmap init)
        {
            Bitmap resultBitmap = ConvolutionFilterX(init,
                                    Laplacian3x3, 1.0, 0, true);

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
    public class LaplacianTests
    {
        [Test]
        public void Algo_WithValidBitmap_ReturnsResultBitmap()
        {
            // Arrange
            Bitmap initBitmap = new Bitmap(10, 10);
            Laplacian laplacian = new Laplacian();

            // Act
            Bitmap resultBitmap = laplacian.algo(initBitmap);

            // Assert
            Assert.IsNotNull(resultBitmap);
            Assert.AreEqual(initBitmap.Width, resultBitmap.Width);
            Assert.AreEqual(initBitmap.Height, resultBitmap.Height);
        }
    }
}