using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxProblemSolver;

namespace BoxProblemSolverTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TopologicalSortTest()
        {
            int n = 6;
            var vertices = new List<Vertex>();
            for (int i = 0; i < n; i++)
            {
                vertices.Add(new Vertex());
            }
            List<Tuple<Vertex, Vertex>> edges = new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(vertices[0], vertices[1]),
            };
        }
    }
}
