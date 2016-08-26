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
	[Register ("SQLiteViewController")]
	partial class SQLiteViewController
	{
		[Outlet]
		UIKit.UIButton btnCreateDatabaseAndDataTable { get; set; }

		[Outlet]
		UIKit.UIButton btnReadRecord { get; set; }

		[Outlet]
		UIKit.UIButton btnUpdateRecord { get; set; }

		[Outlet]
		UIKit.UIButton btnWriteRecord { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCreateDatabaseAndDataTable != null) {
				btnCreateDatabaseAndDataTable.Dispose ();
				btnCreateDatabaseAndDataTable = null;
			}

			if (btnWriteRecord != null) {
				btnWriteRecord.Dispose ();
				btnWriteRecord = null;
			}

			if (btnReadRecord != null) {
				btnReadRecord.Dispose ();
				btnReadRecord = null;
			}

			if (btnUpdateRecord != null) {
				btnUpdateRecord.Dispose ();
				btnUpdateRecord = null;
			}
		}
	}
}
