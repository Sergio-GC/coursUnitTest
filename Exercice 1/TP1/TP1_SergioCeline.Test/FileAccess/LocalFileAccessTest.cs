using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.FileAccess;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TP1_SergioCeline.Test.FileAccess
{
    [TestClass]
    public class LocalFileAccessTest
    {
        string _directoryPath = "images";

        [TestMethod]
        public void LoadImage_ReturnsImage()
        {

            // Create
            var pathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            // fileAccess.LoadImage().Returns(new Bitmap($"{_directoryPath}/init.png"));
            pathDefiner.DefinePath().Returns($"{_directoryPath}/init.png");



            // Arrange
            Bitmap expected = new Bitmap($"{_directoryPath}/init.png");

            // Act
            Bitmap obtained = fileAccess.LoadImage();

            // Assert
            Assert.IsNotNull( obtained );
            Assert.AreEqual(expected.Width, obtained.Width );
            Assert.AreEqual(expected.Height, obtained.Height );
            for(int w = 0; w < expected.Width; w++)
            {
                for(int h = 0; h < expected.Height; h++)
                {
                    Assert.AreEqual(expected.GetPixel(w, h), obtained.GetPixel(w, h));
                }
            }
        }


        [TestMethod]
        public void SaveImage_CreatesImage()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var pathDefiner = Substitute.For < IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath().Returns($"{_directoryPath}/test.png");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
        }
    }
}
