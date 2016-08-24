using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using CoreMedia;
using CoreVideo;
using Foundation;
using AVFoundation;
using CoreGraphics;


namespace iOSTips
{
	public partial class CameraViewController : UIViewController
	{
		
		public CameraViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Camera";

			//
			btnUIImagePickerViewController.TouchUpInside += (object sender, EventArgs e) => {

				UIImagePickerController imagePickerViewController;

				imagePickerViewController = new UIImagePickerController();

				imagePickerViewController.SourceType = UIImagePickerControllerSourceType.Camera ;

				imagePickerViewController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary );

				imagePickerViewController.FinishedPickingMedia += (object qsender, UIImagePickerMediaPickedEventArgs ie) => {

					resultImageView.Image = ie.OriginalImage;

					imagePickerViewController.DismissViewControllerAsync( true );
				};

				imagePickerViewController.Canceled += (object psender, EventArgs pe) => {


					imagePickerViewController.DismissViewControllerAsync( true );
				};

				PresentViewController( imagePickerViewController, true, null);

			};






		}
	}
}
