using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
    public class Graph
    {
        protected List<Vertex> vertices;
        protected int maxIndex;

        public Graph(List<Vertex> start_vertices, List<Tuple<Vertex, Vertex>> edges)
        {
            vertices = new List<Vertex>();
            maxIndex = 0;
            foreach (var vertex in start_vertices)
            {
                vertices.Add(vertex);
                vertex.Index = maxIndex++;
            }

            foreach (var egde in edges)
            {
                AddEdge(egde.Item1, egde.Item2);
            }
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            from.AddEdge(to);
        }

        public void RemoveEdge(Vertex from, Vertex to)
        {
            from.RemoveEdge(to);
        }
        //TODO: it can be done better (probably)
        public Graph(Graph graph)
        {
            var oldVertices = new Dictionary<Vertex, int>();
            vertices = new List<Vertex>();
            for (int i = 0; i < graph.vertices.Count; i++)
            {
                oldVertices[graph.vertices[i]] = i;
                vertices.Add(graph.vertices[i].Copy());
            }
            foreach (var vertex in graph.vertices)
            {
                foreach (var edgeEnd in vertex.ExitingEdges)
                {
                    AddEdge(vertices[oldVertices[vertex]], vertices[oldVertices[edgeEnd]]);
                }
            }
        }

        public List<Vertex> TopologicalSort()
        {
            var graph = new Graph(this);
            var result = new List<Vertex>();
            var startVertices = graph.FindVerticesWithoutEnteringEdges();
            while (startVertices.Count > 0)
            {
                Vertex vertex = startVertices.First();
                startVertices.Remove(vertex);
                result.Add(vertex);
                while (vertex.ExitingEdges.Count > 0)
                {
                    var edgeEnd = vertex.ExitingEdges.First();
                    graph.RemoveEdge(vertex, edgeEnd);
                    if (!edgeEnd.HasEnteringEdges())
                        startVertices.Add(edgeEnd);
                }
            }
            return result;
        }

        private HashSet<Vertex> FindVerticesWithoutEnteringEdges()
        {
            var result = new HashSet<Vertex>();
            foreach (var vertex in vertices)
            {
                if (!vertex.HasEnteringEdges())
                    result.Add(vertex);
            }
            return result;
        }

        public List<Vertex> FindLongestPath()
        {
            var sortedVertices = TopologicalSort();

            var previousVerticeIndices = new int[maxIndex];
            var longestPathToVertex = new int[maxIndex];
            var currentLongestPathIndex = 0;

            foreach (var vertex in sortedVertices.Skip(1))
            {
                longestPathToVertex[vertex.Index] = 0;
                previousVerticeIndices[vertex.Index] = -1;
                foreach (var startVertex in vertex.EnteringEdges)
                {
                    int newPathLength = longestPathToVertex[startVertex.Index] + 1;
                    if (newPathLength > longestPathToVertex[vertex.Index])
                    {
                        longestPathToVertex[vertex.Index] = newPathLength;
                        previousVerticeIndices[vertex.Index] = startVertex.Index;
                    }
                    if (newPathLength > longestPathToVertex[currentLongestPathIndex])
                        currentLongestPathIndex = vertex.Index;
                }
            }

            var longestPath = new List<Vertex>();
            int i = currentLongestPathIndex;
            while (i != -1)
            {
                //longestPath.Add();
            }
            return longestPath;
        }
    }
}
