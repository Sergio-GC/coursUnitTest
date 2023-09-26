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
            //TODO pourquoi pas Width?
            int raz = image.Height / 4;
            for (int x = 0; x < image.Width; x++)
            {
                //TODO on pourrait faire une fonction pour le choix de couleur ?
                // Dividers for the colors
                int r = 1, g = 1, b = 1;

                // Current width zone for calculing the dividers
                int currentZone = (int) (x / raz);
                switch (currentZone)
                {
                    case 0:
                        r = 5;
                        break;
                    case 1:
                        g = 5;
                        break;
                    case 2:
                        b = 5;
                        break;
                    case 3:
                        r = b = 5;
                        break;
                    default:
                        r = g = b = 5;
                        break;
                }

                for (int y = 0; y < image.Height; y++)
                {
                    // rgb values from the current pixels
                    byte red = image.GetPixel(x, y).R;
                    byte green = image.GetPixel(x, y).G;
                    byte blue = image.GetPixel(x, y).B;

                    // Change the colors
                    result.SetPixel(x, y, Color.FromArgb(red / r, green / g, blue / b)) ;
                }

            }
            return result;
        }
    }
}
