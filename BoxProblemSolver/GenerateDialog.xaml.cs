using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoxProblemSolver
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class GenerateDialog : Window
	{
		public MainWindow Owner = null;

		public GenerateDialog()
		{
			InitializeComponent();
		}

		double RandomInRange(double min, double max, Random generator)
		{
			return min + (max - min) * generator.NextDouble();
		}

		private void GenerateClick(object sender, RoutedEventArgs e)
		{
			string filename = FileNameBox.Text;

			if (filename == "")
			{
				var res = MessageBox.Show(this, "No file name entered - data won't be saved to a file!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
				if (res == MessageBoxResult.Cancel)
					return;
			}
			else if (!filename.Contains('.'))
				filename += ".txt";

			double minX;
			double minY;
			double maxX;
			double maxY;

			try
			{
				minX = double.Parse(MinX.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
				minY = double.Parse(MinY.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
				maxX = double.Parse(MaxX.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
				maxY = double.Parse(MaxY.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Invalid box size!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var vertices = new List<BoxVertex>();
			int n = (int)BoxesNumber.Value;
			Random r = new Random();

			for (int i = 0; i < n; ++i)
				vertices.Add(new BoxVertex(RandomInRange(minX, maxX, r), RandomInRange(minY, maxY, r)));		

			if (filename != "")
			{
				try
				{
					using (var sw = new StreamWriter(filename))
					{
						foreach (var v in vertices)
							sw.WriteLine($"{v.Width.ToString(CultureInfo.InvariantCulture)} {v.Height.ToString(CultureInfo.InvariantCulture)}");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, $"An error occurred while saving: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
			}

			Owner.Solver = new BoxSolver(vertices);
			this.Close();
		}
	}
}
