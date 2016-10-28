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
	[Register ("TouchGestureViewController")]
	partial class TouchGestureViewController
	{
		[Outlet]
		UIKit.UIView bottomView { get; set; }

		[Outlet]
		UIKit.UILabel lbMessage { get; set; }

		[Outlet]
		UIKit.UIView topView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbMessage != null) {
				lbMessage.Dispose ();
				lbMessage = null;
			}

			if (bottomView != null) {
				bottomView.Dispose ();
				bottomView = null;
			}

			if (topView != null) {
				topView.Dispose ();
				topView = null;
			}
		}
	}
}
