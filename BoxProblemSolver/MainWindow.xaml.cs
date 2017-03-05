using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoxProblemSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

	    private void DrawResults(List<BoxVertex> results)
	    {
		    if (results.Count == 0)
			    return;

			BoxCanvas.Children.Clear();

		    double scale = BoxCanvas.Width / results[0].Width;

			foreach (var vertex in results)
		    {
			    Rectangle rect = new Rectangle();
			    rect.Width = scale * vertex.Width;
			    rect.Height = scale * vertex.Height;
			    BoxCanvas.Children.Add(rect);
				Canvas.SetLeft(rect, rect.Width);
		    }
	    }
    }
}
