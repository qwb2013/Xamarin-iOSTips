using System;

using UIKit;

using static System.Console;

namespace iOSTips
{
	public partial class TouchGestureViewController : UIViewController
	{
		private double Distance { get; set; }

		public TouchGestureViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Touch";

			UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer ((UITapGestureRecognizer recognizer) => {
				WriteLine ("Tap !");

				var locationTop = recognizer.LocationInView (topView);
				var locationBottom = recognizer.LocationInView (bottomView);

				var isInTop = locationTop.X < topView.Bounds.Width && locationTop.X > 0
										 && locationTop.Y > 0 && locationTop.Y < topView.Bounds.Height;
				var isInBottom = locationBottom.X < bottomView.Bounds.Width && locationBottom.X > 0
										 && locationBottom.Y > 0 && locationBottom.Y < bottomView.Bounds.Height;

				lbMessage.Text = $"Top:{isInTop}:X:{locationTop.X};Y:{locationTop.Y};Bottom:{isInBottom}:X:{locationBottom.X};Y:{locationBottom.Y};";

				if (isInTop) {
					topView.BackgroundColor = UIColor.FromRGB (0, 128, 255);
					bottomView.BackgroundColor = UIColor.FromRGB (0, 128, 0);
				} 
				else if (isInBottom) {
					bottomView.BackgroundColor = UIColor.FromRGB (0, 128, 255);
					topView.BackgroundColor = UIColor.FromRGB (0, 128, 0);
				} 
				else { 
					topView.BackgroundColor = UIColor.FromRGB (255, 255, 0);
					bottomView.BackgroundColor = UIColor.FromRGB (255, 255, 0);
				}



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
			WriteLine ($"count:{ touches.Count }");

			base.TouchesBegan (touches, evt);
		}

		public override void TouchesMoved (Foundation.NSSet touches, UIEvent evt)
		{
			
			if (2 == touches.Count) {
				

				var locations = touches.ToArray<UITouch> () ;

				UITouch loc0 = locations [0];
				var p0 = loc0.LocationInView (this.View);

				UITouch loc1 = locations [1];
				var p1 = loc1.LocationInView (this.View);

				double distance = Math.Sqrt ( Math.Pow ((p0.X - p1.X), 2.0) + Math.Pow ((p0.Y - p1.Y), 2.0));

				if (Distance > distance) {
					lbMessage.Text = $"兩指接近; distance:{distance}";

					topView.BackgroundColor = UIColor.FromRGB (255, 0, 0);
					bottomView.BackgroundColor = UIColor.FromRGB (255, 0, 0);
				} 
				else { 
					lbMessage.Text = $"兩指離開; distance:{distance}";

					topView.BackgroundColor = UIColor.FromRGB (0, 0, 255);
					bottomView.BackgroundColor = UIColor.FromRGB (0, 0, 255);
				}



				Distance = distance;


			}
		}

		public override void TouchesEnded (Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);
		}

		#endregion

	}
}


