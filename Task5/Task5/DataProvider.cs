using System.Drawing;

namespace Task5
{
	static class DataProvider
	{
		static public Figure GetPyramid()
		{
			var basePoint1 = new Point3D(10, 10, -10);
			var basePoint2 = new Point3D(10, 30, -100);
			var basePoint3 = new Point3D(300, 30, -100);
			var basePoint4 = new Point3D(400, 10, -10);
			var topPoint = new Point3D(200, 400, -50);

			var frontSide = new Side(new []{basePoint1, basePoint4, topPoint}, Color.BlueViolet);
			var rightSide = new Side(new []{basePoint4, basePoint3, topPoint}, Color.Brown);
			var backSide = new Side(new []{basePoint3, basePoint2, topPoint}, Color.Chartreuse);
			var leftSide = new Side(new []{basePoint2, basePoint1, topPoint}, Color.DarkBlue);
			var bottomSide = new Side(new []{basePoint1, basePoint2, basePoint3, basePoint4}, Color.Chocolate);

			var pyramid = new Figure(new[] {frontSide, rightSide, backSide, leftSide, bottomSide});

			return pyramid;
		}

		static public Figure GetCube()
		{
			var bottomPoint1 = new Point3D(13, 20, -10);
			var bottomPoint2 = new Point3D(20, 30, -40);
			var bottomPoint3 = new Point3D(400, 30, -40);
			var bottomPoint4 = new Point3D(400, 20,-10);
			var topPoint1 = new Point3D(13, 220, -10);
			var topPoint2 = new Point3D(20, 230, -40);
			var topPoint3 = new Point3D(400, 230, -40);
			var topPoint4 = new Point3D(400, 220, -10);

			var frontSide = new Side(new[] {bottomPoint1, bottomPoint2, topPoint2, topPoint1}, Color.DarkRed);
			var rightSide = new Side(new[] {bottomPoint2, bottomPoint3, topPoint3, topPoint2}, Color.DarkBlue);
			var backSide = new Side(new[] {bottomPoint3, bottomPoint4, topPoint4, topPoint3}, Color.Cyan);
			var leftSide = new Side(new[] {bottomPoint1, bottomPoint4, topPoint4, topPoint1}, Color.DarkOliveGreen);
			var bottomSide = new Side(new[] {bottomPoint1, bottomPoint2, bottomPoint3, bottomPoint4}, Color.DarkSlateBlue); 
			var topSide = new Side(new[] {topPoint1, topPoint2, topPoint3, topPoint4}, Color.Fuchsia);

			var cube = new Figure(new[] {frontSide, rightSide, backSide, leftSide, bottomSide, topSide});
			return cube;
		}
	}
}
