using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramayasket.Mindbox.Shapes;

namespace Ramayasket.Mindbox.Test.Shapes
{
	/// <summary>
	/// Tests the <see cref="Ramayasket.Mindbox.Shapes.Triangle"/> class.
	/// </summary>
	[TestClass]
	public class TriangleTest
	{
		/// <summary>
		/// Tests if triangle's area is correct.
		/// </summary>
		[TestMethod]
		public void IsAreaCorrect()
		{
			var t = new Triangle(1, 1, Math.Sqrt(2.0));

			// precision (arbitrary)
			const double PRECISION = 0.00000001;

			Assert.IsTrue(Math.Abs(t.Area - 0.5) < PRECISION);
		}

		/// <summary>
		/// Tests if valid triangle path is closed.
		/// </summary>
		[TestMethod]
		public void IsValidTrianglePathClosed()
		{
			var t = new Triangle(1, 1, 1);

			Assert.IsTrue(t.IsPathClosed);
		}

		/// <summary>
		/// Tests if invalid triangle path is closed.
		/// </summary>
		[TestMethod]
		public void IsInvalidTrianglePathClosed()
		{
			var t = new Triangle(1, 1, 10);

			Assert.IsFalse(t.IsPathClosed);
		}

		/// <summary>
		/// Tests if right triangle validates as such.
		/// </summary>
		[TestMethod]
		public void IsRightTriangleRight()
		{
			var t = new Triangle(1, 1, Math.Sqrt(2.0));

			Assert.IsTrue(t.IsRight);
		}

		/// <summary>
		/// Tests if non-right triangle doesn't validate as such.
		/// </summary>
		[TestMethod]
		public void IsRegularTriangleRight()
		{
			var t = new Triangle(2, 1, Math.Sqrt(2.0));

			Assert.IsFalse(t.IsRight);
		}
	}
}
