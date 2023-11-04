namespace TP1_SergioCeline.AlgoEdges
{
    public class NoEdgeDetection : AlgoEdge
    {
        public NoEdgeDetection() : base("No Edge Detection") { }
        protected override Bitmap algo(Bitmap init)
        {
            return init;
        }
    }
}
