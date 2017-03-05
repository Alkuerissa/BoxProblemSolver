using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
    public class Vertex
    {
        public HashSet<Vertex> ExitingEdges { get; protected set; }
        public HashSet<Vertex> EnteringEdges { get; protected set; }

        public Vertex()
        {
            ExitingEdges = new HashSet<Vertex>();
            EnteringEdges = new HashSet<Vertex>();
        }

        public void AddEdge(Vertex to)
        {
            ExitingEdges.Add(to);
            to.EnteringEdges.Add(this);
        }

        public void RemoveEdge(Vertex to)
        {
            ExitingEdges.Remove(to);
            to.ExitingEdges.Remove(this);
        }

        public bool HasEnteringEdges()
        {
            return EnteringEdges.Count > 0;
        }

	    public virtual Vertex Copy()
	    {
		    return new Vertex();
	    }
    }
}
