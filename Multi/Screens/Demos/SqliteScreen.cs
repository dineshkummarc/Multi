using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Multi
{
	public partial class SqliteScreen : UIViewController
	{
		public SqliteScreen () : base ("SqliteScreen", null)
		{
			this.Title = "Sqlite"; 
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{ 
			this.btnSave.TouchUpInside += (sender, e) => { 
				this.WritePersonInDb (this.tbFirst.Text, this.tbLast.Text);
				this.tfOutput.Text = ReadFromDb();
				this.View.EndEditing (true);
			};
			
			this.btnClear.TouchUpInside += (sender, e) => { 
				var a = new UIAlertView("Clear ?", "are you sure you want to clear the db?", null, "cancel", "OK");
				a.Clicked += HandleAClicked;
				a.Show();
			}; 
			base.ViewDidLoad (); 
		}

		void HandleAClicked (object sender, UIButtonEventArgs e)
		{
			if (e.ButtonIndex == 0)
			{
				Console.WriteLine("Cancel Clicked");
			}
			else
			{
				Console.WriteLine("Ok Clicked");
				var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				string db = Path.Combine (documents, "mydb.db3");
				bool exists = File.Exists (db); 
				if (exists) {
					File.Delete (db);
				}
				this.tfOutput.Text = ReadFromDb();
			}
		}
		
		public void WritePersonInDb (string firstName, string email)
		{
			var connection = GetConnection ();
			var commands = new [] {"INSERT into people (PersonID, FirstName, LastName) VALUES ( 4, '" + firstName + "', '" + email + "')",};  
			foreach (var cmd in commands) {
				using (var c = connection.CreateCommand()) {
					c.CommandText = cmd;
					c.CommandType = CommandType.Text;
					connection.Open ();
					c.ExecuteNonQuery ();
					connection.Close ();
					Console.Error.WriteLine ("about to run    " + cmd.ToString ());
				}
			} 
		}
		
		public static string ReadFromDb ()
		{
			var sb = new StringBuilder ();
			var connection = GetConnection ();
			using (var cmd = connection.CreateCommand ()) {
				connection.Open ();
				cmd.CommandText = "SELECT * FROM People";
				using (var reader = cmd.ExecuteReader ()) {
					while (reader.Read ()) {
						Console.Error.Write ("(Row "); 
						for (int i = 1; i < reader.FieldCount; ++i) { 
							//Write (reader, i);
							var name = reader.GetName (i);
							var val = reader [i];
							Console.Error.Write ("[{0}:'{1}']", name, val); 
							sb.AppendFormat ("{0} ", val);
						}
						Console.Error.WriteLine (")");
						sb.Append (")  -\n");
					}
				}
				connection.Close ();
			}
			return sb.ToString ();
		}
		
		public static SqliteConnection GetConnection ()
		{
			var documents = Environment.GetFolderPath (
                Environment.SpecialFolder.Personal);
			string db = Path.Combine (documents, "mydb.db3");
			bool exists = File.Exists (db);
			//	exists = false;
			
			if (!exists)
				SqliteConnection.CreateFile (db);
			var conn = new SqliteConnection ("Data Source=" + db);
			if (!exists) {
				var commands = new[] {
		            "CREATE TABLE People (PersonID INTEGER NOT NULL, FirstName ntext, LastName ntext)",
		            "INSERT INTO People (PersonID, FirstName, LastName) VALUES (1, 'Homer', 'Simpson')", 
		        };
				foreach (var cmd in commands){
					using (var c = conn.CreateCommand()) {
						c.CommandText = cmd;
						c.CommandType = CommandType.Text;
						conn.Open ();
						c.ExecuteNonQuery ();
						conn.Close ();
					}
				}
			}
			return conn;
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

