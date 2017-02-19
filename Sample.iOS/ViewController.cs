using System;
using System.Threading.Tasks;
using UIKit;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
			Tests();
        }

		async void Tests()
		{
			UIWebView webView = new UIWebView(View.Bounds);
			// Ajout du contrôle en tant que sous au contrôleur principal
			View.AddSubview(webView);

			//await TestUri(webView);

			await TestScalesPageToFitAsync(webView);
		}

		async Task TestUri(UIWebView webView)
		{
			// Création de l’uri
			var uri = new Uri("http://www.google.fr");
			webView.LoadRequest(new Foundation.NSUrlRequest(uri));

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