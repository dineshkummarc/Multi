using System;
using MonoTouch.UIKit;




namespace Multi
{
	public class NoXcodeScreen: UIViewController
	{
		public NoXcodeScreen ()
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			
			var button  = UIButton.FromType(UIButtonType.RoundedRect);
			button.SetTitle("Hello", UIControlState.Normal);
			button.Frame = new System.Drawing.RectangleF(0,0,100,100);
			View.AddSubview(button);
			
		}
	}
}

