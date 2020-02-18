namespace Ramayasket.Mindbox
{
	/// <summary>
	/// Segment of a shape.
	/// </summary>
	public class Segment
	{
		/// <summary>
		/// Segment's curvature mode.
		/// </summary>
		public CurvatureMode Curvature { get; }

		/// <summary>
		/// Segment's radius, can be double or math function (not yet defined).
		/// </summary>
		public dynamic Radius { get; }

		/// <summary>
		/// Length alongside segment (or ignored).
		/// </summary>
		public double? Length { get; }

		/// <summary>
		/// Angle relative to previous segment, if any.
		/// </summary>
		public double? Angle { get; }

		/// <summary>
		/// Creates a new segment.
		/// </summary>
		/// <param name="curvature">Curvature mode.</param>
		/// <param name="radius">Radius, can be double or math function (not yet defined).</param>
		/// <param name="length">Length alongside segment.</param>
		/// <param name="angle">Angle relative to previous segment, if any.</param>
		public Segment(CurvatureMode curvature, dynamic radius, double? length, double? angle)
		{
			Curvature = curvature;
			Radius = radius;
			Length = length;
			Angle = angle;
		}
	}
}