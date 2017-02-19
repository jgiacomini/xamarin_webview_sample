using System;

using UIKit;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
            UIWebView webView = new UIWebView(View.Bounds);
            // Ajout du contrôle en tant que sous au contrôleur principal
            View.AddSubview(webView);
            // Création de l’uri
            var uri = new Uri("https://www.google.fr");
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