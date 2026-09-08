using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
	public sealed partial class MainMenu_pseudo : Page
	{
		public MainMenu_pseudo()
		{
			InitializeComponent();
		}

		private void pageLoaded(object sender, RoutedEventArgs e)
		{
			ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(256, 384));

			CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

			ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

			titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.White;
		}
	}
}