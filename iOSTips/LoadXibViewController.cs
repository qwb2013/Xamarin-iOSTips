using System;
using System.CodeDom.Compiler;

using UIKit;
using Foundation;
using ObjCRuntime;

using Debug = System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class LoadXibViewController : UIViewController
	{
		public LoadXibViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.NavigationController.NavigationBar.Translucent = false;

			var view = LoadDescriptionViewFromXib ();

			View.AddSubview (view);

			view.TranslatesAutoresizingMaskIntoConstraints = false;

			var leftConstraint = NSLayoutConstraint.Create (
									view,
									NSLayoutAttribute.Leading,
									NSLayoutRelation.Equal,
									this.View,
									NSLayoutAttribute.Leading,
									1,
									0);
			this.View.AddConstraint (leftConstraint);


			var topConstraint = NSLayoutConstraint.Create (
									view,
									NSLayoutAttribute.Top,
									NSLayoutRelation.Equal,
									this.View,
									NSLayoutAttribute.Top,
									1,
									0);
			this.View.AddConstraint (topConstraint);


			var rightConstraint = NSLayoutConstraint.Create (
									view,
									NSLayoutAttribute.Trailing,
									NSLayoutRelation.Equal,
									this.View,
									NSLayoutAttribute.Trailing,
									1,
									0);
			this.View.AddConstraint (rightConstraint);

			var bottomConstraint = NSLayoutConstraint.Create (
									view,
									NSLayoutAttribute.Bottom,
									NSLayoutRelation.Equal,
									this.View,
									NSLayoutAttribute.Bottom,
									1,
									0);

			this.View.AddConstraint (bottomConstraint);


			this.View.SetNeedsUpdateConstraints ();

			view.Update ("Images/idf.jpg");

			view.btnNext.TouchUpInside += (object sender, EventArgs e) => {

				Debug.WriteLine("btnNext Clicked!");
			};
		}

		private DescView LoadDescriptionViewFromXib(){

			var array = NSBundle.MainBundle.LoadNib("DescView", this, null);

			if (1 == array.Count) {
				
				var view = Runtime.GetNSObject<DescView> (array.ValueAt(0));

				return view;
			}

			return null;
		}


	}
}
