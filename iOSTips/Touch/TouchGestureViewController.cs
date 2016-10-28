using System;

using UIKit;

using Debug = System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class TouchGestureViewController : UIViewController
	{
		public TouchGestureViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Touch";

			UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer (() => {
				Debug.WriteLine ("Tap !");

				//tapGestureRecognizer.LocationInView( 
			});

			this.View.AddGestureRecognizer (tapGestureRecognizer);

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


		#region Touch Events

		public override void TouchesBegan (Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
		}

		public override void TouchesMoved (Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);
		}

		public override void TouchesEnded (Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);
		}

		#endregion

	}
}


