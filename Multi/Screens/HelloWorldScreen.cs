using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class HelloWorldScreen : UIViewController
	{
		public HelloWorldScreen () : base ("HelloWorldScreen", null)
		{
			this.Title = "World";
		}
		
	    HelloUsaScreen helloUsaScreen; 
			
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			
			
			//---- when the hello world button is clicked
			this.btnUsa.TouchUpInside += (sender, e) => {
				//---- instantiate a new hello world screen, if it's null
				// (it may not be null if they've navigated backwards
				if (this.helloUsaScreen == null) {
					this.helloUsaScreen = new HelloUsaScreen ();
				}
				//---- push our hello world screen onto the navigation
				//controller and pass a true so it navigates
				this.NavigationController.PushViewController (this.helloUsaScreen, true);
			};
			
			
			// Perform any additional setup after loading the view, typically from a nib.
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

