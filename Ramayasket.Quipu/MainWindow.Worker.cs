using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Kw.Common.Threading;

namespace Ramayasket.Quipu
{
	public partial class MainWindow
	{
		/// <summary>
		/// Worker thread method.
		/// </summary>
		public void Worker()
		{
			foreach (var locator in Locators)
				locator.Reset();

			try
			{
				WithUiThread(() => OnBoundary(true));

				WithUiThread(() => SetStatus("Starting mission..."));

				foreach (var panel in Panels)
					panel.Select(false);

				foreach (var locator in Locators) 
					if(!Cancelled)
						locator.Process();

				var max = Locators.Max(l => l.Hrefs);

				foreach (var panel in Panels)
					if (max == panel.Locator.Hrefs) {

						panel.Select(); break;
					}
			}
			finally
			{
				WorkerThread = null;

				WithUiThread(() => OnBoundary(false));
				WithUiThread(() => SetStatus("Mission completed..."));

				Cancelled = false;
			}
		}

		void OnBoundary(bool enter)
		{
			ClearButton.IsEnabled = StartButton.IsEnabled = ReadButton.IsEnabled = !(CancelButton.IsEnabled = enter);

			Mouse.OverrideCursor = enter ? Cursors.Wait : Cursors.Arrow;
		}
	}
}