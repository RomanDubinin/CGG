using System;
using System.Collections.Generic;
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
			foreach (var edge in movedPolygon.Sections)
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

			var x = -(c1*b2 - c2*b1)/(a1*b2 - a2*b1);
			var y = -(a1*c2 - a2*c1)/(a1*b2 - a2*b1);
			

			return new Point2D(x, y);
		}

		public static Point2D IntersectionOfSections(Section section1, Section section2)
		{
			var intersectionOfLines = IntersectionOfLines(section1, section2);
			if (PointIsOnSection(section1, intersectionOfLines) && PointIsOnSection(section2, intersectionOfLines))
				return intersectionOfLines;
			return null;
		}

		public static bool PointIsOnLine(Section section, Point2D point)
		{
			var a = section.Source.Y - section.Target.Y;
			var b = section.Target.X - section.Source.X;
			var c = section.Source.X * section.Target.Y - section.Target.X * section.Source.Y;

			return (Math.Abs(a*point.X + b*point.Y + c) < Epsilon);
		}

		public static bool PointIsOnSection(Section section, Point2D point)
		{
			if (point == null)
				return false;
			if (!PointIsOnLine(section, point))
				return false;

			var vectorFromSource = section.Source - point;
			var vectorFromTarget = section.Target - point;

			var normalizedVectorFromSource = vectorFromSource/vectorFromSource.Lenght();
			var normalizedVectorFromTarget = vectorFromTarget/vectorFromTarget.Lenght();

			return
				Math.Abs(normalizedVectorFromSource.Lenght() - 1) < Epsilon &&
				Math.Abs(normalizedVectorFromTarget.Lenght() - 1) < Epsilon &&
				!PolygonHelper.PointsAreEquals(normalizedVectorFromSource, normalizedVectorFromTarget, PolygonHelper.Epsilon);
		}

		public static List<Polygon> GetDifference(Polygon a, Polygon b)
		{
			var pair = a.Sections.SelectMany(edgeA => b.Sections, (edgeA, edgeB) => new[] {edgeA, edgeB})
				.FirstOrDefault(edges => IntersectionOfSections(edges[0], edges[1]) != null);

			if (pair == null)
				return new List<Polygon>();

			var inside = (pair[0].Target - pair[0].Source).SinTo(pair[1].Target - pair[1].Source) > 0 ? pair[1] : pair[0];
			var outside = inside == pair[0] ? pair[1] : pair[0];

			var k = a.Sections.Contains(inside) ? 1 : 0;

			var firstIntersection = IntersectionOfSections(inside, outside);
			var currentIntersection = firstIntersection;

			var resultPolygons = new List<Polygon>();
			do
			{
				outside = outside.NextSection;
				var insidePoints = new List<Point2D>();
				var outsidePoints = new List<Point2D>();
				outsidePoints.Add(currentIntersection);
				outsidePoints.Add(outside.Source);

				while(true)
				{
					currentIntersection = IntersectionOfLines(inside, outside);
					var intersectionPointIsOnInsideSection = PointIsOnSection(inside, currentIntersection);
					var intersectionPointIsOnOutsideSection = PointIsOnSection(outside, currentIntersection);

					if(intersectionPointIsOnInsideSection && intersectionPointIsOnOutsideSection)
						break;

					if (intersectionPointIsOnInsideSection && !intersectionPointIsOnOutsideSection)
					{
						outside = outside.NextSection;
						if (k % 2 == 0)
						{
							outsidePoints.Add(outside.Source);
						}
					}


					if (!intersectionPointIsOnInsideSection && intersectionPointIsOnOutsideSection)
					{
						inside = inside.NextSection;
						if (k % 2 == 0)
						{
							insidePoints.Add(inside.Source);
						}
					}


					if (!intersectionPointIsOnInsideSection && !intersectionPointIsOnOutsideSection)
					{
						outside = outside.NextSection;
						if (k % 2 == 0)
						{
							outsidePoints.Add(outside.Source);
						}
					}
				}

				outsidePoints.Add(currentIntersection);
				insidePoints.Reverse();
				if (k % 2 == 0)
				{
					var polygon = new Polygon(outsidePoints.Concat(insidePoints).ToList());
					resultPolygons.Add(polygon);
				}
				k++;
				var temp = inside;
				inside = outside;
				outside = temp;

			} while (!PointsAreEquals(firstIntersection, currentIntersection, Epsilon));

			return resultPolygons;
		}
	}
}