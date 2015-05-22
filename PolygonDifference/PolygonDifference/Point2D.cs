using System;

namespace PolygonDifference
{
	public class Point2D
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Point2D(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double Lenght()
		{
			return Math.Sqrt(X*X + Y*Y);
		}

		public double CosBetween(Point2D anotherPoint)
		{
			return (X*anotherPoint.X + Y*anotherPoint.Y)/(Lenght()*anotherPoint.Lenght());
		}

		public double SinTo(Point2D anotherPoint)
		{
			return (X*anotherPoint.Y - Y*anotherPoint.X)/(Lenght()*anotherPoint.Lenght());
		}

		public static Point2D operator +(Point2D a, Point2D b)
		{
			return new Point2D(a.X + b.X, a.Y + b.Y);
		}

		public static Point2D operator-(Point2D a, Point2D b)
		{
			return new Point2D(a.X - b.X, a.Y - b.Y);
		}

		public static Point2D operator/(Point2D a, double val)
		{
			return new Point2D(a.X/val, a.Y/val);
		}

		public static Point2D operator *(Point2D a, double val)
		{
			return new Point2D(a.X * val, a.Y * val);
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", X, Y);
		}
	}
}
