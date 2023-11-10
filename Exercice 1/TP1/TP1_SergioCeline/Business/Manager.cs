using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.Tools;

namespace TP1_SergioCeline.Business
{
    public class Manager : IManager
    {
        public Image Process(Image image, List<AlgoFilter> filters, AlgoEdge edges)
        {
            if(image == null)
            {
                throw new ArgumentNullException("Please load a picture before");
            }
            Bitmap bitmap = ConvertImage.ConvertToBitmap(image);
            // application du filtre
            foreach (var item in filters)
            {
                bitmap = item.ExecuteAlgo(bitmap);
            }
            // application du Edge
            bitmap = edges.ExecuteAlgo(bitmap);

            return bitmap;
        } 
    }
}
