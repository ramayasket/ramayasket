using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramayasket.Mindbox.Shapes;

namespace Ramayasket.Mindbox.Test.Shapes
{
	/// <summary>
	/// Tests the <see cref="Ramayasket.Mindbox.Shapes.Square"/> class.
	/// </summary>
	[TestClass]
	public class SquareTest
	{
		/// <summary>
		/// Tests if square's area is correct.
		/// </summary>
		[TestMethod]
		public void IsAreaCorrect()
		{
			var t = new Square(2);

			// precision (arbitrary)
			const double PRECISION = 0.00000001;

			Assert.IsTrue(Math.Abs(t.Area - 4.0) < PRECISION);
		}

		/// <summary>
		/// Tests if square path is closed.
		/// </summary>
		[TestMethod]
		public void IsSquarePathClosed() => Assert.IsTrue(new Square(1).IsPathClosed);
	}
}
