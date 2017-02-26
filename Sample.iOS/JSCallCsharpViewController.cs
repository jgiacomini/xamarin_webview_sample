using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Sample.iOS
{
	public class JSCallCsharpViewController : UIViewController
	{
		public JSCallCsharpViewController()
		{
			View.BackgroundColor = UIColor.White;

			UIWebView webView = new UIWebView(View.Bounds);
			webView.ShouldStartLoad = OnStartLoad;

			// Recherche du chemin de la ressource 
			string htmlPath = NSBundle.MainBundle.PathForResource("javascript_callcsharp", "html");
			// Lecture du flux html
			string htmlContents = File.ReadAllText(htmlPath);
			// Chargement de la string de la page html
			webView.LoadHtmlString(htmlContents, null);

			// Ajout du contrôle en tant que sous au contrôleur principal
			View.AddSubviews(webView);

		}
			
		private bool OnStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			// On vérifie que c'est bien la bonne url qui appelle notre code C#
			if (request.MainDocumentURL.ToString() == "callios://functionTest")
			{
				// On affiche une alerte
				new UIAlertView("Valider", "Fonction C# invoquée", null, "ok", null).Show();
			}
			return true;
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

