using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation;
using MediaPlayer;
using CoreGraphics;

namespace iOSTips
{
	public partial class VideoViewController : UIViewController
	{
		MPMoviePlayerController moviePlayer;


		public VideoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Video";

			btnPlay.TouchUpInside += (object sender, EventArgs e) => {
				moviePlayer = new MPMoviePlayerController (NSUrl.FromFilename ("sample_iPod.m4v"));

				View.AddSubview (moviePlayer.View);
				moviePlayer.SetFullscreen (true, true);
				moviePlayer.Play ();

			};


		}

	}
}
