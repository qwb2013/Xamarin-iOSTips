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
	[Register ("LocalNotificationViewController")]
	partial class LocalNotificationViewController
	{
		[Outlet]
		UIKit.UIButton btnSend { get; set; }

		[Outlet]
		UIKit.UITextField txtMessage { get; set; }

		[Outlet]
		UIKit.UITextField txtTime { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnSend != null) {
				btnSend.Dispose ();
				btnSend = null;
			}

			if (txtTime != null) {
				txtTime.Dispose ();
				txtTime = null;
			}

			if (txtMessage != null) {
				txtMessage.Dispose ();
				txtMessage = null;
			}
		}
	}
}
