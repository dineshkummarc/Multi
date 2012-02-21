using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Multi
{
	public class TableViewDelegate : UITableViewDelegate
	{
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			var dataSource = (TableViewDataSource) tableView.DataSource;
			var alert = new UIAlertView("Row Selected", dataSource.Data[indexPath.Row], null, "Ok", null);
			alert.Show();
		}
 
	}
		
	public class TableViewDataSource : UITableViewDataSource
	{ 
		public List<string> Data { get; set; } 
		public TableViewDataSource(){
			Data = new List<string> {"100 grams","23 grams","4343 grams"};
		}
		
		#region implemented abstract members of MonoTouch.UIKit.UITableViewDataSource
		public override int RowsInSection (UITableView tableView, int section)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			return Data.Count;
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
			return cell;
		}
		#endregion
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

