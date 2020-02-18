using System;

namespace Ramayasket.Mindbox.Problems
{
	/// <summary>
	/// Calculates shape's area.
	/// </summary>
	public interface IAreaCalculator
	{
		double Area { get; }
	}

	/// <summary>
	/// Default shape area calculator.
	/// </summary>
	/// <remarks>
	/// Area calculation was moved to separate class to conform with (S)OLID.
	/// </remarks>
	public class DefaultAreaCalculator : IAreaCalculator
	{
		/// <summary>
		/// The shape to calculate area for.
		/// </summary>
		public Shape Shape { get; }

		/// <summary>
		/// Creates new area calculator for a shape.
		/// </summary>
		/// <param name="shape"></param>
		public DefaultAreaCalculator(Shape shape) => Shape = shape;

		/// <inheritdoc />
		public double Area => throw new NotImplementedException();
	}
}
