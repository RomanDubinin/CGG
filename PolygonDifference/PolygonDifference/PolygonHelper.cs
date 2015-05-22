﻿using System;
using System.Linq;

namespace PolygonDifference
{
	public class PolygonHelper
	{
		public static double Epsilon = 1e-5;

		public static bool PointsAreEquals(Point2D a, Point2D b, double eps)
		{
			return Math.Abs(a.X - b.X) < eps && Math.Abs(a.Y - b.Y) < eps;
		}

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

		public static Point2D IntersectionOfLines(Section section1, Section section2)
		{
			var a1 = section1.Source.Y - section1.Target.Y;
			var b1 = section1.Target.X - section1.Source.X;
			var c1 = section1.Source.X*section1.Target.Y - section1.Target.X*section1.Source.Y;

			var a2 = section2.Source.Y - section2.Target.Y;
			var b2 = section2.Target.X - section2.Source.X;
			var c2 = section2.Source.X * section2.Target.Y - section2.Target.X * section2.Source.Y;

			var x = (c1*b2 - c2*b1)/(a1*b2 - a2*b1);
			var y = (a1*c2 - a2*c1)/(a1*b2 - a2*b1);
			

			return new Point2D(x, y);
		}

//		public static Point2D IntersectionOfSections(Section section1, Section section2)
//		{
//
//		}
	}
}