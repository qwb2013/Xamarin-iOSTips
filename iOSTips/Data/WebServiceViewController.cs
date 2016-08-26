using System;
using System.Net;
using System.Threading.Tasks;

using UIKit;

using Debug = System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class WebServiceViewController : UIViewController
	{
		private WebWorker Worker { get; set; }

		public WebServiceViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// 
			Worker = new WebWorker ();

			Worker.HtmlStringReceived += (sender, e) => {
				Debug.WriteLine (e.Html);
			};

			btnWebClient.TouchUpInside += (sender, e) => { 
				Task.Run(() => { Worker.DownloadHtmlString ("https://stackoverflow.com"); });
			};


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public class WebWorker
		{

			private WebClient MyWebClient { get; set; }

			public WebWorker ()
			{
				MyWebClient = new WebClient ();
			}

			public async Task DownloadHtmlString (string url)
			{

				var resultString = MyWebClient.DownloadString (url);

				EventHandler<HtmlReceivedEventArgs> handler = HtmlStringReceived;
				var args = new HtmlReceivedEventArgs { Html = resultString };
				if (null != handler) {
					handler (this, args);
				}
			}

			public event EventHandler<HtmlReceivedEventArgs> HtmlStringReceived;
		}

		public class HtmlReceivedEventArgs : EventArgs
		{
			public string Html { get; set; }
		}
	}
}


