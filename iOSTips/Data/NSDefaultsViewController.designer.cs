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
	[Register ("NSDefaultsViewController")]
	partial class NSDefaultsViewController
	{
		[Outlet]
		UIKit.UIButton btnReadKeyChain { get; set; }

		[Outlet]
		UIKit.UIButton btnReadNSDefaults { get; set; }

		[Outlet]
		UIKit.UIButton btnWriteKeyChain { get; set; }

		[Outlet]
		UIKit.UIButton btnWriteNSDefaults { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnWriteKeyChain != null) {
				btnWriteKeyChain.Dispose ();
				btnWriteKeyChain = null;
			}

			if (btnReadKeyChain != null) {
				btnReadKeyChain.Dispose ();
				btnReadKeyChain = null;
			}

			if (btnWriteNSDefaults != null) {
				btnWriteNSDefaults.Dispose ();
				btnWriteNSDefaults = null;
			}

			if (btnReadNSDefaults != null) {
				btnReadNSDefaults.Dispose ();
				btnReadNSDefaults = null;
			}
		}
	}
}
