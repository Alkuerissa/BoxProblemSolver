using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
    public class BoxGraphFactory
    {
        static Graph CreateBoxGraph(List<BoxVertex> boxes)
        {
            var edges = new List<Tuple<Vertex, Vertex>>();
            for (int i = 0; i < boxes.Count; i++)
                for (int j = i; j < boxes.Count; j++)
                {
                    if (boxes[i].FitsIn(boxes[j]))
                        edges.Add(new Tuple<Vertex, Vertex>(boxes[j], boxes[i]));
                    if (boxes[j].FitsIn(boxes[i]))
                        edges.Add(new Tuple<Vertex, Vertex>(boxes[i], boxes[j]));
                }
            return new Graph(boxes, edges);
        }
    }
}
