using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kw.Common;

namespace Ramayasket.Quipu // ReSharper disable SuspiciousTypeConversion.Global
{
	/// <summary>
	/// UI representation of a locator.
	/// </summary>
	public partial class LocatorPanel : UserControl
	{
		public LocatorPanel() => InitializeComponent();

		/// <summary>
		/// Locator object.
		/// </summary>
		internal Locator Locator { get; }

		/// <summary>
		/// Creates locator panel from a locator.
		/// </summary>
		/// <param name="locator"></param>
		internal LocatorPanel(Locator locator)
		{
			Locator = locator;
			InitializeComponent();

			Url.ToolTip = Url.Content = locator.Uri?.AbsoluteUri;

			((INotifyPropertyChanged) locator).PropertyChanged +=
				(s, e) => {

					Dispatcher?.Invoke(() => MainWindow.Instance.Update());
					Update(e);
				};

		}

		internal void Update(PropertyChangedEventArgs args)
		{
			var data = new string((Locator.Data ?? "").Take(100).ToArray()).Replace(Environment.NewLine, " ");

			switch (args.PropertyName)
			{
				case "IsRead":
					if(Locator.IsRead)
						WithUiThread(() => Data.Content = data);
					else
						WithUiThread(() => Data.Content = "");
					break;

				case "IsHtml":
					if (Locator.IsHtml)
						WithUiThread(() => Hrefs.Content = Locator.Hrefs);
					else
						WithUiThread(() => Hrefs.Content = "0");
					break;

				case "Error":
					switch (Locator.Error) {

						case LocatorError.Download:
							WithUiThread(() => Data.Content = "Error"); break;

						case LocatorError.Markup:
							WithUiThread(() => Hrefs.Content = "Error"); break;
					}
					break;
			}
		}

		/// <summary>
		/// Selects panel as winner.
		/// </summary>
		internal void Select(bool yes = true) => WithUiThread(() => Winner.Visibility = yes ? Visibility.Visible : Visibility.Hidden);

		/// <summary>
		/// Executes an action within the UI thread.
		/// </summary>
		internal void WithUiThread(Action a) => Dispatcher?.Invoke(a);
	}
}
