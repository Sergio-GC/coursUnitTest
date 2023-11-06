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
            // tu pourrais controler que l'image est bien sauver quelque part 
            // il me faut aussi un test du coup dans le cas ou ça marche pas du coup si on return par exemple un string vide "" et un autre si on retourne null
            // pour le load c'est pareil
            //(tu peux faire dans le if au lieu  !=null mettre string.isNullOrEmpty(varaible) ça controle les 2 en 1 )
            // Tu peux aussi mettre des régions pour séparer les teste de sav et de load
        }
    }
}
