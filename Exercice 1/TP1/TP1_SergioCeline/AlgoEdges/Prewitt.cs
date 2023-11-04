﻿namespace TP1_SergioCeline.AlgoEdges
{
    public class Prewitt : AlgoEdge
    {
        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, }, };
            }
        }
        public Prewitt() : base("Prewitt Grayscale") { }
        public override Bitmap algo(Bitmap init)
        {
            Bitmap resultBitmap = ConvolutionFilterXY(init,
                                                 Prewitt3x3Horizontal,
                                                   Prewitt3x3Vertical,
                                                        1.0, 0, true);

            return resultBitmap;
        }
    }
}

