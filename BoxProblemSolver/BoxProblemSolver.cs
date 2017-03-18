using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
	public class BoxSolver
	{
		private Graph graph;

		public BoxSolver(List<BoxVertex> vertices)
		{
			graph = BoxGraphFactory.CreateBoxGraph(vertices);
		}

		public List<BoxVertex> Run()
		{
			return graph.FindLongestPath().Cast<BoxVertex>().ToList();
		}
	}
}
