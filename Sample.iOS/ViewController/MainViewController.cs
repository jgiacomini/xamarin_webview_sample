using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Sample.iOS
{
	public class MainViewController : UIViewController
	{
		public UIWebView WebView
		{
			get;
			set;
		}
		public MainViewController()
		{
			Tests();
			NavigationItem.Title = "WebView";
		}

		async void Tests()
		{
			UIWebView webView = new UIWebView(View.Bounds);
			WebView = webView;


			// Ajout du contrôle en tant que sous au contrôleur principal
			View.AddSubview(webView);

			TestEvents(webView);

			await TestUriAsync(webView);

			await TestScalesPageToFitAsync(webView);

			await TestLocalEmbbededHtmlPageAsync(webView);

			await TestLocalHtmlPageAsync(webView);

		}



		async Task TestUriAsync(UIWebView webView)
		{
			// Création de l’uri
			var uri = new Uri("http://www.google.fr");
			webView.LoadRequest(new NSUrlRequest(uri));

			await Task.Delay(5000);
		}

		async Task TestScalesPageToFitAsync(UIWebView webView)
		{
			// Url du blog de James Montemagno
			var uri = new Uri("http://motzcod.es/");

			// par défaut la web view est en ScalesPageToFit à false
			webView.ScalesPageToFit = false;
			webView.LoadRequest(new Foundation.NSUrlRequest(uri));
			await Task.Delay(5000);

			// On réaffiche le même site web avec en ScalesPageToFit à true
			webView.ScalesPageToFit = true;
			// On recharge la page web
			webView.LoadRequest(new Foundation.NSUrlRequest(uri));
			await Task.Delay(5000);
		}

		async Task TestLocalEmbbededHtmlPageAsync(UIWebView webView)
		{
			var pageName = "Content/InAppHtmlPage.html";
			string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, pageName);

			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			await Task.Delay(5000);
		}

		async Task TestLocalHtmlPageAsync(UIWebView webView)
		{
			// Dossier ou iOS
			string contentDirectory = Path.Combine(NSBundle.MainBundle.BundlePath, "Content/");

			// Flux html à afficher dans la UIWebView
			string html = "<html><body><h1>Hello</h1><br /><span>Voici une page web issue d'une chaîne de caractères.</span></body></html>";

			// Chargement de la string de la page html
			webView.LoadHtmlString(html, new NSUrl(contentDirectory, true));

			await Task.Delay(5000);

			html = "<html><body><h1>Hello</h1><br /> <img src=\"xamarin.png\" alt=\"Xamarin logo\" height=\"200\" width=\"200\"> </body></html>";
			// Chargement de la string de la page html
			webView.LoadHtmlString(html, new NSUrl(contentDirectory, true));
		}

		void TestEvents(UIWebView webView)
		{
			webView.LoadStarted += WebView_LoadStarted;
			webView.LoadError += WebView_LoadError;
			webView.LoadFinished += WebView_LoadFinished;

			webView.LoadRequest(new NSUrlRequest(new NSUrl("http://www.unepageinexistante.com")));
		}

		void WebView_LoadStarted(object sender, EventArgs e)
		{
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			Debug.WriteLine("Chargement d'un élément de la page");
		}

		void WebView_LoadError(object sender, UIWebErrorArgs e)
		{
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
			Debug.WriteLine("Erreur lors d'un élément de la page");
			Debug.WriteLine(e.Error.LocalizedDescription);
			Debug.WriteLine(e.Error.LocalizedFailureReason);
		}

		void WebView_LoadFinished(object sender, EventArgs e)
		{
			if (!WebView.IsLoading)
			{
				Debug.WriteLine("Page chargée");
			}			
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
