using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonDifference;

namespace Tests
{
	[TestClass]
	public class IntersectionTests
	{
		[TestMethod]
		public void IntersectionOfLinesTest1()
		{
			var point1 = new Point2D(2, 5);
			var point2 = new Point2D(5, -2);
			var secction1 = new Section(point1, point2, null);

			var point3 = new Point2D(4, 1);
			var point4 = new Point2D(-3, -2);
			var section2 = new Section(point3, point4, null);

			var expectedPoint = new Point2D(3.7586206896552, 0.89655172413793);
			var realPoint = PolygonHelper.IntersectionOfLines(secction1, section2);

			Assert.IsTrue(PolygonHelper.PointsAreEquals(expectedPoint, realPoint, PolygonHelper.Epsilon));
		}

		[TestMethod]
		public void IntersectionOfLinesTest2()
		{
			var point1 = new Point2D(2, 5);
			var point2 = new Point2D(5, -2);
			var secction1 = new Section(point1, point2, null);

			var point3 = new Point2D(3, 5);
			var point4 = new Point2D(6, -2);
			var section2 = new Section(point3, point4, null);

			var realPoint = PolygonHelper.IntersectionOfLines(secction1, section2);

			Assert.IsTrue(double.IsInfinity(Math.Abs(realPoint.X)) && double.IsInfinity(Math.Abs(realPoint.Y)));
		}

		[TestMethod]
		public void IntersectionOfSectionTest1()
		{
			var point1 = new Point2D(2, 5);
			var point2 = new Point2D(5, -2);
			var secction1 = new Section(point1, point2, null);

			var point3 = new Point2D(3, 5);
			var point4 = new Point2D(6, -2);
			var section2 = new Section(point3, point4, null);

			var realPoint = PolygonHelper.IntersectionOfSections(secction1, section2);

			Assert.IsNull(realPoint);
		}

		[TestMethod]
		public void IntersectionOfSectionTest2()
		{
			var point1 = new Point2D(2, 5);
			var point2 = new Point2D(5, -2);
			var secction1 = new Section(point1, point2, null);

			var point3 = new Point2D(4, 1);
			var point4 = new Point2D(-3, -2);
			var section2 = new Section(point3, point4, null);

			var expectedPoint = new Point2D(3.7586206896552, 0.89655172413793);
			var realPoint = PolygonHelper.IntersectionOfSections(secction1, section2);

			Assert.IsTrue(PolygonHelper.PointsAreEquals(expectedPoint,  realPoint, PolygonHelper.Epsilon));
		}

		[TestMethod]
		public void IntersectionOfSectionTest3()
		{
			var point1 = new Point2D(2, 5);
			var point2 = new Point2D(5, -2);
			var secction1 = new Section(point1, point2, null);

			var point3 = new Point2D(3, 1);
			var point4 = new Point2D(-3, -2);
			var section2 = new Section(point3, point4, null);

			var realPoint = PolygonHelper.IntersectionOfSections(secction1, section2);

			Assert.IsNull(realPoint);
		}
	}
}