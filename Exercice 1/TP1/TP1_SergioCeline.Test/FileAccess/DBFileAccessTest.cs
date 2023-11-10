using NSubstitute;
using System.Drawing;
using System.Drawing.Imaging;
using TP1_SergioCeline.DefineName;
using TP1_SergioCeline.FileAccess;
using TP1_SergioCeline.Test.Helper;
using TP1_SergioCeline.Tools;
using Image = System.Drawing.Image;

namespace TP1_SergioCeline.Test.FileAccess
{
    [TestClass]
    public class DBFileAccessTest
    {
        string _directoryPath = "images";
        string _connectionString = "Server=zemog.ch;Database=utimages;Uid=utadmin;Pwd=1234ut;";

        #region Load
        [TestMethod]
        public void LoadImage_ReturnsImage()
        {
            // Create
            var nameDefiner = Substitute.For<INameDefiner>();
            DbFileAccess fileAccess = new DbFileAccess(nameDefiner, _connectionString);

            // Set a return value
            nameDefiner.SelectName(Arg.Any<List<string>>()).Returns("sampleImage");


            // Arrange
            Bitmap expected = new Bitmap($"{_directoryPath}/init.png");
           // expected = new Bitmap("C:\\Users\\gomez\\OneDrive\\Imágenes\\pfp2.jpg");

            // Act
            Bitmap obtained = fileAccess.LoadImage();

            // Assert
            Assert.IsNotNull(obtained);
            // EqualsHelper.CheckBitmapEquals(test2, obtained);
        }

        [TestMethod]
        public void LoadImage_ThrowsExceptionForInvalidPath()
        {
            // Create
            var emptyNameDefiner = Substitute.For<INameDefiner>();
            var nullNameDefiner = Substitute.For<INameDefiner>();
            DbFileAccess emptyFileAccess = new DbFileAccess(emptyNameDefiner, _connectionString);
            DbFileAccess nullFileAccess = new DbFileAccess(nullNameDefiner, _connectionString);

            // Set a return value
            emptyNameDefiner.SelectName(Arg.Any<List<string>>()).Returns("");
            nullNameDefiner.SelectName(Arg.Any<List<string>>()).Returns(callInfo => null);


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
            DbFileAccess fileAccess = new DbFileAccess(nameDefiner, _connectionString);

            // Set a return value
            nameDefiner.DefineName().Returns($"test");



            // Assert
            Assert.AreEqual(true, fileAccess.SaveImage(img));
            // Test that the image is correctly saved
            nameDefiner.SelectName(Arg.Any<List<string>>()).Returns("test");
            Image result = fileAccess.LoadImage();
            // TODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO delete :3
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveImage_ThrowsExceptionForInvalidPath()
        {
            Image img = new Bitmap($"{_directoryPath}/init.png");

            // Create
            var emptyNameDefiner = Substitute.For<INameDefiner>();
            var nullNameDefiner = Substitute.For<INameDefiner>();
            IFileAccess emptyFileAccess = new DbFileAccess(emptyNameDefiner, _connectionString);
            IFileAccess nullFileAccess = new DbFileAccess(nullNameDefiner, _connectionString);

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
            IFileAccess fileAccess = new DbFileAccess(nameDefiner, _connectionString);

            // Set a return value
            nameDefiner.DefineName().Returns($"test.png");



            // Assert
            Assert.ThrowsException<NullReferenceException>(() => fileAccess.SaveImage(img));
        }
        #endregion
    }
}
