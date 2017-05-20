using System;
using System.Collections.Generic;
using System.Diagnostics;
using BoxProblemSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoxProblemSolverTests
{
    [TestClass]
    class AlgorithmBenchmarks
    {
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
            int minn = 10, maxn = 1000, step = 10;
            double[] times = new double[(maxn - minn) / step];
            double[] resultsAsFraction = new double[(maxn - minn) / step];
            for (int i = minn / step; i <= maxn / step; i++)
            {
                int n = i * step;
                List<BoxVertex> vertices = GenerateData(n);
                BoxSolver solver = new BoxSolver(vertices);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = solver.Run();
                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                resultsAsFraction[i] = result.Count / n;
            }
        }
    }
}
