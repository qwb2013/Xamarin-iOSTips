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
	[Register ("FileIOViewController")]
	partial class FileIOViewController
	{
		[Outlet]
		UIKit.UIButton btnReadFile { get; set; }

		[Outlet]
		UIKit.UIButton btnWriteFile { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnWriteFile != null) {
				btnWriteFile.Dispose ();
				btnWriteFile = null;
			}

			if (btnReadFile != null) {
				btnReadFile.Dispose ();
				btnReadFile = null;
			}
		}
	}
}
