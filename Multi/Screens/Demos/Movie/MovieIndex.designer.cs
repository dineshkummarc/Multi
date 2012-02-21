// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("MovieIndex")]
	partial class MovieIndex
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnClear { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSync { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView textView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRemote { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnList { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnInsert { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
			}

			if (btnSync != null) {
				btnSync.Dispose ();
				btnSync = null;
			}

			if (textView != null) {
				textView.Dispose ();
				textView = null;
			}

			if (btnRemote != null) {
				btnRemote.Dispose ();
				btnRemote = null;
			}

			if (btnList != null) {
				btnList.Dispose ();
				btnList = null;
			}

			if (btnInsert != null) {
				btnInsert.Dispose ();
				btnInsert = null;
			}
		}
	}
}
