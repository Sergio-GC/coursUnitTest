namespace TP1_SergioCeline.AlgoFilters
{
    public abstract class AlgoFilter
    {
        public AlgoFilter(string text) {
            Text = text;
        }
        public string Text { get; set; }
        public abstract Bitmap algo(Bitmap image);
        public override string ToString()
        {
            return Text;
        }
    }
}
