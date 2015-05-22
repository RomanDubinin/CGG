using System;
using System.Collections.Generic;
using System.Linq;

namespace PolygonDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			var polygonA = new Polygon(
				new List<Point2D>
				{
					new Point2D(0, 2),
					new Point2D(0, 0),
					new Point2D(2, 0),
					new Point2D(2, 2)
				});
			var polygonB = new Polygon(
				new List<Point2D>
				{
					new Point2D(1, 1),
					new Point2D(-1, 1),
					new Point2D(-1, -1),
					new Point2D(1, -1)
				});

//			var first = polygonA.Sections.First();
//			var currentSection = first;
//			while (currentSection.NextSection != first)
//			{
//				currentSection = currentSection.NextSection;
//			}

			PolygonHelper.GetDifference(polygonA, polygonB);
		}
	}
}
