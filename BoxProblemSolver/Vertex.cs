using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
    public class Vertex
    {
        public HashSet<Vertex> exitingEdges { get; protected set; }
        public HashSet<Vertex> enteringEdges { get; protected set; }

        public Vertex()
        {
            exitingEdges = new HashSet<Vertex>();
            enteringEdges = new HashSet<Vertex>();
        }

        public void AddEdge(Vertex to)
        {
            exitingEdges.Add(to);
            to.enteringEdges.Add(this);
        }

        public void RemoveEdge(Vertex to)
        {
            exitingEdges.Remove(to);
            to.exitingEdges.Remove(this);
        }

        public bool HasEnteringEdges()
        {
            return enteringEdges.Count > 0;
        }
    }
}
