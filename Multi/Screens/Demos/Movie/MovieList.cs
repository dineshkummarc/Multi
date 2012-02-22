using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Multi
{
	
	
	public class MovieListDelegate : UITableViewDelegate
	{
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{ 
			var dataSource = (MovieListDataSource) tableView.DataSource;
			var alert = new UIAlertView("Row Selected", Detail(dataSource.Data[indexPath.Row]), null, "Ok", null); 
			alert.Show();
		}
		
		private string Detail(Movie m)
		{
			return string.Format("Title:{0} \n Rated:{1}", m.Title, m.Rating);
		}
 
	}
	
	
	public class MovieListDataSource : UITableViewDataSource
	{  
		public List<Movie> Data { get; set; } 
		public MovieListDataSource(){
			
			Data = MovieService.Get(); 
		}
		
		#region implemented abstract members of MonoTouch.UIKit.UITableViewDataSource
		public override int RowsInSection (UITableView tableView, int section)
		{ 
			return Data.Count; 
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{ 
			var cell = tableView.DequeueReusableCell("cell");
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, "cell");
			}
			cell.TextLabel.Text = ((Movie)Data[indexPath.Row]).Title; 
			cell.ImageView.Image = new UIImage("./Screens/Demos/blackpaw.png");
			if (indexPath.Row % 3 == 1){
				cell.ImageView.Image = new UIImage("./paw.jpg");
			} 
			cell.Accessory =   UITableViewCellAccessory.DetailDisclosureButton;
			
			return cell;
		}
		#endregion
 
	}
	
	
	
	
	public partial class MovieList : UIViewController
	{
		public MovieList () : base ("MovieList", null)
		{
			this.Title = "List";
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
			 
			Console.WriteLine("called viewdidload");
			
			
			 this.tableView.DataSource = new MovieListDataSource();
			this.tableView.Delegate  = new MovieListDelegate();
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			Console.WriteLine("called ViewDidAppear");
			
		}
		public override void LoadView ()
		{
			base.LoadView ();
			
			Console.WriteLine("called LoadView");
		}
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			Console.WriteLine("called ViewDidDisappear");
		}
		
		public override void ViewWillUnload ()
		{
			base.ViewWillUnload ();
			Console.WriteLine("called ViewWillUnload");
		}
		 
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			Console.WriteLine("called ViewDidUnload");
			
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

