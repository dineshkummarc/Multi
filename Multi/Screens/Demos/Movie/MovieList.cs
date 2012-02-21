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
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			var dataSource = (MovieListDataSource) tableView.DataSource;
			var alert = new UIAlertView("Row Selected", dataSource.Data[indexPath.Row], null, "Ok", null);
			//var alert = new UIAlertView("Row Selected", dataSource.Data[indexPath.Section].Entries[indexPath.Row], null, "Ok", null);
			alert.Show();
		}
 
	}
	
	
	public class MovieListDataSource : UITableViewDataSource
	{ 
		//public List<string> Data { get; set; } 
		public List<string> Data { get; set; } 
		public MovieListDataSource(){
			Data = new List<string> {"9 grams","7 grams","5 grams"}; 
			
		}
		
		#region implemented abstract members of MonoTouch.UIKit.UITableViewDataSource
		public override int RowsInSection (UITableView tableView, int section)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			return Data.Count;
			//return Data[section].Entries.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			var cell = tableView.DequeueReusableCell("cell");
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, "cell");
			}
			cell.TextLabel.Text = Data[indexPath.Row];
			//cell.TextLabel.Text = Data[indexPath.Section].Entries[indexPath.Row]; 
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
			
			this.btnLoad.TouchUpInside += (sender, e) => {
				Console.WriteLine("Clicked load");
			};
			 this.tableView.DataSource = new MovieListDataSource();
			this.tableView.Delegate  = new MovieListDelegate();
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

