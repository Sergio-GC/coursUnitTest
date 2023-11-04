using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.FileAccess;
using TP1_SergioCeline.Test.Helper;
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
            EqualsHelper.CheckBitmapEquals(expected, obtained);
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
