using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ramayasket.Mindbox.Test
{
	/// <summary>
	/// Tests the <see cref="Ramayasket.Mindbox.Segment"/> class.
	/// </summary>
	[TestClass]
	public class SegmentTest
	{
		/// <summary>
		/// Create segment with value radius.
		/// </summary>
		[TestMethod]
		public void CreateSegmentValueRadius()
		{
			var curvature = CurvatureMode.Fixed;
			var radius = 1.0;
			var length = 2.0;
			var angle = Math.PI;

			var segment = new Segment(curvature, radius, length, angle);

			Assert.AreEqual(segment.Curvature, curvature);
			Assert.AreEqual((double)segment.Radius, radius);
			Assert.AreEqual(segment.Length, length);
			Assert.AreEqual(segment.Angle, angle);
		}

		/// <summary>
		/// Calculates radius at given point along the segment.
		/// </summary>
		/// <remarks>
		/// This is just an example, not the final solution.
		/// </remarks>
		class DynamicRadius
		{
			/// <summary>
			/// Returns radius as sinus value.
			/// </summary>
			/// <param name="offset">The point to calculate radius at.</param>
			public double Get(double offset) => Math.Sin(offset);
		}

		/// <summary>
		/// Create segment with function radius.
		/// </summary>
		[TestMethod]
		public void CreateSegmentFunctionRadius()
		{
			var curvature = CurvatureMode.Fixed;
			dynamic radius = new DynamicRadius();
			var length = 2.0;
			var angle = Math.PI;

			var segment = new Segment(curvature, radius, length, angle);

			Assert.AreEqual(segment.Curvature, curvature);

			for (double x = 0; x < length; x += 0.01)
			{
				Assert.AreEqual(segment.Radius.Get(x), Math.Sin(x));
			}

			Assert.AreEqual(segment.Length, length);
			Assert.AreEqual(segment.Angle, angle);
		}
	}
}
