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
	[Register ("CameraViewController")]
	partial class CameraViewController
	{
		[Outlet]
		UIKit.UIButton btnAVFoundation { get; set; }

		[Outlet]
		UIKit.UIButton btnUIImagePickerViewController { get; set; }

		[Outlet]
		UIKit.UIImageView resultImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnAVFoundation != null) {
				btnAVFoundation.Dispose ();
				btnAVFoundation = null;
			}

			if (resultImageView != null) {
				resultImageView.Dispose ();
				resultImageView = null;
			}

			if (btnUIImagePickerViewController != null) {
				btnUIImagePickerViewController.Dispose ();
				btnUIImagePickerViewController = null;
			}
		}
	}
}
