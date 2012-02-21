// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("MovieInsert")]
	partial class MovieInsert
	{
		[Outlet]
		MonoTouch.UIKit.UITextField tbTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbRating { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSubmit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView textView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tbTitle != null) {
				tbTitle.Dispose ();
				tbTitle = null;
			}

			if (tbRating != null) {
				tbRating.Dispose ();
				tbRating = null;
			}

			if (btnSubmit != null) {
				btnSubmit.Dispose ();
				btnSubmit = null;
			}

			if (textView != null) {
				textView.Dispose ();
				textView = null;
			}
		}
	}
}
