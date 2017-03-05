using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProblemSolver
{
    public class BoxVertex : Vertex
    {
		public double Width { get; set; }
		public double Height { get; set; }

	    public BoxVertex(double width, double height)
	    {
		    Width = width;
		    Height = height;
	    }

		public override Vertex Copy()
		{
			return new BoxVertex(Width, Height);
		}
	}
}
