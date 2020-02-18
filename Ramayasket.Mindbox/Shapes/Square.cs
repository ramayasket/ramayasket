using Ramayasket.Mindbox.Problems;

namespace Ramayasket.Mindbox.Shapes
{
	/// <summary>
	/// Describes a square.
	/// </summary>
	/// <remarks>
	/// Illustrates how to combine customized definition with default area calculation.
	/// </remarks>
	public class Square : Shape, IAreaCalculator
	{
		/// <summary>
		/// Square edge.
		/// </summary>
		public double Edge { get; }

		/// <summary>
		/// Creates new square by its radius.
		/// </summary>
		/// <param name="edge">square edge.</param>
		public Square(double edge) : base(new Segment(CurvatureMode.Zero, double.PositiveInfinity, edge, null)) => Edge = edge;

		/// <inheritdoc />
		public override bool CheckIsClosed() => true;

		/// <inheritdoc />
		/// <remarks>
		/// Alternatively, we could use default calculation as: new DefaultAreaCalculator(this).Area;
		/// </remarks>
		public double Area => Edge * Edge;
	}
}
