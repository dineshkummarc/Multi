// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("SqliteScreen")]
	partial class SqliteScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField tbFirst { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbLast { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSave { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView tfOutput { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnClear { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tbFirst != null) {
				tbFirst.Dispose ();
				tbFirst = null;
			}

			if (tbLast != null) {
				tbLast.Dispose ();
				tbLast = null;
			}

			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}

			if (tfOutput != null) {
				tfOutput.Dispose ();
				tfOutput = null;
			}

			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
			}
		}
	}
}
