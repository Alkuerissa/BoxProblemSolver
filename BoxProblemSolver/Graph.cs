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

        public Graph(List<Vertex> start_vertices, List<Tuple<Vertex, Vertex>> edges)
        {
            vertices = start_vertices;
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

        public Graph(Graph graph)
        {
            var oldVertices = new Dictionary<Vertex, int>();

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
                foreach (var edgeEnd in vertex.ExitingEdges)
                {
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
    }
}
