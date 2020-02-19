using System;

namespace Ramayasket.Mindbox
{
	/// <summary>
	/// Shape description.
	/// </summary>
	public class Shape
	{
		/// <summary>
		/// Segments that comprise the shape.
		/// </summary>
		public Segment[] Segments { get; }

		/// <summary>
		/// Creates new shape from segments.
		/// </summary>
		/// <param name="segments">Collection of segments.</param>
		public Shape(params Segment[] segments) => Segments = segments;

		/// <summary>
		/// Verifies if shape's path is closed.
		/// </summary>
		/// <returns>True when path is closed, False otherwise.</returns>
		public virtual bool IsPathClosed
		{
			get => throw new NotImplementedException();
		}
	}
}
