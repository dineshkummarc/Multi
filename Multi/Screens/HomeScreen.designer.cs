// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("HomeScreen")]
	partial class HomeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnWorld { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnUniverse { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnWorld != null) {
				btnWorld.Dispose ();
				btnWorld = null;
			}

			if (btnUniverse != null) {
				btnUniverse.Dispose ();
				btnUniverse = null;
			}
		}
	}
}
