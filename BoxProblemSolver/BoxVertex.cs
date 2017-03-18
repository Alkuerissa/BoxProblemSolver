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
		    if (width >= height)
		    {
			    Width = width;
			    Height = height;
		    }
		    else
		    {
			    Width = height;
			    Height = width;
		    }
	    }

        public BoxVertex(BoxVertex vertex):base(vertex)
        {
            Width = vertex.Width;
            Height = vertex.Height;
        }

		public override Vertex Copy()
		{
			return new BoxVertex(this);
		}

        public bool FitsIn(BoxVertex vertex)
        {
            if (Width < vertex.Width && Height < vertex.Height)
                return true;
            return false;
        }
	}
}
