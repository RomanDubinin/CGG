using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Task5
{
	public class Program
	{
		readonly static Bitmap Image = new Bitmap(Constants.WindowSize, Constants.WindowSize);
		static readonly Figure[] Figures = {DataProvider.GetPyramid()};

		private static void CreateImage()
		{

			var zBuf = new double[Constants.WindowSize, Constants.WindowSize];
			var colors = new Color[Constants.WindowSize, Constants.WindowSize];
			for (var y = 0; y < Constants.WindowSize; y++)
			{
				for (var x = 0; x < Constants.WindowSize; x++)
				{
					zBuf[x, y] = int.MaxValue;
					colors[x, y] = Color.Azure;
				}
			}

			for (var x = 0; x < Constants.WindowSize; x++) 
			{
				for (var y = 0; y < Constants.WindowSize; y++)
				{
					foreach (var figure in Figures)
					{
						foreach (var side in figure.Sides)
						{
							var screenPolygon = new Polygon2D(side.Points.Select(point => new Point2D(point.X, point.Y)).ToList());
							var screenPoint = new Point2D(x, y);
							if (PointInPolygon(screenPolygon, screenPoint))
							{
								var distance = GetDistance(side, screenPoint);
								if (distance < zBuf[x, y])
								{
									zBuf[x, y] = distance;
									colors[x, y] = side.Color;
								}
							}
							
						}
					}
				}
			}

			for (int x = 0; x < Constants.WindowSize; x++)
			{
				for (int y = 0; y < Constants.WindowSize; y++)
				{
					Image.SetPixel(x, Constants.WindowSize - y - 1, colors[x,y]);
				}
			}
		}

		private static double GetDistance(Side side, Point2D screenPoint)
		{
			var firstPoint = side.Points.First();
			var secondPoint = side.Points.Skip(1).First();
			var thirdPoint = side.Points.Skip(2).First();

			return -ComputeZOfPointInPlane(firstPoint, secondPoint, thirdPoint, screenPoint);
		}

		private static double ComputeZOfPointInPlane(Point3D firstPoint, Point3D secondPoint, Point3D thirdPoint, Point2D screenPoint)
		{
			var matrix11 = screenPoint.X - firstPoint.X;
			var matrix12 = screenPoint.Y - firstPoint.Y;

			var matrix21 = secondPoint.X - firstPoint.X;
			var matrix22 = secondPoint.Y - firstPoint.Y;
			var matrix23 = secondPoint.Z - firstPoint.Z;
			var matrix31 = thirdPoint.X - firstPoint.X;
			var matrix32 = thirdPoint.Y - firstPoint.Y;
			var matrix33 = thirdPoint.Z - firstPoint.Z;

			var matrix13 = (-matrix11*matrix22*matrix33 +
			                matrix11*matrix23*matrix32 +
			                matrix12*matrix21*matrix33 -
			                matrix12*matrix23*matrix31)/
							(matrix21*matrix32 - matrix22*matrix31);
			return matrix13 + firstPoint.Z;
		}

		private static IEnumerable<int> Range(int from, int to)
		{
			if (from < to)
			{
				for (var i = from; i < to; i++)
					yield return i;
			}
			else
			{
				for (var i = from; i > to; i--)
					yield return i;
			}
			//yield return to;
		}

		private static int PutIntoScreen(int val)
		{
			return Math.Max(Math.Min(Constants.WindowSize - 1, val), 0);
		}

		private static double GetDistance(Point3D point3D)
		{
			if (point3D.X > Constants.DistToZero)
			{
				return int.MaxValue;
			}
			return Constants.DistToZero - point3D.X;
		}

		private static Point2D GetScreenPoint(Point3D point3D)
		{
			return new Point2D((int)point3D.X, (int)(Constants.WindowSize - point3D.Y));
		}

		public static bool PointInPolygon(Polygon2D polygon2D, Point2D point)
		{
			var movedPolygon = new Polygon2D(polygon2D.Points.Select(p => p - point).ToList());
			var numbersOfPices = movedPolygon.Points.Select(NumberOfSectorInCircle);
			var sum = 0;
			foreach (var edge in movedPolygon.Sections)
			{
				var dif = ModularDifference(NumberOfSectorInCircle(edge.Source) - NumberOfSectorInCircle(edge.Target), 4);
				if (Math.Abs(dif) == 4)
					sum += edge.Source.SinTo(edge.Target) > 0 ? -4 : 4;
				else
					sum += dif;
			}

			return Math.Abs(sum) == 8;
		}

		public static int ModularDifference(int val, int mod)
		{
			if (val > mod)
				val -= mod * 2;
			else if (val < -mod)
				val += mod * 2;
			return val;
		}

		public static int NumberOfSectorInCircle(Point2D point)
		{
			if (point.X > 0 && point.Y >= 0 && point.X > point.Y)
				return 0;
			if (point.X > 0 && point.Y > 0 && point.X <= point.Y)
				return 1;
			if (point.X <= 0 && point.Y > 0 && -point.X < point.Y)
				return 2;
			if (point.X < 0 && point.Y > 0 && -point.X >= point.Y)
				return 3;
			if (point.X < 0 && point.Y <= 0 && -point.X > -point.Y)
				return 4;
			if (point.X < 0 && point.Y < 0 && -point.X <= -point.Y)
				return 5;
			if (point.X >= 0 && point.Y < 0 && point.X < -point.Y)
				return 6;

			return 7;
		}


		private static void ShowImageInWindow(Bitmap image)
		{
			var form = new Form
			{
				ClientSize = new Size(Constants.WindowSize, Constants.WindowSize)
			};
			form.Controls.Add(new PictureBox { Image = image, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.CenterImage });
			form.ShowDialog();
		}

		static void Main(string[] args)
		{
			var graphic = Graphics.FromImage(Image);
			graphic.FillRectangle(Brushes.Azure, 0, 0, Image.Width, Image.Height);

			CreateImage();

			// image.Save("img.png", ImageFormat.Png);

			ShowImageInWindow(Image);

		}
	}
}