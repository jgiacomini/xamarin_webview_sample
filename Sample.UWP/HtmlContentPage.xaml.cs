using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class HtmlContentPage : Page
    {
        public HtmlContentPage()
        {
            this.InitializeComponent();
            myWebView.NavigationStarting += MyWebView_NavigationStarting;
            myWebView.NavigationCompleted += MyWebView_NavigationCompleted;
            myWebView.NavigationFailed += MyWebView_NavigationFailed;
        }

        private void MyWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            // Gestion du début de navigation
        }

        private void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            // Gestion de la complétion de navigation
        }

        private void MyWebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            // Gestion des erreurs de navigation
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var htmlContent = "<html><body><h1>Hello</h1><br /><span>Voici une page web issue d'une chaîne de caractères.</span></body></html>";
            myWebView.NavigateToString(htmlContent);

            base.OnNavigatedTo(e);
        }
    }
}
