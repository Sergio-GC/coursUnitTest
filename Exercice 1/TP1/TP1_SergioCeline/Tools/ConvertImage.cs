﻿using System.Drawing.Imaging;
using TP1_SergioCeline.Business;

namespace TP1_SergioCeline.Tools
{
    public class ConvertImage : IConvertImage
    {
        public Bitmap ConvertToBitmap(Image image)
        {
            return new Bitmap(image);
        }
        public byte[] ConvertImageToByteArray(Image imageToConvert,
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
        public Bitmap GetBitmapFromByteArray(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return new Bitmap(ms);
            }
        }
    }
}
