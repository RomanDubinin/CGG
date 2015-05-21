using System;
using System.Linq;

namespace PolygonDifference
{
	public class PolygonHelper
	{
		public static bool PointInPolygon(Polygon polygon, Point2D point)
		{
			var movedPolygon = new Polygon(polygon.Points.Select(p => p - point).ToList());
			var numbersOfPices = movedPolygon.Points.Select(NumberOfSectorInCircle);
			var sum = 0;
			foreach (var edge in movedPolygon.Edges)
			{
				var dif = ModularDifference(NumberOfSectorInCircle(edge.Source) - NumberOfSectorInCircle(edge.Target), 4);
				if (Math.Abs(dif) == 4)
					sum += edge.Source.SinTo(edge.Target) < 0 ? -4 : 4;
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
	}
}