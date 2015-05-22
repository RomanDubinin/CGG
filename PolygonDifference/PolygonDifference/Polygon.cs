using System.Collections.Generic;
using System.Linq;

namespace PolygonDifference
{
		public class Polygon
		{
			public readonly List<Point2D> Points;
			public readonly List<Section> Edges;

			public Polygon(List<Point2D> points)
			{
				Points = points;
				Edges = new List<Section>(Points.Count);
				for (var i = 0; i < Points.Count - 1; i++)
				{
					Edges.Add(new Section(Points[i], Points[i + 1]));
				}
				Edges.Add(new Section(Points[Points.Count - 1], Points.First()));
			}
		}
}
