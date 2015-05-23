using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PolygonDifference;

namespace Vsualization
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

			var graphics = Graphics.FromImage(pictureBox1.Image);


			var polygonA = new Polygon(
				new List<Point2D>
				{
					new Point2D(50, 400),
					new Point2D(50, 200),
					new Point2D(400, 200),
					new Point2D(400, 400)
				});
			var polygonB = new Polygon(
				new List<Point2D>
				{
					new Point2D(300, 500),
					new Point2D(300, 100),
					new Point2D(100, 100),
					new Point2D(100, 500),
				});

			var blueVioletPen = new Pen(Brushes.BlueViolet, 4);
			foreach (var section in polygonA.Sections)
			{
				graphics.DrawLine(blueVioletPen, MyPointToSysDrawingPoint(section.Source), MyPointToSysDrawingPoint(section.Target));
			}

			var brownPen = new Pen(Color.Brown, 4);
			foreach (var section in polygonB.Sections)
			{
				graphics.DrawLine(brownPen, MyPointToSysDrawingPoint(section.Source), MyPointToSysDrawingPoint(section.Target));
			}


			var diffs = PolygonHelper.GetDifference(polygonA, polygonB);
			foreach (var polygon in diffs)
			{
				graphics.FillPolygon(Brushes.BlueViolet, polygon.Points.Select(MyPointToSysDrawingPoint).ToArray());
			}
		}

		public static Point MyPointToSysDrawingPoint(Point2D point)
		{
			return new Point((int) point.X, (int) point.Y);
		}
	}
}
