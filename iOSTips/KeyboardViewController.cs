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
	public partial class KeyboardViewController : UIViewController
	{
		MTMBProgressHUD _hud;
		int _currentKeyboardHight;

		public KeyboardViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Keyboard and UITextField";

			#region WebView

			webView.ShouldStartLoad = 
				delegate(UIWebView webView, 
					NSUrlRequest request, 
					UIWebViewNavigationType navigationType) {

				var requestString = request.Url.AbsoluteString;

				if( requestString.StartsWith("liddle://") ){
					var components = requestString.Split ( new[]{ @"://"}, StringSplitOptions.None);

					if (components.Length > 1 && components [0].ToLower() == @"liddle".ToLower()) {

						if (components [1] == @"Hi") {

							UIAlertController alert = UIAlertController.Create (@"Hi Title", @"當然是世界好", UIAlertControllerStyle.Alert);


							UIAlertAction okAction = UIAlertAction.Create (@"OK", UIAlertActionStyle.Default, (action) => {
								Console.WriteLine(@"OK");
							});
							alert.AddAction (okAction);


							UIAlertAction cancelAction = UIAlertAction.Create (@"Cancel", UIAlertActionStyle.Default, (action) =>{
								Console.WriteLine(@"Cancel");
							});
							alert.AddAction (cancelAction);

							PresentViewController (alert, true, null);


							return false;
						}

					}


				}

				return true;

			};

			webView.LoadFinished += (object sender, EventArgs e) => {

				InvokeOnMainThread(()=>{
					_hud.Hide (animated: true, delay: 5);
				});


				if( txtUrl.IsFirstResponder ){
					txtUrl.ResignFirstResponder();
				}

			};

			webView.LoadError += (object sender, UIWebErrorArgs e) => {

				Debug.WriteLine(e.Error.LocalizedDescription);

				InvokeOnMainThread(()=>{
					_hud.Hide (animated: true, delay: 5);
				});

				if( txtUrl.IsFirstResponder ){
					txtUrl.ResignFirstResponder();
				}
			};

			#endregion

			#region UITextField

			txtUrl.Placeholder = @"請輸入網址";
			txtUrl.KeyboardType = UIKeyboardType.Url;
			txtUrl.SecureTextEntry = false ;

			// return true ;
			txtUrl.ShouldReturn += (textField) => {
				if( textField.IsFirstResponder ){
					textField.ResignFirstResponder();
					// v.s.
					//textField.BecomeFirstResponder();

				}

				return true;
			};

			// return true ;
			txtUrl.ShouldChangeCharacters = (textField, range, replacementString) => {

				return true;

				/*
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 25;
				*/
			};

			txtUrl.EditingDidBegin += (object sender, EventArgs e) => {

				if( sender is UITextField ){
					

				}
			};

			txtUrl.EditingDidEnd += (object sender, EventArgs e) => {
				// Compare with "webView.LoadFinished"
				if( txtUrl.IsFirstResponder ){
					txtUrl.ResignFirstResponder();
				}
			};

			#endregion

			btnGo.TouchUpInside += (object sender, EventArgs e) => {

				string urlString = txtUrl.Text.Trim() ;

				var alertController = UIAlertController.Create ("網址", urlString, UIAlertControllerStyle.Alert);

				var acceptAction = UIAlertAction.Create ("確認", UIAlertActionStyle.Default, (action)=>{ 
					InvokeOnMainThread(()=>{

						_hud = new MTMBProgressHUD (View) {
							LabelText = "Waiting...",
							RemoveFromSuperViewOnHide = true
						};

						View.AddSubview (_hud);
						_hud.Show (animated: true);

					});

					webView.LoadRequest( new NSUrlRequest( new NSUrl(urlString )));
				});

				var cancelAction = UIAlertAction.Create ("取消", UIAlertActionStyle.Cancel, (action) => {

				});

				// Add the actions.
				alertController.AddAction (acceptAction);
				alertController.AddAction (cancelAction);

				InvokeOnMainThread(()=>{
					PresentViewController (alertController, true, null);
				});
			};


			UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer (()=>{
				if( txtUrl.IsFirstResponder ){
					txtUrl.ResignFirstResponder();

				}
			});
			this.View.AddGestureRecognizer (tapGestureRecognizer);

			NSNotificationCenter.DefaultCenter.AddObserver( UIKeyboard.WillChangeFrameNotification, UIKeyboardWillChangeFrameNotification);
			NSNotificationCenter.DefaultCenter.AddObserver( UIKeyboard.WillHideNotification, UIKeyboardWillHideNotification);


		}

		private void UIKeyboardWillHideNotification (NSNotification notification){
			NSString key = new NSString(UIKeyboard.FrameEndUserInfoKey.ToString());

			NSObject objRect = notification.UserInfo[key];

			if (objRect is NSValue) {
				var v = (NSValue)objRect;

				var rect = v.RectangleFValue;

				_currentKeyboardHight = (int)rect.Height;

				Debug.WriteLine ("Hide Keyboard Height:{0}", _currentKeyboardHight);
				txtUrlBottomConstraint.Constant = 5;
			}
		}

		private void UIKeyboardWillChangeFrameNotification(NSNotification notification){
			if(notification.UserInfo.ContainsKey( new NSString(UIKeyboard.FrameBeginUserInfoKey.ToString()))){


				NSString key = new NSString(UIKeyboard.FrameEndUserInfoKey.ToString());

				NSObject objRect = notification.UserInfo[key];

				if (objRect is NSValue) {
					var v = (NSValue)objRect;

					var rect = v.RectangleFValue;

					_currentKeyboardHight = (int)rect.Height;

					Debug.WriteLine ("Change Keyboard Height:{0}", _currentKeyboardHight);
					txtUrlBottomConstraint.Constant = _currentKeyboardHight + 5;
				}
			}
		}


		private bool IsUrl(string inputString){

			Regex urlchk = new Regex(@"((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,15})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			return urlchk.IsMatch (inputString);
		}
	}
}
