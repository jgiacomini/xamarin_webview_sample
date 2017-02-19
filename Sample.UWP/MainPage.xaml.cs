using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sample.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnExternalWebPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExternalWebPage));
        }

        private void btnInAppHtmlPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InAppHtmlPage));
        }

        private void btnHtmlContentPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HtmlContentPage));
        }
    }
}
