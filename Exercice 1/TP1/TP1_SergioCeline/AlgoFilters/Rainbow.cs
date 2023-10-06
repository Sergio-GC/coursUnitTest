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
                    result.SetPixel(x, y, Color.FromArgb(red / dividers.red, green / dividers.green, blue / dividers.blue));
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
        public (int red, int green, int blue) GetDividers(int horizontalPixel, float sideWidth)
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