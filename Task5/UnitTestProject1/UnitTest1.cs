using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var polygon = new Polygon2D(new List<Point2D>
			{
				new Point2D(0, 0),
				new Point2D(250, 500),
				new Point2D(500, 0),
				
			});

			var point = new Point2D(50, 250);
			Assert.IsTrue(!Program.PointInPolygon(polygon, point));
		}
	}
}
