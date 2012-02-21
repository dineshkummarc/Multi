using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class FileSystemScreen : UIViewController
	{
		public FileSystemScreen () : base ("FileSystemScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		UIButton btnFiles, btnDirectories, btnXml, btnAll, btnWrite, btnDirectory;
		UITextView txtView;
		
		
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			 
			// Create the buttons and TextView to run the sample code
			btnFiles = UIButton.FromType(UIButtonType.RoundedRect);
			btnFiles.Frame = new RectangleF(10,10,145,50);
			btnFiles.SetTitle("Open 'ReadMe.txt'", UIControlState.Normal);
			//btnFiles.Font.SetValueForKey(NSObject., "green");
			btnFiles.Enabled = false;
			
			btnDirectories = UIButton.FromType(UIButtonType.RoundedRect);
			btnDirectories.Frame = new RectangleF(10,70,145,50);
			btnDirectories.SetTitle("List Directories", UIControlState.Normal);
			
			btnXml = UIButton.FromType(UIButtonType.RoundedRect);
			btnXml.Frame = new RectangleF(165,10,145,50);
			btnXml.SetTitle("Open 'Test.xml'", UIControlState.Normal);
			btnXml.Enabled = false;
			
			
			btnAll = UIButton.FromType(UIButtonType.RoundedRect);
			btnAll.Frame = new RectangleF(165,70,145,50);
			btnAll.SetTitle("List All", UIControlState.Normal);
			
			btnWrite = UIButton.FromType(UIButtonType.RoundedRect);
			btnWrite.Frame = new RectangleF(10,130,145,50);
			btnWrite.SetTitle("Write File", UIControlState.Normal);

			btnDirectory = UIButton.FromType(UIButtonType.RoundedRect);
			btnDirectory.Frame = new RectangleF(165,130,145,50);
			btnDirectory.SetTitle("Create Directory", UIControlState.Normal);

			txtView = new UITextView(new RectangleF(10, 190, 300, 250));
			txtView.Editable = false;
			txtView.ScrollEnabled = true;
			
			// Wire up the buttons to the SamplCode class methods
			btnFiles.TouchUpInside += (sender, e) => {
				SampleCode.ReadText(txtView);
			};

			btnDirectories.TouchUpInside += (sender, e) => {
				SampleCode.ReadDirectories(txtView);
			};
			
			btnAll.TouchUpInside += (sender, e) => {
				SampleCode.ReadAll(txtView);
			};

			btnXml.TouchUpInside += (sender, e) => {
				SampleCode.ReadXml(txtView);
			};
			
			btnWrite.TouchUpInside += (sender, e) => {
				SampleCode.WriteFile(txtView);
			};

			btnDirectory.TouchUpInside += (sender, e) => {
				SampleCode.CreateDirectory(txtView);
			};
			
			// Add the controls to the view
			this.Add(btnFiles);
			this.Add(btnDirectories);
			this.Add(btnXml);
			this.Add(btnAll);
			this.Add(btnWrite);
			this.Add(btnDirectory);			
			this.Add(txtView);
			
			// Write out this special folder, just for curiousity's sake
			Console.WriteLine("MyDocuments:"+Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
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

