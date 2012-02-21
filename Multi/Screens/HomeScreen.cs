using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class HomeScreen : UIViewController
	{
		
			
	    HelloWorldScreen helloWorldScreen;
	    HelloUniverseScreen helloUniverseScreen;
		SqliteScreen	sqliteScreen;
		FileSystemScreen	fileSystemScreen;
		ActionSheetScreen	actionSheetScreen;

		
		public HomeScreen () : base ("HomeScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		/*public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}*/
		
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//---- when the hello world button is clicked
			this.btnWorld.TouchUpInside += (sender, e) => {
				//---- instantiate a new hello world screen, if it's null
				// (it may not be null if they've navigated backwards
				if (this.helloWorldScreen == null) {
					this.helloWorldScreen = new HelloWorldScreen ();
				}
				//---- push our hello world screen onto the navigation
				//controller and pass a true so it navigates
				this.NavigationController.PushViewController (this.helloWorldScreen, true);
			};

			//---- same thing, but for the hello universe screen
			this.btnUniverse.TouchUpInside += (sender, e) => {
				if (this.helloUniverseScreen == null) {
					this.helloUniverseScreen = new HelloUniverseScreen ();
				}  
				this.NavigationController.PushViewController (this.helloUniverseScreen, true);
			};
			
			
			
			this.btnSqlite.TouchUpInside += (sender, e) => {
				if (this.sqliteScreen == null){
					this.sqliteScreen = new SqliteScreen();
				}
				this.NavigationController.PushViewController (this.sqliteScreen, true);
			};
			this.btnFiles.TouchUpInside += (sender, e) => {
				if (this.fileSystemScreen == null){
					this.fileSystemScreen = new FileSystemScreen();
				}
				this.NavigationController.PushViewController (this.fileSystemScreen, true);
			};
			this.btnAction.TouchUpInside += (sender, e) => {
				if (this.actionSheetScreen == null){
					this.actionSheetScreen = new ActionSheetScreen();
				}
				this.NavigationController.PushViewController (this.actionSheetScreen, true);
			};
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
		
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			this.NavigationController.SetNavigationBarHidden (true, animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			this.NavigationController.SetNavigationBarHidden (false, animated);
		}
		
		
		
		
		
	}
}

