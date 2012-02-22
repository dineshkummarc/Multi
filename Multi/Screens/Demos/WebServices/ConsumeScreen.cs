using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using System.IO;

namespace Multi
{
	public partial class ConsumeScreen : UIViewController
	{
		public ConsumeScreen () : base ("ConsumeScreen", null)
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
			 
			var rxcui = "198440";
			
			this.btnGet.TouchUpInside += (sender, e) => {  
				var request = HttpWebRequest.Create (string.Format (@"http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/{0}/allinfo", rxcui));
				request.ContentType = "application/json";
				request.Method = "GET";
				Console.Out.WriteLine ("Starting ...");
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) 
				{
					if (response.StatusCode != HttpStatusCode.OK)
						Console.Out.WriteLine ("Error fetching data. Server returned status code: {0}", response.StatusCode);
					using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
					{
						var content = reader.ReadToEnd ();
						if (string.IsNullOrWhiteSpace (content)) {
							Console.Out.WriteLine ("Response contained empty body...");
						} else {
							Console.Out.WriteLine ("Response Body: \r\n {0}", content);
							this.textView.Text = content;
						}
       
						//Assert.NotNull (content);
					}
				} 
			};
			
			this.btnRestSharp.TouchUpInside += (sender, e) => {
				/*var request = new RestRequest(string.Format("{0}/allinfo", rxcui));
				request.RequestFormat = DataFormat.Json;
				var response = Client.Execute(request);
				if(string.IsNullOrWhiteSpace(response.Content) || response.StatusCode != System.Net.HttpStatusCode.OK) {
				    return null;
				}
				rxTerm = DeserializeRxTerm(response.Content);*/
				Console.WriteLine("Disabled right now check - btnRestSharp.TouchUpInside----");
			};
			
			this.btnWebRef.TouchUpInside += (sender, e) => { 
				Console.WriteLine("Disabled right now check - btnWebRef.TouchUpInside----");
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
	}
}

