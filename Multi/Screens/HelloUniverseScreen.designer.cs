// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Multi
{
	[Register ("HelloUniverseScreen")]
	partial class HelloUniverseScreen
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lbOutput { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnShow { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbEmail { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSubmit { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbOutput != null) {
				lbOutput.Dispose ();
				lbOutput = null;
			}

			if (btnShow != null) {
				btnShow.Dispose ();
				btnShow = null;
			}

			if (tbEmail != null) {
				tbEmail.Dispose ();
				tbEmail = null;
			}

			if (tbName != null) {
				tbName.Dispose ();
				tbName = null;
			}

			if (btnSubmit != null) {
				btnSubmit.Dispose ();
				btnSubmit = null;
			}
		}
	}
}
