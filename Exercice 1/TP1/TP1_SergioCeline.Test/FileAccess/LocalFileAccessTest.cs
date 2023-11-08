using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.FileAccess;
using TP1_SergioCeline.Test.Helper;
using Image = System.Drawing.Image;

namespace TP1_SergioCeline.Test.FileAccess
{
    [TestClass]
    public class LocalFileAccessTest
    {
        string _directoryPath = "images";

        #region Load
        [TestMethod]
        public void LoadImage_ReturnsImage()
        {
            // Create
            var pathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath(true).Returns($"{_directoryPath}/init.png");


            // Arrange
            Bitmap expected = new Bitmap($"{_directoryPath}/init.png");

            // Act
            Bitmap obtained = fileAccess.LoadImage();

            // Assert
            Assert.IsNotNull( obtained );
            EqualsHelper.CheckBitmapEquals(expected, obtained);
        }

        [TestMethod]
        public void LoadImage_ThrowsExceptionForInvalidPath()
        {
            // Create
            var emptyPathDefiner = Substitute.For<IPathDefiner>();
            var nullPathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess emptyFileAccess = new LocalFileAccess(emptyPathDefiner);
            IFileAccess nullFileAccess = new LocalFileAccess(nullPathDefiner);

            // Set a return value
            emptyPathDefiner.DefinePath(true).Returns("");
            nullPathDefiner.DefinePath(true).Returns(callInfo => null!);


            // Assert
            Assert.ThrowsException<ArgumentException>(() => emptyFileAccess.LoadImage());
            Assert.ThrowsException<ArgumentException>(() => nullFileAccess.LoadImage());
        }
        #endregion

        #region Save
        [TestMethod]
        public void SaveImage_CreatesImage()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var pathDefiner = Substitute.For < IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath(false).Returns($"{_directoryPath}/test.png");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
            // Test that the image is correctly saved
            Image result = new Bitmap($"{_directoryPath}/test.png");
            Assert.IsNotNull( result );
        }

        [TestMethod]
        public void SaveImage_ThrowsExceptionForInvalidPath()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var emptyPathDefiner = Substitute.For<IPathDefiner>();
            var nullPathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess emptyFileAccess = new LocalFileAccess(emptyPathDefiner);
            IFileAccess nullFileAccess = new LocalFileAccess(nullPathDefiner);

            // Set a return value
            emptyPathDefiner.DefinePath(false).Returns("");
            nullPathDefiner.DefinePath(false).Returns(callInfo => null!);



            // Assert
            Assert.ThrowsException<ArgumentException>(() => emptyFileAccess.SaveImage(img));
            Assert.ThrowsException<ArgumentException>(() => nullFileAccess.SaveImage(img));
        }

        [TestMethod]
        public void SaveImage_ThrowsExceptionForEmptyImage()
        {
            Image img = null;

            // Create
            var pathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath(false).Returns($"{_directoryPath}/test.png");



            // Assert
            Assert.ThrowsException<NullReferenceException>(() => fileAccess.SaveImage(img));
        }
        #endregion
    }
}
