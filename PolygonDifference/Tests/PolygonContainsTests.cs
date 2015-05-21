using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonDifference;

namespace Tests
{
	[TestClass]
	public class PolygonContainsTests
	{
		readonly Polygon Polygon = new Polygon(new List<Point2D>
			{
				new Point2D(1, 1),
				new Point2D(1, -1),
				new Point2D(-1, -1),
				new Point2D(-1, 1)
			});


		[TestMethod]
		public void PolygonContainsTest1()
		{
			var point = new Point2D(2, 0);
			
			Assert.IsFalse(PolygonHelper.PointInPolygon(Polygon, point));
		}

		[TestMethod]
		public void PolygonContainsTest2()
		{
			var point = new Point2D(2, 1);

			Assert.IsFalse(PolygonHelper.PointInPolygon(Polygon, point));
		}

		[TestMethod]
		public void PolygonContainsTest3()
		{
			var point = new Point2D(2, 2);

			Assert.IsFalse(PolygonHelper.PointInPolygon(Polygon, point));
		}

		[TestMethod]
		public void PolygonContainsTest4()
		{
			var point = new Point2D(1, 2);

			Assert.IsFalse(PolygonHelper.PointInPolygon(Polygon, point));
		}

		[TestMethod]
		public void PolygonContainsTest5()
		{
			var point = new Point2D(1, 1);

			Assert.IsFalse(PolygonHelper.PointInPolygon(Polygon, point));
		}

		[TestMethod]
		public void PolygonContainsTest6()
		{
			var point = new Point2D(0.5, 0);

			Assert.IsTrue(PolygonHelper.PointInPolygon(Polygon, point));
		}
	}
}