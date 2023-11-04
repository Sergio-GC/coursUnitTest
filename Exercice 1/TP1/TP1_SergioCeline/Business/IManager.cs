using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.Business
{
    public interface IManager
    {
        public Image Process(Image image, List<AlgoFilter> filters, AlgoEdge edges);
    }
}
