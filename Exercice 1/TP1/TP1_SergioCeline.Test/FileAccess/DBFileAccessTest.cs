using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.DefineName;
using TP1_SergioCeline.FileAccess;
using TP1_SergioCeline.Test.Helper;
using Image = System.Drawing.Image;

namespace TP1_SergioCeline.Test.FileAccess
{
    [TestClass]
    public class DBFileAccessTest
    {
        string _directoryPath = "images";

        #region Load
        [TestMethod]
        public void LoadImage_ReturnsImage()
        {
            // Create
            var nameDefiner = Substitute.For<INameDefiner>();
            IFileAccess fileAccess = new DbFileAccess(nameDefiner);

            // Set a return value
            nameDefiner.SelectName(DbAccess.GetNames).Returns($"scooby");


            // Arrange
            Bitmap expected = DbAccess.GetNames("scooby");//new Bitmap($"{_directoryPath}/init.png");

            // Act
            Bitmap obtained = fileAccess.LoadImage();

            // Assert
            Assert.IsNotNull(obtained);
            EqualsHelper.CheckBitmapEquals(expected, obtained);
        }

        [TestMethod]
        public void LoadImage_ThrowsExceptionForInvalidPath()
        {
            // Create
            var emptyNameDefiner = Substitute.For<INameDefiner>();
            var nullNameDefiner = Substitute.For<INameDefiner>();
            IFileAccess emptyFileAccess = new DbFileAccess(emptyNameDefiner);
            IFileAccess nullFileAccess = new DbFileAccess(nullNameDefiner);

            // Set a return value
            emptyNameDefiner.SelectName(DbAccess.GetNames).Returns("");
            nullNameDefiner.SelectName(DbAccess.GetNames).Returns(callInfo => null!);


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
            var nameDefiner = Substitute.For<INameDefiner>();
            IFileAccess fileAccess = new DbFileAccess(nameDefiner);

            // Set a return value
            nameDefiner.DefineName().Returns($"test");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
            // Test that the image is correctly saved
            nameDefiner.SelectName(DbAccess.GetNames).Returns("test");
            Image result = fileAccess.LoadImage();
            Assert.IsNotNull(result);
        }

        /*
        [TestMethod]
        public void SaveImage_CreatesImageJPG()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var pathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath(false).Returns($"{_directoryPath}/test.jpg");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
            // Test that the image is correctly saved
            Image result = new Bitmap($"{_directoryPath}/test.jpg");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveImage_CreatesImageBMP()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var pathDefiner = Substitute.For<IPathDefiner>();
            IFileAccess fileAccess = new LocalFileAccess(pathDefiner);

            // Set a return value
            pathDefiner.DefinePath(false).Returns($"{_directoryPath}/test.bmp");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
            // Test that the image is correctly saved
            Image result = new Bitmap($"{_directoryPath}/test.bmp");
            Assert.IsNotNull(result);
        }
        */

        [TestMethod]
        public void SaveImage_ThrowsExceptionForInvalidPath()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var emptyNameDefiner = Substitute.For<INameDefiner>();
            var nullNameDefiner = Substitute.For<INameDefiner>();
            IFileAccess emptyFileAccess = new DbFileAccess(emptyNameDefiner);
            IFileAccess nullFileAccess = new DbFileAccess(nullNameDefiner);

            // Set a return value
            emptyNameDefiner.DefineName().Returns("");
            nullNameDefiner.DefineName().Returns(callInfo => null!);



            // Assert
            Assert.ThrowsException<ArgumentException>(() => emptyFileAccess.SaveImage(img));
            Assert.ThrowsException<ArgumentException>(() => nullFileAccess.SaveImage(img));
        }

        [TestMethod]
        public void SaveImage_ThrowsExceptionForEmptyImage()
        {
            Image img = null;

            // Create
            var nameDefiner = Substitute.For<INameDefiner>();
            IFileAccess fileAccess = new DbFileAccess(nameDefiner);

            // Set a return value
            nameDefiner.DefineName().Returns($"test.png");



            // Assert
            Assert.ThrowsException<NullReferenceException>(() => fileAccess.SaveImage(img));
        }
        #endregion
    }
}
