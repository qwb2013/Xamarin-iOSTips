using System;
using System.Net;
using System.Threading.Tasks;

using UIKit;

using static System.Diagnostics.Debug;

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
				WriteLine (e.Html);
			};

			btnWebClient.TouchUpInside += async (sender, e) => { 
				var result = await Worker.DownloadHtmlString ("https://stackoverflow.com");

				WriteLine ($"這是直接使用回傳結果 { result.Length }");
			
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

			public async Task<string> DownloadHtmlString (string url)
			{
				var task = MyWebClient.DownloadStringTaskAsync (url);
				var result = await task;

				EventHandler<HtmlReceivedEventArgs> handler = HtmlStringReceived;
				var args = new HtmlReceivedEventArgs { Html = result };
				if (null != handler) {
					handler (this, args);
				}

				return result;
			}
			public event EventHandler<HtmlReceivedEventArgs> HtmlStringReceived;
		}
		public class HtmlReceivedEventArgs : EventArgs
		{
			public string Html { get; set; }
		}
	}
}


