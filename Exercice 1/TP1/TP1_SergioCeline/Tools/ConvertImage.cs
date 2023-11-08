using TP1_SergioCeline.Business;

namespace TP1_SergioCeline.Tools
{
    public class ConvertImage : IConvertImage
    {
        public Bitmap ConvertToBitmap(Image image)
        {
            return new Bitmap(image);
        }
    }
}
