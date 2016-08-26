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
			string path = CreatePathToFile (filename);
			using (StreamWriter sw = File.CreateText (path))
				await sw.WriteAsync (text);
		}

		public string LoadText (string filename)
		{
			var result = string.Empty;
			string path = CreatePathToFile (filename);

			using (var file = new FileStream (path, FileMode.Open)) {
				using (var reader = new StreamReader (file)) {
					result = reader.ReadToEnd ();
				}
			}

			return result;
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string path = CreatePathToFile (filename);

			using (var file = new FileStream (path, FileMode.Open)) {
				using (var reader = new StreamReader (file)) {
					return ReadFileText (reader).Result;
				}
			}
		}

		private async Task<string> ReadFileText (StreamReader reader)
		{
			return await Task.Run (() => reader.ReadToEndAsync ()).ConfigureAwait (false);
		}

		public bool FileExists (string filename)
		{
			return File.Exists (CreatePathToFile (filename));
		}

		#endregion

		public static string DocumentsPath {
			get {
				var documentsDirUrl = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User).Last ();
				return documentsDirUrl.Path;
			}
		}

		static string CreatePathToFile (string fileName)
		{
			return Path.Combine (DocumentsPath, fileName);
		}

	}
}


