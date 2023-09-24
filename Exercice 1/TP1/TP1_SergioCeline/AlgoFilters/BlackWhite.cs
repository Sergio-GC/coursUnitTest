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
            int colorAvg;
            Color c;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    c = image.GetPixel(x, y);
                    colorAvg = (int)((c.R + c.G + c.B) / 3);
                    image.SetPixel(x, y, Color.FromArgb(colorAvg, colorAvg, colorAvg));
                }
            }

            return image;
        }
    }
}
