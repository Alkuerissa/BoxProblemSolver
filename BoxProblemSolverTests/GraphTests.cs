using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxProblemSolver;

namespace BoxProblemSolverTests
{
    [TestClass]
    public class GraphTests
    {
        public Graph CreateSimpleGraph()
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
                new Tuple<Vertex, Vertex>(vertices[0], vertices[2]),
                new Tuple<Vertex, Vertex>(vertices[2], vertices[3]),
                new Tuple<Vertex, Vertex>(vertices[2], vertices[4]),
                new Tuple<Vertex, Vertex>(vertices[3], vertices[5]),
                new Tuple<Vertex, Vertex>(vertices[4], vertices[3]),
            };
            return new Graph(vertices, edges);
        }

        [TestMethod]
        public void SimpleTopologicalSortTest()
        {

            var graph = CreateSimpleGraph();
            var sortedVertices = graph.TopologicalSort();
        }

        [TestMethod]
        public void SimpleLongestPathFindingTest()
        {
            var graph = CreateSimpleGraph();
            var longestPath = graph.FindLongestPath();
        }
    }
}

