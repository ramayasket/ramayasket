using System.Linq;
using System.Windows.Controls;

namespace Ramayasket.Quipu
{
	/// <summary>
	/// Interaction logic for LocatorHeader.xaml
	/// </summary>
	public partial class MainHeader : UserControl
	{
		/// <summary/>
		public MainHeader() => InitializeComponent();

		/// <summary>
		/// Updates count value from locator data.
		/// </summary>
		/// <param name="locators">Locator data.</param>
		internal void UpdateFrom(Locator[] locators)
		{
			ValidUrls.Content = locators.Count(m => m.IsValid);
			ReadUrls.Content = locators.Count(m => m.IsRead);
			HtmlUrls.Content = locators.Count(m => m.IsHtml);
			MaxHrefs.Content = locators.Length > 0 ? locators.Max(m => m.Hrefs) : 0;
		}
	}
}
