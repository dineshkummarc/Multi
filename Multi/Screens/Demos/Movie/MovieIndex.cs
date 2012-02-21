using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class MovieIndex : UIViewController
	{
		
		MovieList movieList;
		//MovieRemote movieRemote; 
		
		public MovieIndex () : base ("MovieIndex", null)
		{
			this.Title = "Movies";
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
			/*
			this.btnInsert.TouchUpInside += (sender, e) => {
				if (this.movieInsert == null) {
					this.movieInsert = new MovieInsert ();
				}  
				this.NavigationController.PushViewController (this.movieInsert, true);
			};*/
			
			 
			this.btnList.TouchUpInside += (sender, e) => {
				if (this.movieList == null) {
					this.movieList = new MovieList ();
				}  
				this.NavigationController.PushViewController (this.movieList, true);
			};
			
			
			
			this.btnClear.TouchUpInside += (sender, e) => { 
				var a = new UIAlertView("Clear ?", "are you sure you want to clear the db?", null, "cancel", "OK");
				a.Clicked += HandleAClicked;
				a.Show();
			}; 
			
		/*
			this.btnRemote.TouchUpInside += (sender, e) => {
				if (this.movieRemote == null) {
					this.movieRemote = new MovieRemote ();
				}  
				this.NavigationController.PushViewController (this.movieRemote, true);
			};*/
			
		}
		
		
		void HandleAClicked (object sender, UIButtonEventArgs e)
		{
			if (e.ButtonIndex == 0)
			{
				Console.WriteLine("Cancel Clicked");
			}
			else
			{
				Console.WriteLine("Ok Clicked");
				MovieService.CleanDb();
			}
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

