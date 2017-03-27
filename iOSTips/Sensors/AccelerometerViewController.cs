using System;

using UIKit;
using Foundation;
using CoreMotion;

using System.Diagnostics;

namespace iOSTips
{
	public partial class AccelerometerViewController : UIViewController
	{
		CMMotionManager manager;

		public AccelerometerViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var operationQueue = new NSOperationQueue();
			manager = new CMMotionManager();
			manager.AccelerometerUpdateInterval = 1 / 60;

			if (manager.AccelerometerAvailable) {


				manager.StartAccelerometerUpdates(operationQueue, ProcessAccelerometerData);


			}

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ProcessAccelerometerData(CoreMotion.CMAccelerometerData data, NSError error) {

			if (null != error)
			{
				manager.StopAccelerometerUpdates();
				Debug.WriteLine($"X:{ data.Acceleration.X }; Y:{ data.Acceleration.Y }; Z:{ data.Acceleration.Z }");


			}
			else
			{
				Debug.WriteLine(error.LocalizedDescription);
			}
		}
	}
}

