namespace Task5
{
	public class Section
	{
		public Section(Point2D source, Point2D target)
		{
			Source = source;
			Target = target;
		}

		public override string ToString()
		{
			return string.Format("{0} -> {1}", Source, Target);
		}

		public Point2D Source { get; private set; }
		public Point2D Target { get; private set; }
	}
}