using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.AlgoFilters
{
    public class ColorSwap : AlgoFilter
    {
        public ColorSwap() : base("Color swap") { }

        public override Bitmap algo(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);


            for (int i = 0; i < image.Width; i++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color c = image.GetPixel(i, x);
                    Color newColor = Color.FromArgb(c.A, c.G, c.B, c.R);
                    result.SetPixel(i, x, newColor);
                }

            }
            return result;
        }
    }
}
