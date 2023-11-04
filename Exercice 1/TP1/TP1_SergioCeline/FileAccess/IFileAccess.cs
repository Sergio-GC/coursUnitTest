namespace TP1_SergioCeline.FileAccess
{
    public interface IFileAccess
    {
        Bitmap LoadImage();
        bool SaveImage(Image image);
    }
}
