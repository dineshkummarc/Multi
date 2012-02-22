// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("ConsumeScreen")]
	partial class ConsumeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnGet { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRestSharp { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView textView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnWebRef { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGet != null) {
				btnGet.Dispose ();
				btnGet = null;
			}

			if (btnRestSharp != null) {
				btnRestSharp.Dispose ();
				btnRestSharp = null;
			}

			if (textView != null) {
				textView.Dispose ();
				textView = null;
			}

			if (btnWebRef != null) {
				btnWebRef.Dispose ();
				btnWebRef = null;
			}
		}
	}
}
