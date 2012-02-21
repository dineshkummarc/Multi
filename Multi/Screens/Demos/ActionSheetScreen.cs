using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class ActionSheetScreen : UIViewController
	{
		public ActionSheetScreen () : base ("ActionSheetScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.btnReset.TouchUpInside += (sender, e) => { 
				var actionSheet = new UIActionSheet("Are you sure you want to reset ?", null, "Cancel", "Reset", "?");
				actionSheet.Clicked += HandleActionSheetClicked;;
				actionSheet.ShowInView(View);
			};  
		}

		void HandleActionSheetClicked (object sender, UIButtonEventArgs e)
		{ 
			if (e.ButtonIndex == 0) 
				Console.WriteLine("reset Clicked"); 
			else if (e.ButtonIndex == 1) 
				Console.WriteLine("? Clicked"); 
			else 
				Console.WriteLine("Cancel Clicked"); 
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

