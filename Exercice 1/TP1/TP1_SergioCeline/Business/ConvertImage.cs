namespace TP1_SergioCeline.Business
{
    public class ConvertImage: IConvertImage
    {
        public Bitmap ConvertToBitmap(Image image)
        {
            return new Bitmap(image);
        }
    }
}
