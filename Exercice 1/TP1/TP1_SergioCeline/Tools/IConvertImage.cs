using System.Drawing.Imaging;

namespace TP1_SergioCeline.Tools
{
    public interface IConvertImage
    {
        public Bitmap ConvertToBitmap(Image image);
        public byte[] ConvertImageToByteArray(Image imageToConvert,
                                      ImageFormat formatOfImage);
        public Bitmap GetBitmapFromByteArray(byte[] data);
    }
}
