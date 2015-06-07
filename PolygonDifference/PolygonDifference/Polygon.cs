using System.Collections.Generic;
using System.Linq;

namespace PolygonDifference
{
		public class Polygon
		{
			public readonly List<Point2D> Points;
			public readonly List<Section> Sections;

			public Polygon(List<Point2D> points)
			{
				//todo: впилить проверку на обход против часовой(отдельным методом, не для каждого объекта)
				Points = points;
				Sections = new List<Section>(Points.Count);
				var nextSection = new Section(Points[points.Count - 1], Points[0], null);
				Sections.Add(nextSection);
				for (var i = Points.Count - 1; i > 0; i--)
				{
					var currentSection = new Section(Points[i - 1], Points[i], nextSection);
					Sections.Add(currentSection);
					nextSection = currentSection;
				}
				Sections.First().NextSection = nextSection;
				Sections.Reverse();
			}
		}
}
