using System;
using Ramayasket.Mindbox.Problems;

namespace Ramayasket.Mindbox.Shapes
{
	/// <summary>
	/// Describes a circle.
	/// </summary>
	public class Circle : Shape, IAreaCalculator
	{
		/// <summary>
		/// Circle radius.
		/// </summary>
		public double Radius { get; }

		/// <summary>
		/// Creates new circle by its radius.
		/// </summary>
		/// <param name="radius">Circle radius.</param>
		public Circle(double radius) : base(new Segment(CurvatureMode.Fixed, radius, radius * Math.PI * 2, null)) => Radius = radius;

		/// <inheritdoc />
		public override bool IsPathClosed => true;

		/// <inheritdoc />
		public double Area => Radius * Radius * Math.PI;
	}
}
