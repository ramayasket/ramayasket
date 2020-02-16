using System;
using System.Linq;
using System.Net;
using Kw.Aspects;
using Kw.Common;

namespace Ramayasket.Quipu	// ReSharper disable EmptyGeneralCatchClause
{
	/// <summary>
	/// Possible URL errors.
	/// </summary>
	internal enum LocatorError
	{
		None = 0,

		/// <summary>
		/// Download error.
		/// </summary>
		Download,

		/// <summary>
		/// HTML markup error.
		/// </summary>
		Markup,
	}

	/// <summary>
	/// A locator related to a single URL.
	/// </summary>
	[NotifyPropertyChanged]
	internal class Locator
	{
		/// <summary>
		/// Locator Uri.
		/// </summary>
		public Uri Uri { get; }

		/// <summary>
		/// Is the URL valid?
		/// </summary>
		public bool IsValid { get; }

		/// <summary>
		/// Has the URL been read?
		/// </summary>
		public bool IsRead { get; private set; }

		/// <summary>
		/// Downloaded data.
		/// </summary>
		public string Data { get; private set; }

		/// <summary>
		/// Number of 'a' tags.
		/// </summary>
		public int Hrefs { get; private set; }

		/// <summary>
		/// Is the read data in HTML format?
		/// </summary>
		public bool IsHtml { get; private set; }

		public LocatorError Error { get; private set; }

		/// <summary>
		/// Creates locator from URL string.
		/// </summary>
		/// <param name="url"></param>
		public Locator(string url)
		{
			try {

				Uri = new Uri(url, UriKind.Absolute);
				IsValid = Uri.Scheme.In(Uri.UriSchemeHttp, Uri.UriSchemeHttps);
			}
			catch { }
		}

		/// <summary>
		/// Cleans locator work results.
		/// </summary>
		public void Reset()
		{
			Data = null;
			IsRead = IsHtml = false;
			Hrefs = 0;
		}

		/// <summary>
		/// Processes current URL.
		/// </summary>
		public void Process()
		{
			try
			{
				// download data by URL.

				using (var wc = new WebClient())
				{
					Data = wc.DownloadString(Uri);
					IsRead = true;
				}
			}
			catch {

				Error = LocatorError.Download;
			}

			if (IsRead)
				try { // analyze tags by a third-party parser.

					if(!Data.Contains("<html"))
						throw new FormatException();

					var parser = new HtmlParser(Data);
					while (parser.ParseNext("a", out _))
						Hrefs++;

					IsHtml = true;
				}
				catch {

					Error = LocatorError.Markup;
				}
		}
	}
}