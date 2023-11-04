using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.Business;
using TP1_SergioCeline.Test.Helper;

namespace TP1_SergioCeline.Test.Business
{
    [TestClass]
    public class ManagerTests
    {
        #region TestExeption
        [TestMethod]
        public void Process_ThrowArgumentNullException()
        {
            IConvertImage convert = Substitute.For<IConvertImage>();

            // Arrange
            IManager manager = new Manager(convert);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => manager.Process(null, null, null), "Please load a picture before");
        }

        #endregion
        #region TestOk
        [TestMethod]
        public void Process_ReturnImage()
        {
            // Arrange
            Image image = Image.FromFile("images/init.png");
            Bitmap bpm = new Bitmap(image);
            Image imgAttempt = Image.FromFile("images/rainbows.png");
            Bitmap bpmAttempt = new Bitmap(imgAttempt);

            // Subsitute algo
            AlgoFilter filter = Substitute.For<AlgoFilter>("Test filter");
            filter.ExecuteAlgo(bpm).Returns(bpmAttempt);
            List<AlgoFilter> algoFilters = new ();
            algoFilters.Add(filter);

            AlgoEdge edge = Substitute.For<AlgoEdge>("Test EdgeDetection");
            edge.ExecuteAlgo(bpmAttempt).Returns(bpmAttempt);

            IConvertImage convert = Substitute.For<IConvertImage>();
            convert.ConvertToBitmap(image).Returns(bpm);

            IManager manager = new Manager(convert);

            // Act
            Image imgResult = manager.Process(image, algoFilters, edge);
           
            // Assert
            Assert.AreEqual(imgAttempt.GetType(), imgResult.GetType());
            EqualsHelper.CheckBitmapEquals(new Bitmap(imgAttempt), new Bitmap(imgResult));
        }

        

        #endregion

    }
}
