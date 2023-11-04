using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TP1_SergioCeline.AlgoEdges
{
    public abstract class AlgoEdge
    {
        public AlgoEdge(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        public abstract Bitmap algo(Bitmap init);

        /// <summary>
        /// Use a matrix to appliy a filter in X 
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="filterMatrix"></param>
        /// <param name="factor"></param>
        /// <param name="bias"></param>
        /// <param name="grayscale"></param>
        /// <returns></returns>
        public Bitmap ConvolutionFilterX(Bitmap sourceBitmap,
                                             double[,] filterMatrix,
                                                  double factor = 1,
                                                       int bias = 0,
                                             bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                pixelBuffer = CalculGrayScal(pixelBuffer);
            }

            int filterWidth = filterMatrix.GetLength(1);

            int filterOffset = (filterWidth - 1) / 2;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    double blue = 0.0;
                    double green = 0.0;
                    double red = 0.0;

                    int byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            int calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            double matrixValue = filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];
                            blue += (double)(pixelBuffer[calcOffset]) * matrixValue;

                            green += (double)(pixelBuffer[calcOffset + 1]) * matrixValue;

                            red += (double)(pixelBuffer[calcOffset + 2]) * matrixValue;
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }


        /// <summary>
        /// Use a matrix to appliy a filter in X and Y
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="xFilterMatrix"></param>
        /// <param name="yFilterMatrix"></param>
        /// <param name="factor"></param>
        /// <param name="bias"></param>
        /// <param name="grayscale"></param>
        /// <returns></returns>
        public Bitmap ConvolutionFilterXY(Bitmap sourceBitmap,
                                                double[,] xFilterMatrix,
                                                double[,] yFilterMatrix,
                                                      double factor = 1,
                                                           int bias = 0,
                                                 bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                pixelBuffer = CalculGrayScal(pixelBuffer);
            }

            int filterOffset = 1;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    double blueX = 0.0;
                    double greenX = 0.0;
                    double redX = 0.0;

                    double blueY = 0.0;
                    double greenY = 0.0;
                    double redY = 0.0;

                    int byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset +
                                          (filterX * 4) +
                                          (filterY * sourceData.Stride);

                            double xValue = xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueX += (double)(pixelBuffer[calcOffset]) * xValue;
                            greenX += (double)(pixelBuffer[calcOffset + 1]) * xValue;
                            redX += (double)(pixelBuffer[calcOffset + 2]) * xValue;

                            double yValue = yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                            blueY += (double)(pixelBuffer[calcOffset]) * yValue;
                            greenY += (double)(pixelBuffer[calcOffset + 1]) * yValue;
                            redY += (double)(pixelBuffer[calcOffset + 2]) * yValue;
                        }
                    }

                    double blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    double greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    double redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// calcul a gray scal in the algo
        /// </summary>
        /// <param name="pixelBuffer"></param>
        /// <returns></returns>
        public byte[] CalculGrayScal(byte[] pixelBuffer)
        {
            for (int k = 0; k < pixelBuffer.Length; k += 4)
            {
                float rgb = pixelBuffer[k] * 0.11f; // 50, 100, 150
                rgb += pixelBuffer[k + 1] * 0.59f;
                rgb += pixelBuffer[k + 2] * 0.3f;

                pixelBuffer[k] = (byte)rgb;
                pixelBuffer[k + 1] = pixelBuffer[k];
                pixelBuffer[k + 2] = pixelBuffer[k];
                pixelBuffer[k + 3] = 255;
            }

            return pixelBuffer;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
