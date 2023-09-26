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
