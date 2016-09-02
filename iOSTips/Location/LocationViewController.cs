using System;

using UIKit;
using CoreLocation;

using Geolocator.Plugin;

using static System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class LocationViewController : UIViewController
	{
		private CLLocationManager LocationManager { get; set; }

		public LocationViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			LocationManager = new CLLocationManager ();
			LocationManager.DesiredAccuracy = 1000;

			LocationManager.RequestAlwaysAuthorization ();
			LocationManager.RequestWhenInUseAuthorization ();

			LocationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {

				if (e.Locations.Length > 0) {
					var location = e.Locations [0];
					WriteLine ($"LocationsUpdated :緯度:{ location.Coordinate.Latitude };經度:{location.Coordinate.Longitude}");

					InvokeOnMainThread (() => {
						lbMessage.Text = $"緯度:{ location.Coordinate.Latitude.ToString("F4") };經度:{location.Coordinate.Longitude.ToString ("F4") }";
					});

				}
			};


			if (CLLocationManager.LocationServicesEnabled) {

				// 單次要求
				LocationManager.RequestLocation ();

				// 持續更新
				LocationManager.StartUpdatingLocation (); 
			}

			btnLocation.TouchUpInside += async (sender, e) => {

				LocationManager.StopUpdatingLocation ();

				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;

				var position = await locator.GetPositionAsync (timeoutMilliseconds: 10000);

				InvokeOnMainThread (() => {
					lbMessage.Text = $"Position 緯度:{ position.Latitude.ToString ("F4") };經度:{position.Longitude.ToString ("F4") }";
				});

				Console.WriteLine ("Position Status: {0}", position.Timestamp);
				Console.WriteLine ("Position Latitude: {0}", position.Latitude);
				Console.WriteLine ("Position Longitude: {0}", position.Longitude);
			
			};

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


