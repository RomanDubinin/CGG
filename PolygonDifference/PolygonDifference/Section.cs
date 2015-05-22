namespace PolygonDifference
{
	public class Section
	{
		public Section(Point2D source, Point2D target, Section nextSection)
		{
			Source = source;
			Target = target;
			NextSection = nextSection;
		}

		public override string ToString()
		{
			return string.Format("{0} -> {1}", Source, Target);
		}

		public Point2D Source { get; private set; }
		public Point2D Target { get; private set; }
		public Section NextSection { get; set; }
	}
}