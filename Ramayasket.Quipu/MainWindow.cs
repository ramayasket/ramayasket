using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Kw.Common;
using Kw.Common.Threading;
using Microsoft.Win32;

namespace Ramayasket.Quipu
{
	/// <summary>
	/// Quipu's locator's logic.
	/// </summary>
	public partial class MainWindow : Window
	{
		private static MainWindow _intstance;

		/// <summary>
		/// Singleton instance.
		/// </summary>
		public static MainWindow Instance => _intstance = _intstance ?? new MainWindow();

		/// <summary/>
		public MainWindow()
		{
			InitializeComponent();
			Update();
		}

		/// <summary>
		/// Holds locator data.
		/// </summary>
		internal Locator[] Locators { get; private set; } = new Locator[0];

		/// <summary>
		/// Holds UI panels for locators.
		/// </summary>
		internal LocatorPanel[] Panels { get; private set; }

		/// <summary>
		/// Locator count limit.
		/// </summary>
		internal const int MISSION_COUNT_LIMIT = 100000;

		/// <summary>
		/// Reads locators from file.
		/// </summary>
		/// <remarks>
		/// For demonstration purposes, locator count is limited to 100.
		/// </remarks>
		private async void OnRead(object sender, RoutedEventArgs e)
		{
			var selector = new OpenFileDialog() { ReadOnlyChecked = true };

			if (selector.ShowDialog(this).GetValueOrDefault(false))
			{
				using (new WaitCursorScope())
				{
					ReadButton.IsEnabled = false;

					SetStatus($"Reading file... {selector.FileName}");

					try
					{
						using (var reader = File.OpenText(selector.FileName))
						{
							var text = await reader.ReadToEndAsync();
							var lines = text.Split(Environment.NewLine);

							SetStatus($"Analyzing file... {selector.FileName}");

							await CreateLocators(lines); // convert lines to locators.

							SetStatus($"Preparing UI... {selector.FileName}");

							await ShowLocators(); // display locators.

							if (Locators.Empty())
								MessageBox.Show("The file has no valid URLs.", "Ramayasket", MessageBoxButton.OK, MessageBoxImage.Exclamation);

							SetStatus();
						}

					}
					catch
					{
						SetStatus($"Can't read the file {selector.FileName}");
					}
					finally
					{
						ReadButton.IsEnabled = true;
					}
				}
			}
		}

		/// <summary>
		/// Creates locator data.
		/// </summary>
		/// <param name="lines"></param>
		/// <returns></returns>
		private async Task CreateLocators(string[] lines)
		{
			var r = Task.Run(() =>
			{
				Locators = lines.Take(MISSION_COUNT_LIMIT).Where(l => !string.IsNullOrEmpty(l)).Select(l => new Locator(l)).Where(m => m.IsValid).ToArray();
			});

			await r;
		}

		internal ExecutionThread WorkerThread { get; private set; }
		internal bool Cancelled { get; private set; }

		/// <summary>
		/// Begins locator work.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnStart(object sender, RoutedEventArgs e) => WorkerThread  = ExecutionThread.StartNew(Worker);

		/// <summary>
		/// Cancels processing, if any.
		/// </summary>
		private void Cancel()
		{
			if (null != WorkerThread) {

				Cancelled = true;
				WorkerThread.Thread.Abort();
			}
		}

		/// <summary>
		/// Cancel button pressed.
		/// </summary>
		private void OnCancel(object sender, RoutedEventArgs e) => Cancel();

		/// <summary>
		/// Main window is closed.
		/// </summary>
		private void OnClosing(object sender, CancelEventArgs e) => Cancel();

		/// <summary>
		/// Clears locator data.
		/// </summary>
		private async void OnClear(object sender, RoutedEventArgs e)
		{
			Locators = new Locator[0];
			await ShowLocators();
			SetStatus("Locator(s) cleared.");
		}

		/// <summary>
		/// Updates locator display with new set of locators.
		/// </summary>
		private async Task ShowLocators()
		{
			WithUiThread(() => LocatorList.Children.Clear());

			var r = Task.Run(() =>
			{
				WithUiThread(() =>
				{
					var panels = Locators.Select(m => new LocatorPanel(m)).ToArray();

					foreach (var panel in Panels = Locators.Select(m => new LocatorPanel(m)).ToArray()) LocatorList.Children
						//.Add(WaitedAdd(panel))
						.Add(panel)
						;
				});
			});

			await r;

			Update();
		}

		/// <summary>
		/// Updates locator information.
		/// </summary>
		internal void Update()
		{
			LocatorHeader.UpdateFrom(Locators);

			StartButton.IsEnabled = Locators.Length > 0 && null == WorkerThread;
		}

		/// <summary>
		/// Resizes locator display.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSizeChanged(object sender, SizeChangedEventArgs e) => LocatorDisplay.Resize(LeftPanel.ActualHeight - StatusBar.ActualHeight);

		/// <summary>
		/// Executes an action within the UI thread.
		/// </summary>
		internal void WithUiThread(Action a) => Dispatcher?.Invoke(a);

		/// <summary>
		/// Sets status bar text.
		/// </summary>
		internal static void SetStatus(string s = "Ready") => Instance.StatusLabel.Content = s;
	}
}
