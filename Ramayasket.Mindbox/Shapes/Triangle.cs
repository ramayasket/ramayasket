using System;
using System.Linq;
using Ramayasket.Mindbox.Problems;

namespace Ramayasket.Mindbox.Shapes
{
	/// <summary>
	/// Describes a triangle.
	/// </summary>
	public class Triangle : Shape, IAreaCalculator
	{
		public double A { get; }
		public double B { get; }
		public double C { get; }

		/// <summary>
		/// Creates a new triangle by its edges.
		/// </summary>
		/// <param name="a">Edge A.</param>
		/// <param name="b">Edge B.</param>
		/// <param name="c">Edge C.</param>
		public Triangle(double a, double b, double c) : base(
			new Segment(CurvatureMode.Zero, double.PositiveInfinity, a, null),
			new Segment(CurvatureMode.Zero, double.PositiveInfinity, b, null),
			new Segment(CurvatureMode.Zero, double.PositiveInfinity, c, null)
			)
		{
			A = a;
			B = b;
			C = c;
		}

		/// <inheritdoc />
		/// <remarks>
		/// Path is closed when one edge is larger that two others combined.
		/// </remarks>
		public override bool IsPathClosed
		{
			get
			{
				var sorted = (new[] { A, B, C }).OrderByDescending(x => x).ToArray();
				return sorted[0] < sorted[1] + sorted[2];
			}
		}

		/// <summary>
		/// Calculate triangle area by its edges.
		/// </summary>
		public double Area {

			get {

				var p = (A + B + C) / 2;
				return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
			}
		}

		/// <summary>
		/// Checks if triangle is right.
		/// </summary>
		public bool IsRight
		{
			get {
				var sorted = (new[] { A, B, C }).OrderByDescending(x => x).ToArray();
				
				// precision (arbitrary)
				const double PRECISION = 0.00000001;

				return Math.Abs(sorted[0] * sorted[0] - (sorted[1] * sorted[1] + sorted[2] * sorted[2])) < PRECISION;
			}
		}
	}
}
