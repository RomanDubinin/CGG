using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonDifference;

namespace Tests
{
	[TestClass]
	public class SectorTests
	{
		[TestMethod]
		public void SectorTest1()
		{
			var point = new Point2D(1, 0);
			var expectedSector = 0;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest2()
		{
			var point = new Point2D(1, 0.5);
			var expectedSector = 0;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest3()
		{
			var point = new Point2D(1, 1);
			var expectedSector = 1;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest4()
		{
			var point = new Point2D(1, 2);
			var expectedSector = 1;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest5()
		{
			var point = new Point2D(0, 1);
			var expectedSector = 2;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest6()
		{
			var point = new Point2D(-1, 2);
			var expectedSector = 2;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest7()
		{
			var point = new Point2D(-1, 1);
			var expectedSector = 3;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest8()
		{
			var point = new Point2D(-2, 1);
			var expectedSector = 3;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest9()
		{
			var point = new Point2D(-1, 0);
			var expectedSector = 4;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest10()
		{
			var point = new Point2D(-2, -1);
			var expectedSector = 4;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest11()
		{
			var point = new Point2D(-1, -1);
			var expectedSector = 5;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest12()
		{
			var point = new Point2D(-1, -2);
			var expectedSector = 5;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest13()
		{
			var point = new Point2D(0, -1);
			var expectedSector = 6;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest14()
		{
			var point = new Point2D(1, -2);
			var expectedSector = 6;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest15()
		{
			var point = new Point2D(1, -1);
			var expectedSector = 7;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}

		[TestMethod]
		public void SectorTest16()
		{
			var point = new Point2D(2, -1);
			var expectedSector = 7;
			var realSector = PolygonHelper.NumberOfSectorInCircle(point);

			Assert.AreEqual(expectedSector, realSector);
		}


	}
}