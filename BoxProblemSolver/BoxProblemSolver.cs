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
			
		}

		public List<BoxVertex> Run()
		{
			return new List<BoxVertex>()
			{
				new BoxVertex(100, 80),
				new BoxVertex(90, 65),
				new BoxVertex(85, 50),
				new BoxVertex(50, 40),
				new BoxVertex(30, 25),
				new BoxVertex(15, 10),
			};
		}
	}
}
