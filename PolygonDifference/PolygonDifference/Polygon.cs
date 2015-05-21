using System.Collections.Generic;
using System.Linq;

namespace PolygonDifference
{
		public class Polygon
		{
			public readonly List<Point2D> Points;
			public readonly List<Edge> Edges;

			public Polygon(List<Point2D> points)
			{
				Points = points;
				Edges = new List<Edge>(Points.Count);
				for (var i = 0; i < Points.Count - 1; i++)
				{
					Edges.Add(new Edge(Points[i], Points[i + 1]));
				}
				Edges.Add(new Edge(Points[Points.Count - 1], Points.First()));
			}
		}
}
