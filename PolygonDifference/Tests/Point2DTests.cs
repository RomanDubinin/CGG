using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonDifference;

namespace Tests
{
	[TestClass]
	public class Point2DTests
	{
		private double Epsilon = 1e-5;

		[TestMethod]
		public void SinTest1()
		{
			var point1 = new Point2D(1, 0);
			var point2 = new Point2D(0, 4.74);

			var expectedSin = 1;
			var realSin = point1.SinTo(point2);
			Assert.IsTrue(Math.Abs(expectedSin - realSin) < Epsilon);
		}

		[TestMethod]
		public void SinTest2()
		{
			var point1 = new Point2D(0, 6.2);
			var point2 = new Point2D(-1.4, 0);

			var expectedSin = 1;
			var realSin = point1.SinTo(point2);
			Assert.IsTrue(Math.Abs(expectedSin - realSin) < Epsilon);
		}

		[TestMethod]
		public void SinTest3()
		{
			var point1 = new Point2D(-1, 1);
			var point2 = new Point2D(0, 4.74);

			var expectedSin = -Math.Sqrt(2)/2;
			var realSin = point1.SinTo(point2);
			Assert.IsTrue(Math.Abs(expectedSin - realSin) < Epsilon);
		}

		[TestMethod]
		public void SinTest4()
		{
			var point1 = new Point2D(-1, -1);
			var point2 = new Point2D(0, 4.74);

			var expectedSin = -Math.Sqrt(2) / 2;
			var realSin = point1.SinTo(point2);
			Assert.IsTrue(Math.Abs(expectedSin - realSin) < Epsilon);
		}
	}
}
