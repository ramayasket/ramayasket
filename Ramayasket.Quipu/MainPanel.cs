using System.Windows;
using System.Windows.Controls;

namespace Ramayasket.Quipu
{
	/// <summary>
	/// Main locator panel.
	/// </summary>
	internal class MainPanel : StackPanel
	{
		static MainPanel() => DefaultStyleKeyProperty.OverrideMetadata(typeof(MainPanel), new FrameworkPropertyMetadata(typeof(MainPanel)));

		/// <summary>
		/// Resizes scroll viewer and locator list.
		/// </summary>
		public void Resize(double h)
		{
			var viewer = (ScrollViewer)Children[1];

			viewer.Height = ((StackPanel)viewer.Content).Height = (Height = h) - ((MainHeader)Children[0]).ActualHeight;
		}
	}
}
