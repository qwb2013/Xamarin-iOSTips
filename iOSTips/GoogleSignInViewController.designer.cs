// WARNING
//
// This file has been generated automatically by Xamarin Studio Business to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSTips
{
	[Register ("GoogleSignInViewController")]
	partial class GoogleSignInViewController
	{
		[Outlet]
		UIKit.UIButton btnConnect { get; set; }

		[Outlet]
		Google.SignIn.SignInButton btnSignIn { get; set; }

		[Outlet]
		UIKit.UILabel lbStatus { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnConnect != null) {
				btnConnect.Dispose ();
				btnConnect = null;
			}

			if (btnSignIn != null) {
				btnSignIn.Dispose ();
				btnSignIn = null;
			}

			if (lbStatus != null) {
				lbStatus.Dispose ();
				lbStatus = null;
			}
		}
	}
}
