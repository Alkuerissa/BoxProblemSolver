using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using Microsoft.Win32;

namespace BoxProblemSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
	    private BoxSolver solver;
	    private const string resultsFileName = "results.out";

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

		    var rand = new Random();

			foreach (var vertex in results)
		    {
			    Rectangle rect = new Rectangle
			    {
				    Width = scale * vertex.Width,
				    Height = scale * vertex.Height,
				    Stroke = new SolidColorBrush(Colors.Black),
				    StrokeThickness = 0.5,
				    Fill =
					    new SolidColorBrush(Color.FromRgb((byte) rand.Next(0, 30), (byte) rand.Next(0, 190), (byte) rand.Next(220, 255)))
			    };
			    BoxCanvas.Children.Add(rect);
				Canvas.SetLeft(rect, 0.5 * (BoxCanvas.Width - rect.Width));
				Canvas.SetTop(rect, 0.5 * (BoxCanvas.Height - rect.Height));
		    }
			MessageBox.Show(this, $"Found path with {results.Count} boxes.\nSaved as {resultsFileName}.", "Success!");
		}

	    private void LoadClick(object sender, RoutedEventArgs e)
	    {
		    var dialog = new OpenFileDialog
		    {
			    Multiselect = false,
			    CheckFileExists = true,
			    InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory,
			    RestoreDirectory = true
		    };
		    if (dialog.ShowDialog() != true)
			    return;
		    
			
			var vertices = new List<BoxVertex>();
		    try
		    {
			    using (var sr = new StreamReader(dialog.OpenFile()))
			    {
				    var s = sr.ReadToEnd().Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
				    for (int i = 0; i < s.Length / 2; ++i)
				    {
					    vertices.Add(new BoxVertex(double.Parse(s[2 * i]), double.Parse(s[2 * i + 1])));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
				MessageBox.Show(this, $"An error occurred while loading: {ex.Message}", "Error");
			    return;
		    }
			MessageBox.Show(this, $"Loaded {vertices.Count} boxes.", "Result");
			if (vertices.Count == 0)
				return;
		    solver = new BoxSolver(vertices);
		    RunButton.IsEnabled = true;
	    }

	    private void RunClick(object sender, RoutedEventArgs e)
	    {
		    var results = solver.Run();
		    var lines = new List<string>(results.Count + 1);
		    lines.Add(results.Count.ToString());
		    foreach (var vertex in results)
				lines.Add($"{vertex.Width} {vertex.Height}");
			System.IO.File.WriteAllLines(resultsFileName, lines);
			DrawResults(results);
	    }
    }
}
