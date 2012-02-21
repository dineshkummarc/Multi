// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("ActionSheetScreen")]
	partial class ActionSheetScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnAction { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnReset { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnAction != null) {
				btnAction.Dispose ();
				btnAction = null;
			}

			if (btnReset != null) {
				btnReset.Dispose ();
				btnReset = null;
			}
		}
	}
}
