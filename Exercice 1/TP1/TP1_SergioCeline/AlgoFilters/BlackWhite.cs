using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.AlgoFilters
{
    public class BlackWhite : AlgoFilter
    {
        public BlackWhite() : base("Black & White") { }
        public override Bitmap algo(Bitmap image)
        {

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    int colorAvg = (int)((color.R + color.G + color.B) / 3);
                    image.SetPixel(x, y, Color.FromArgb(colorAvg, colorAvg, colorAvg));
                }
            }

            return image;
        }
    }
}



using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.UnitTests
{
    [TestClass]
    public class BlackWhiteTests
    {
        [TestMethod]
        public void BlackWhite_Algo_ReturnsBlackAndWhiteImage()
        {
            // Arrange
            Bitmap image = new Bitmap(2, 2);
            image.SetPixel(0, 0, Color.FromArgb(255, 0, 0)); // Red
            image.SetPixel(1, 0, Color.FromArgb(0, 255, 0)); // Green
            image.SetPixel(0, 1, Color.FromArgb(0, 0, 255)); // Blue
            image.SetPixel(1, 1, Color.FromArgb(255, 255, 255)); // White

            BlackWhite blackWhite = new BlackWhite();

            // Act
            Bitmap result = blackWhite.algo(image);

            // Assert
            Assert.AreEqual(Color.FromArgb(85, 85, 85), result.GetPixel(0, 0)); // Dark gray
            Assert.AreEqual(Color.FromArgb(85, 85, 85), result.GetPixel(1, 0)); // Dark gray
            Assert.AreEqual(Color.FromArgb(85, 85, 85), result.GetPixel(0, 1)); // Dark gray
            Assert.AreEqual(Color.FromArgb(255, 255, 255), result.GetPixel(1, 1)); // White
        }
    }
}