using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace iOSTips
{
	public partial class FileIOViewController : UIViewController
	{
		private StorageWorker Worker { get; set; }

		public FileIOViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//
			Worker = new StorageWorker ();

			Debug.WriteLine ($"DocumentsPath:{StorageWorker.DocumentsPath}");  

			#region Buttons' Event

			btnWriteFile.TouchUpInside += async (sender, e) => {
				await Worker.SaveTextAsync ("io.txt", $"Hello, Xamarin { DateTime.Now.ToLongTimeString() } ");
			};

			btnReadFile.TouchUpInside += async (sender, e) => {
				var result = await Worker.LoadTextAsync ("io.txt");
				Debug.WriteLine ($"result:{result}");
			};

			#endregion

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}

	public class StorageWorker
	{

		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			string path = DocumentPath (filename);
			using (StreamWriter sw = File.CreateText (path))
				await sw.WriteAsync (text);
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string path = DocumentPath (filename);

			using (var file = new FileStream (path, FileMode.Open)) {
				using (var reader = new StreamReader (file)) {

					var awaitResult = await reader.ReadToEndAsync ();

					return awaitResult;
				}
			}
		}

		public bool FileExists (string filename)
		{
			return File.Exists (DocumentPath (filename));
		}

		#endregion

		public static string DocumentsPath {
			get {
				var documentsDirUrl = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User).Last ();
				return documentsDirUrl.Path;
			}
		}

		static string DocumentPath (string fileName)
		{
			return Path.Combine (DocumentsPath, fileName);
		}

	}
}


