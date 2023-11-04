namespace TP1_SergioCeline.AlgoEdges
{
    public class Laplacian : AlgoEdge
    {
        private double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }
        public Laplacian() : base("Laplacian 5x5 of Gaussian 5x5") { }
        protected override Bitmap algo(Bitmap init)
        {
            Bitmap resultBitmap = ConvolutionFilterX(init,
                                    Laplacian3x3, 1.0, 0, true);

            return resultBitmap;
        }
    }
}
