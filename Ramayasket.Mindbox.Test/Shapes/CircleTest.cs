using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramayasket.Mindbox.Shapes;

namespace Ramayasket.Mindbox.Test.Shapes
{
	/// <summary>
	/// Tests the <see cref="Ramayasket.Mindbox.Shapes.Circle"/> class.
	/// </summary>
	[TestClass]
	public class CircleTest
	{
		/// <summary>
		/// Tests if circle's area is correct.
		/// </summary>
		[TestMethod]
		public void IsAreaCorrect()
		{
			var t = new Circle(1);

			// precision (arbitrary)
			const double PRECISION = 0.00000001;

			Assert.IsTrue(Math.Abs(t.Area - Math.PI) < PRECISION);
		}

		/// <summary>
		/// Tests if circle path is closed.
		/// </summary>
		[TestMethod]
		public void IsSquarePathClosed() => Assert.IsTrue(new Circle(1).IsPathClosed);
	}
}
