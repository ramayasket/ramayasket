using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using Kw.Common;

namespace Ramayasket.Quipu
{
	/// <summary>
	/// Quipu skills demonstration entry point.
	/// </summary>
	internal class Program : Application
	{

		[STAThread]
		public static void Main()
		{
			//
			//	Suppress data binding errors
			//
			PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Critical;

			var app = new Program();

			Quipu.MainWindow.SetStatus();

			app.Run(Quipu.MainWindow.Instance);
		}
	}
}
