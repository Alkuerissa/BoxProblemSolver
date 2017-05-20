using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public double RandomInRange(double min, double max, Random generator)
        {
            return min + (max - min) * generator.NextDouble();
        }

        public List<BoxVertex> GenerateData(int n, double minX = 0.5, double maxX = 20, double minY = 0.5, double maxY = 20)
        {
            var vertices = new List<BoxVertex>();
            Random r = new Random();

            for (int i = 0; i < n; ++i)
                vertices.Add(new BoxVertex(RandomInRange(minX, maxX, r), RandomInRange(minY, maxY, r)));
            return vertices;
        }

        [TestMethod]
        public void MeanTimeAndResult()
        {
            int maxn = 1000, step = 10;
            double[] times = new double[maxn / step];
            double[] resultsAsFraction = new double[maxn / step];
            for (int i = 0; i < maxn / step; i++)
            {
                int n = i * step + 1;
                List<BoxVertex> vertices = GenerateData(n);
                BoxSolver solver = new BoxSolver(vertices);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = solver.Run();
                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                resultsAsFraction[i] = (double)result.Count / n;
            }
        }
    }
}

