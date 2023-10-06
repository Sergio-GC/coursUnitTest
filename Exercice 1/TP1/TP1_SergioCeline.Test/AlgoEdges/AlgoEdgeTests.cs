using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.Test.AlgoEdges
{
    [TestClass]
    public class AlgoEdgeTests
    {
        #region ConvolutionFilterX

        //1. Test that the method returns a non-null Bitmap object:
        [TestMethod]
        public void ConvolutionFilterX_ReturnsNonNullBitmap()
        {
            // Arrange
            Bitmap sourceBitmap = new Bitmap(100, 100);
            double[,] filterMatrix = new double[3, 3];

            // Act
            Bitmap resultBitmap = ConvolutionFilterX(sourceBitmap, filterMatrix);

            // Assert
            Assert.IsNotNull(resultBitmap);
        }

        //2. Test that the method returns a Bitmap object with the same dimensions as the source bitmap:
        [TestMethod]
        public void ConvolutionFilterX_ReturnsBitmapWithSameDimensions()
        {
            // Arrange
            Bitmap sourceBitmap = new Bitmap(100, 100);
            double[,] filterMatrix = new double[3, 3];

            // Act
            Bitmap resultBitmap = ConvolutionFilterX(sourceBitmap, filterMatrix);

            // Assert
            Assert.AreEqual(sourceBitmap.Width, resultBitmap.Width);
            Assert.AreEqual(sourceBitmap.Height, resultBitmap.Height);
        }

        //3. Test that the method applies the filter correctly to the pixels in the source bitmap:
        [TestMethod]
        public void ConvolutionFilterX_AppliesFilterCorrectly()
        {
            // Arrange
            Bitmap sourceBitmap = new Bitmap(100, 100);
            double[,] filterMatrix = new double[3, 3] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };

            // Act
            Bitmap resultBitmap = ConvolutionFilterX(sourceBitmap, filterMatrix);

            // Assert
            // Check that the resultBitmap contains the expected pixel values after applying the filter
            // You can compare individual pixel values or check a specific region of the image
        }

        //4. Test that the method handles grayscale conversion correctly:

        [TestMethod]
        public void ConvolutionFilterX_HandlesGrayscaleConversionCorrectly()
        {
            // Arrange
            Bitmap sourceBitmap = new Bitmap(100, 100);
            double[,] filterMatrix = new double[3, 3];
            bool grayscale = true;

            // Act
            Bitmap resultBitmap = ConvolutionFilterX(sourceBitmap, filterMatrix, grayscale: grayscale);

            // Assert
            // Check that the resultBitmap is grayscale
            // You can check individual pixel values or use a library like AForge.NET to perform more advanced checks
        }
        #endregion

        #region ConvolutionFilterXY

        //1. Test that the output bitmap has the same dimensions as the input bitmap:

        [TestMethod]
        public void ConvolutionFilterXY_OutputHasSameDimensions()
        {
            // Arrange
            Bitmap inputBitmap = new Bitmap(100, 100);
            double[,] xFilterMatrix = new double[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            double[,] yFilterMatrix = new double[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Act
            Bitmap outputBitmap = ConvolutionFilterXY(inputBitmap, xFilterMatrix, yFilterMatrix);

            // Assert
            Assert.AreEqual(inputBitmap.Width, outputBitmap.Width);
            Assert.AreEqual(inputBitmap.Height, outputBitmap.Height);
        }

        //2. Test that the output bitmap is not the same instance as the input bitmap:
        [TestMethod]
        public void ConvolutionFilterXY_OutputIsNotSameInstance()
        {
            // Arrange
            Bitmap inputBitmap = new Bitmap(100, 100);
            double[,] xFilterMatrix = new double[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            double[,] yFilterMatrix = new double[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Act
            Bitmap outputBitmap = ConvolutionFilterXY(inputBitmap, xFilterMatrix, yFilterMatrix);

            // Assert
            Assert.AreNotSame(inputBitmap, outputBitmap);
        }
        //3. Test that the output bitmap is in the correct format(32bppArgb) :
        [TestMethod]
        public void ConvolutionFilterXY_OutputIsInCorrectFormat()
        {
            // Arrange
            Bitmap inputBitmap = new Bitmap(100, 100);
            double[,] xFilterMatrix = new double[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            double[,] yFilterMatrix = new double[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Act
            Bitmap outputBitmap = ConvolutionFilterXY(inputBitmap, xFilterMatrix, yFilterMatrix);

            // Assert
            Assert.AreEqual(PixelFormat.Format32bppArgb, outputBitmap.PixelFormat);
        }

        //4. Test that the output bitmap is grayscale when the grayscale parameter is set to true:
        [TestMethod]
        public void ConvolutionFilterXY_OutputIsGrayscale()
        {
            // Arrange
            Bitmap inputBitmap = new Bitmap(100, 100);
            double[,] xFilterMatrix = new double[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            double[,] yFilterMatrix = new double[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Act
            Bitmap outputBitmap = ConvolutionFilterXY(inputBitmap, xFilterMatrix, yFilterMatrix, grayscale: true);

            // Assert
            Assert.IsTrue(IsGrayscale(outputBitmap));
        }

        private bool IsGrayscale(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if (pixelColor.R != pixelColor.G || pixelColor.G != pixelColor.B)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region CalculGrayScal

        [TestMethod]
        public void CalculGrayScal_ReturnsGrayScaleImage()
        {
            // Arrange
            byte[] pixelBuffer = new byte[] { 100, 150, 200, 255, 50, 100, 150, 255 };

            // Act
            byte[] result = CalculGrayScal(pixelBuffer);

            // Assert
            Assert.AreEqual(8, result.Length);
            Assert.AreEqual(160, result[0]); //159.5
            Assert.AreEqual(160, result[1]); //159.5
            Assert.AreEqual(160, result[2]); //159.5
            Assert.AreEqual(255, result[3]);

            Assert.AreEqual(110, result[4]); //109.5
            Assert.AreEqual(110, result[5]); //109.5
            Assert.AreEqual(110, result[6]); //109.5
            Assert.AreEqual(255, result[7]);
        }
        #endregion

    }
}
