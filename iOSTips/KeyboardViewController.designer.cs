// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSTips
{
	[Register ("KeyboardViewController")]
	partial class KeyboardViewController
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtUrl { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint txtUrlBottomConstraint { get; set; }

		[Outlet]
		UIKit.UIWebView webView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtUrlBottomConstraint != null) {
				txtUrlBottomConstraint.Dispose ();
				txtUrlBottomConstraint = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (txtUrl != null) {
				txtUrl.Dispose ();
				txtUrl = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}
}
