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
		private UIImagePickerController _imagePickerViewController;

		public CameraViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//
			btnUIImagePickerViewController.TouchUpInside += (object sender, EventArgs e) => {

				_imagePickerViewController = new UIImagePickerController();

				_imagePickerViewController.SourceType = UIImagePickerControllerSourceType.Camera ;

				_imagePickerViewController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary );

				_imagePickerViewController.FinishedPickingMedia += (object qsender, UIImagePickerMediaPickedEventArgs e) => {



				};

				_imagePickerViewController.Canceled += (object psender, EventArgs pe) => {


				};

				PresentViewController( _imagePickerViewController, true, null);

			};






		}
	}
}
