// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSTips
{
	[Register ("WebServiceViewController")]
	partial class WebServiceViewController
	{
		[Outlet]
		UIKit.UIButton btnWebClient { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnWebClient != null) {
				btnWebClient.Dispose ();
				btnWebClient = null;
			}
		}
	}
}
