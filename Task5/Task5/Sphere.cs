using System.Drawing;

namespace Task5
{
	public class Sphere
	{
		public Point3D Center { get; private set; }
		public double Radius { get; private set; }
		public Color Color { get; private set; }

		public Sphere(Point3D center, double radius, Color color)
		{
			Color = color;
			Radius = radius;
			Center = center;
		}
	}
}