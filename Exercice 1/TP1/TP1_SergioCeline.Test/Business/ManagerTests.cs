using NSubstitute;
using System.Drawing;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.Business;

namespace TP1_SergioCeline.Test.Business
{
    [TestClass]
    public class ManagerTests
    {
        #region TestExeption
        [TestMethod]
        public void Process_ThrowArgumentNullException()
        {
            // Arrange
            IManager manager = new Manager();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => manager.Process(null, null, null), "Please load a picture before");
        }

        #endregion
        #region TestOk
        [TestMethod]
        public void Process_ReturnImage()
        {
            // Arrange
            IManager manager = new Manager();
            Image image = Image.FromFile("images/init.png");
            Image imgAttempt = Image.FromFile("images/rainbows.png");
            Bitmap bpmAttempt = new Bitmap(imgAttempt);

            // Subsitute algo
            AlgoFilter filter = Substitute.For<AlgoFilter>("Test filter");
            filter.ExecuteAlgo(new Bitmap(image)).Returns(bpmAttempt);
            List<AlgoFilter> algoFilters = new ();
            algoFilters.Add(filter);

            AlgoEdge edge = Substitute.For<AlgoEdge>("Test EdgeDetection");
            edge.ExecuteAlgo(new Bitmap(imgAttempt)).Returns(bpmAttempt);

            // Act
            Image imgResult = manager.Process(image, algoFilters, edge);
           
            // Assert
            Assert.AreEqual(imgAttempt, imgResult);
        }

        #endregion

    }
}
