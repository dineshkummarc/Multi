using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Multi
{
	
	
	public class DayData
	{
		public List<string> Entries { get; set; }
		public string Title { get; set; }
	}
	
	
	
	
	public class TableViewDelegate : UITableViewDelegate
	{
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			var dataSource = (TableViewDataSource) tableView.DataSource;
			//var alert = new UIAlertView("Row Selected", dataSource.Data[indexPath.Row], null, "Ok", null);
			var alert = new UIAlertView("Row Selected", dataSource.Data[indexPath.Section].Entries[indexPath.Row], null, "Ok", null);
			alert.Show();
		}
 
	}
		
	public class TableViewDataSource : UITableViewDataSource
	{ 
		//public List<string> Data { get; set; } 
		public List<DayData> Data { get; set; } 
		public TableViewDataSource(){
			//Data = new List<string> {"100 grams","23 grams","4343 grams"};
			var day1 = new DayData();
			day1.Title = "Day 1";
			day1.Entries = new List<string> {"100 grams","23 grams","4343 grams"};
			
			var day2 = new DayData();
			day2.Title = "Day 2";
			day2.Entries = new List<string> {"100 grams","122 grams","23 grams","4343 grams"};
			
			var day3 = new DayData();
			day3.Title = "Day 3";
			day3.Entries = new List<string> {"100 grams","23 grams","4343 grams"};
			
			
			Data = new List<DayData> {day1, day2, day3 };
			
		}
		
		#region implemented abstract members of MonoTouch.UIKit.UITableViewDataSource
		public override int RowsInSection (UITableView tableView, int section)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			//return Data.Count;
			return Data[section].Entries.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			var cell = tableView.DequeueReusableCell("cell");
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, "cell");
			}
			//cell.TextLabel.Text = Data[indexPath.Row];
			cell.TextLabel.Text = Data[indexPath.Section].Entries[indexPath.Row]; 
			cell.ImageView.Image = new UIImage("./Screens/Demos/blackpaw.png");
			if (indexPath.Row % 3 == 1){
				cell.ImageView.Image = new UIImage("./paw.jpg");
			}
				
			cell.Accessory =   UITableViewCellAccessory.DetailDisclosureButton;
			
			return cell;
		}
		#endregion

		public override int NumberOfSections (UITableView tableView)
		{
			return Data.Count;
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			return Data[section].Title;
		}

		public override string TitleForFooter (UITableView tableView, int section)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			return "footer";
		}
	}
	
	
	
	public partial class TableViewScreen : UIViewController
	{
		public TableViewScreen () : base ("TableViewScreen", null)
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
			
			 this.tableView.DataSource = new TableViewDataSource();
			this.tableView.Delegate  = new TableViewDelegate();
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

