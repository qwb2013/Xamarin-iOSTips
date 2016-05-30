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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView tipsTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tipsTable != null) {
				tipsTable.Dispose ();
				tipsTable = null;
			}
		}
	}
}
