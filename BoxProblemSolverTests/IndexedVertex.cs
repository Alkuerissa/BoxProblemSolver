using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BoxProblemSolver;

namespace BoxProblemSolverTests
{
    public class IndexedVertex: Vertex
    {
        public int index { get; private set; }

        public IndexedVertex(int i)
        {
            index = i;
        }

        public Vertex Copy()
        {
            return new IndexedVertex(index);
        }
    }
}
