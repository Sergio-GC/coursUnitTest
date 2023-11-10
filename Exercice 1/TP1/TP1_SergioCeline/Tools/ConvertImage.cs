using System.Drawing.Imaging;

namespace TP1_SergioCeline.Tools
{
    public static class ConvertImage 
    {
        public static Bitmap ConvertToBitmap(Image image)
        {
            return new Bitmap(image);
        }
        public static byte[] ConvertImageToByteArray(Image imageToConvert,
                                      ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        /// <summary>
        /// Convert an array of bytes into a bitmap
        /// </summary>
        /// <param name="data">Image data in the form of an array of bytes</param>
        /// <returns>Bitmap with the image</returns>
        public static Bitmap GetBitmapFromByteArray(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return new Bitmap(ms);
            }
        }
    }
}
