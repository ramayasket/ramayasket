using System;
using System.Windows.Input;

namespace Ramayasket.Quipu
{
	/// <summary>
	/// Adorns lengthy operations.
	/// </summary>
	internal class WaitCursorScope : IDisposable
	{
		/// <summary>
		/// Opens wait cursor scope.
		/// </summary>
		public WaitCursorScope() => Mouse.OverrideCursor = Cursors.Wait;

		/// <summary>
		/// Sets back arrow cursor.
		/// </summary>
		public void Dispose() => Mouse.OverrideCursor = Cursors.Arrow;
	}
}
