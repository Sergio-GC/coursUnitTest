using System.Drawing.Imaging;

namespace TP1_SergioCeline.Business
{
    public interface IConvertImage
    {
        public Bitmap ConvertToBitmap(Image image);
        public byte[] ConvertImageToByteArray(Image imageToConvert,
                                      ImageFormat formatOfImage);
    }
}
