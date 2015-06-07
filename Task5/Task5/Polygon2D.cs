using System.Collections.Generic;
using System.Linq;

namespace Task5
{
	public class Polygon2D
	{
		public readonly List<Point2D> Points;
			public readonly List<Section> Sections;

			public Polygon2D(List<Point2D> points)
			{
				Points = points;
				Sections = new List<Section>(Points.Count);
				var nextSection = new Section(Points[points.Count - 1], Points[0]);
				Sections.Add(nextSection);
				for (var i = Points.Count - 1; i > 0; i--)
				{
					var currentSection = new Section(Points[i - 1], Points[i]);
					Sections.Add(currentSection);
					nextSection = currentSection;
				}
				Sections.Reverse();
			}
	}
}