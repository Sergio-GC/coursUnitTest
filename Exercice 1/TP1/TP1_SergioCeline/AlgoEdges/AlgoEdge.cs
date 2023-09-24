using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.AlgoEdges
{
    public abstract class AlgoEdge
    {
        public AlgoEdge(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        public abstract Bitmap algo();

        public override string ToString()
        {
            return Text;
        }
    }
}
