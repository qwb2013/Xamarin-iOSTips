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
	[Register ("LocationViewController")]
	partial class LocationViewController
	{
		[Outlet]
		UIKit.UIButton btnLocation { get; set; }

		[Outlet]
		UIKit.UILabel lbMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbMessage != null) {
				lbMessage.Dispose ();
				lbMessage = null;
			}

			if (btnLocation != null) {
				btnLocation.Dispose ();
				btnLocation = null;
			}
		}
	}
}
