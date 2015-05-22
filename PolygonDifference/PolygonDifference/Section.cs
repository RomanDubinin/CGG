namespace PolygonDifference
{
	public class Section
	{
		public Section(Point2D source, Point2D target)
		{
			Source = source;
			Target = target;
		}

		public Point2D Source { get; private set; }
		public Point2D Target { get; private set; } 
	}
}