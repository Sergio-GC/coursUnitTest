namespace TP1_SergioCeline.AlgoEdges
{
    public class Sobel : AlgoEdge
    {
        private double[,] Sobel3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -2,  0,  2, },
                  { -1,  0,  1, }, };
            }
        }

        private double[,] Sobel3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                  {  0,  0,  0, },
                  { -1, -2, -1, }, };
            }
        }
        public Sobel() : base("Sobel") { }
        protected override Bitmap algo(Bitmap init)
        {
            Bitmap resultBitmap = ConvolutionFilterXY(init,
                                                 Sobel3x3Horizontal,
                                                   Sobel3x3Vertical,
                                                        1.0, 0, true);

            return resultBitmap;
        }
    }
}

