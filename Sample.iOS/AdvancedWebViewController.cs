using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Sample.iOS
{
	public class AdvancedWebViewController : UIViewController
	{
		public AdvancedWebViewController()
		{
			View.BackgroundColor = UIColor.White;

			UIButton testButton = UIButton.FromType(UIButtonType.RoundedRect);
			testButton.SetTitle("Invoque une fonction javascript", UIControlState.Normal);
			testButton.TouchUpInside += TestButton_TouchUpInside;
			testButton.SizeToFit();

			testButton.Center = View.Center;
			UIWebView webView = new UIWebView(View.Bounds);
			WebView = webView;

			// Recherche du chemin de la ressource 
			string htmlPath = NSBundle.MainBundle.PathForResource("javascript_example", "html");
			// Lecture du flux html
			string htmlContents = File.ReadAllText(htmlPath);
			// Chargement de la string de la page html
			webView.LoadHtmlString(htmlContents, null);

			// Ajout du contrôle en tant que sous au contrôleur principal
			View.AddSubviews(webView, testButton);

		}

		void TestButton_TouchUpInside(object sender, EventArgs e)
		{
			WebView.EvaluateJavascript("myFunction();");
		}

		public UIWebView WebView
		{
			get;
			set;
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

