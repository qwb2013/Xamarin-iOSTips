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
	[Register ("QRCodeViewController")]
	partial class QRCodeViewController
	{
		[Outlet]
		UIKit.UIButton btnScan { get; set; }

		[Outlet]
		UIKit.UILabel lbResult { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnScan != null) {
				btnScan.Dispose ();
				btnScan = null;
			}

			if (lbResult != null) {
				lbResult.Dispose ();
				lbResult = null;
			}
		}
	}
}
