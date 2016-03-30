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
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			// 需要使用者授權，才能發出 Notification
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes (
					UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);

				application.RegisterUserNotificationSettings (notificationSettings);

				UIApplication.SharedApplication.RegisterForRemoteNotifications ();
			} 


			if (launchOptions != null)
			{
				// 如果是因為 Local Notification 啟動 App 
				if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
				{
					var localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
					if (localNotification != null)
					{
						// 
						Debug.WriteLine("Start with Local Notification");

						UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
					}
				}
			}

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		public override void ReceivedLocalNotification (UIApplication application, UILocalNotification notification)
		{
			Debug.WriteLine("Start with Local Notification : " + notification.AlertBody);
			
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;	
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			var DeviceToken = deviceToken.Description;
			if (!string.IsNullOrWhiteSpace(DeviceToken)) {
				DeviceToken = DeviceToken.Trim('<').Trim('>');
			}
				
			var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

			if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
			{
				
			}

			Debug.WriteLine ("DeviceToken:" + DeviceToken );

			NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application, NSError error)
		{
			
		}

		public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)
		{
			

			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;	
		}
	}
}


