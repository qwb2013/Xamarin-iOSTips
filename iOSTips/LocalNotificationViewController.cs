using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UIKit;
using Foundation;
using CoreGraphics;

using MBProgressHUD;

using Debug = System.Diagnostics.Debug ;

namespace iOSTips
{
	public partial class LocalNotificationViewController : UIViewController
	{
		public LocalNotificationViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Local Notification";

			btnSend.TouchUpInside += (object sender, EventArgs e) => {

				if( txtTime.IsFirstResponder ){
					txtTime.ResignFirstResponder();
				}

				if( txtMessage.IsFirstResponder ){
					txtMessage.ResignFirstResponder();
				}


				var notification = new UILocalNotification();

				var time = 1 ;

				if( int.TryParse( txtTime.Text.Trim(), out time ) ){
					notification.FireDate = NSDate.FromTimeIntervalSinceNow( time * 60 );
				}
				else{
					notification.FireDate = NSDate.FromTimeIntervalSinceNow( 60 );
				}

				// configure the alert
				notification.AlertAction = "View Alert";
				notification.AlertBody = string.IsNullOrEmpty( txtMessage.Text.Trim() )
					? "許功蓋警告" : txtMessage.Text.Trim() ;

				// modify the badge
				notification.ApplicationIconBadgeNumber = 1;

				// set the sound to be the default sound
				notification.SoundName = UILocalNotification.DefaultSoundName;

				// schedule it
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);


			};

			txtTime.ShouldChangeCharacters = (textField, range, replacement) =>
			{
				int number;
				return replacement.Length == 0 || int.TryParse(replacement, out number);
			};



		}
	}
}
