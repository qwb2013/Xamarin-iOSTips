using System;

using UIKit;
using Security;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class NSDefaultsViewController : UIViewController
	{
		public NSDefaultsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// 
			#region Buttons' Event

			btnWriteKeyChain.TouchUpInside += (sender, e) => {
				SaveRecord ();
			} ;

			btnReadKeyChain.TouchUpInside += (sender, e) => {
				QueryRecord ();
			};

			btnWriteNSDefaults.TouchUpInside += (sender, e) => {
				SaveNSDefaults ("demo", $"Hi, Xamarin { DateTime.Now.ToLongTimeString() }");
			};

			btnReadNSDefaults.TouchUpInside += (sender, e) => {
				ReadNSDefaults ("demo");
			};

			#endregion
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void SaveRecord () {

			var record = new SecRecord (SecKind.GenericPassword) { 
				Label = "交易密碼",
				Description = "用於xxx服務",
				Account = "liddle.fang@gmail.com",
				Service = "Transcation",
				Comment = "Demo",
				ValueData = NSData.FromString("P@ssw0rd"),
				Generic = NSData.FromString("SecurityChainDemo")
			};

			var status = SecKeyChain.Add (record);

			if (SecStatusCode.Success == status) {
				Debug.WriteLine ("Keychain Saved!");
			}
			else if (SecStatusCode.DuplicateItem == status || SecStatusCode.DuplicateKeyChain == status) {
				Debug.WriteLine ("Duplicate !");
				SecKeyChain.Remove (record);
			} 
			else {
				Debug.WriteLine ($"{ status }");
			}

		}

		private string QueryRecord () {

			SecStatusCode status;

			var rec = new SecRecord (SecKind.GenericPassword) {
				Generic = NSData.FromString ("SecurityChainDemo")
			};

			var match = SecKeyChain.QueryAsRecord (rec, out status);

			if (SecStatusCode.Success == status && null != match ) {

				Debug.WriteLine ($"{match.Account};{match.ValueData.ToString()}");

				return match.Account;
			}

			Debug.WriteLine ("Nothing found.");
			return string.Empty;

		}

		public void SaveNSDefaults (string key, string item)
		{
			NSUserDefaults.StandardUserDefaults.SetString (item, key);
			NSUserDefaults.StandardUserDefaults.Synchronize ();

			Debug.WriteLine ($"{ item } Saved!");
		}

		public string ReadNSDefaults (string key)
		{
			var stored = NSUserDefaults.StandardUserDefaults.StringForKey (key);

			Debug.WriteLine ($"stored:{stored}!");

			return stored;
		}
	}
}


