using System.Drawing;

namespace TP1_SergioCeline.Test.Helper
{
    public static class EqualsHelper
    {
        public static void CheckBitmapEquals(Bitmap expected, Bitmap actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
            for (int w = 0; w < expected.Width; w++)
            {
                for (int h = 0; h < expected.Height; h++)
                {
                    Assert.AreEqual(expected.GetPixel(w, h), actual.GetPixel(w, h));
                }
            }
        }
    }
}
