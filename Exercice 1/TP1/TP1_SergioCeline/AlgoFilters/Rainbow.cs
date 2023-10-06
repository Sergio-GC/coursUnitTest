using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.AlgoFilters
{
    public class Rainbow : AlgoFilter
    {
        public Rainbow() : base("Rainbow") { }

        public override Bitmap algo(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int raz = image.Width / 5;
            for (int x = 0; x < image.Width; x++)
            {
                // Dividers for the colors
                var dividers = GetDividers(x, raz);

                for (int y = 0; y < image.Height; y++)
                {
                    // rgb values from the current pixels
                    byte red = image.GetPixel(x, y).R;
                    byte green = image.GetPixel(x, y).G;
                    byte blue = image.GetPixel(x, y).B;

                    // Change the colors
                    result.SetPixel(x, y, Color.FromArgb(red / dividers.red, green / dividers.green, blue / dividers.green));
                }

            }
            return result;
        }

        /// <summary>
        /// Calculates the values to divide the rgb colors of an image in order to apply a rainbow filter.
        /// </summary>
        /// <param name="horizontalPixel">Position of the current pixel horizontally (by the width)</param>
        /// <param name="sideWidth">Width of each side to determine in which size is the pixel</param>
        /// <returns>Red, green and blue variables containing the division value</returns>
        private (int red, int green, int blue) GetDividers(int horizontalPixel, float sideWidth)
        {
            // By default, dividers are equal to 1
            int red = 1, green = 1, blue = 1;
            int currentArea = (int)(horizontalPixel / sideWidth);

            // Calculate the dividers in function of the current position
            switch (currentArea)
            {
                case 0:
                    red = 5;
                    break;
                case 1:
                    green = 5;
                    break;
                case 2:
                    blue = 5;
                    break;
                case 3:
                    red = blue = 5;
                    break;
                default:
                    red = green = blue = 5;
                    break;
            }

            return (red, green, blue);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.UnitTests
{
    [TestClass]
    public class RainbowTests
    {
        [TestMethod]
        public void Rainbow_Algo_ReturnsCorrectImage()
        {
            // Arrange
            Rainbow rainbowFilter = new Rainbow();
            Bitmap image = new Bitmap(100, 100);

            // Act
            Bitmap result = rainbowFilter.algo(image);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(image.Width, result.Width);
            Assert.AreEqual(image.Height, result.Height);
        }

        [TestMethod]
        public void GetDividers_ReturnsCorrectDividers()
        {
            // Arrange
            Rainbow rainbowFilter = new Rainbow();

            // Act
            var dividers1 = rainbowFilter.GetDividers(10, 20);
            var dividers2 = rainbowFilter.GetDividers(30, 20);
            var dividers3 = rainbowFilter.GetDividers(50, 20);
            var dividers4 = rainbowFilter.GetDividers(70, 20);
            var dividers5 = rainbowFilter.GetDividers(90, 20);

            // Assert
            Assert.AreEqual(1, dividers1.red);
            Assert.AreEqual(1, dividers1.green);
            Assert.AreEqual(1, dividers1.blue);

            Assert.AreEqual(5, dividers2.red);
            Assert.AreEqual(1, dividers2.green);
            Assert.AreEqual(1, dividers2.blue);

            Assert.AreEqual(1, dividers3.red);
            Assert.AreEqual(5, dividers3.green);
            Assert.AreEqual(1, dividers3.blue);

            Assert.AreEqual(5, dividers4.red);
            Assert.AreEqual(1, dividers4.green);
            Assert.AreEqual(5, dividers4.blue);

            Assert.AreEqual(5, dividers5.red);
            Assert.AreEqual(5, dividers5.green);
            Assert.AreEqual(5, dividers5.blue);
        }
    }
}