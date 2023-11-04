namespace TP1_SergioCeline.FileAccess
{
    public interface IFileAccess
    {
        Bitmap LoadImage();
        void SaveImage(Image image);
    }
}
