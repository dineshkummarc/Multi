using System;
using System.Drawing;
using System.Text;
using System.Data;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.IO;

using Mono.Data.Sqlite;



namespace Multi
{
	public partial class HelloUniverseScreen : UIViewController
	{
		public HelloUniverseScreen () : base ("HelloUniverseScreen", null)
		{
			this.Title = "Universe";
			
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			
			this.btnSubmit.TouchUpInside += (sender, e) => {
				WritePersonInDb(this.tbName.Text, this.tbEmail.Text);	
			};
			
			this.btnShow.TouchUpInside += (sender, e) => {
				this.lbOutput.Text = ReadFromDb();
				this.View.EndEditing(true);
				
			};
			
			
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		
		
		public static void WritePersonInDb(string firstName, string email)
		{
			var connection = GetConnection ();
			var commands = new [] {"INSERT into people (PersonID, FirstName, LastName) VALUES ( 4, '"+firstName+"', '"+email+"')",}; 
			
            foreach (var cmd in commands)
			{
                using (var c = connection.CreateCommand()) {
                    c.CommandText = cmd;
                    c.CommandType = CommandType.Text;
                    connection.Open ();
                    c.ExecuteNonQuery ();
                    connection.Close ();
					Console.Error.WriteLine("about to run    "+ cmd.ToString());
                }
			} 
		}
	
		public static string ReadFromDb( )
		{
			var sb = new StringBuilder();
			var connection = GetConnection ();
	        using (var cmd = connection.CreateCommand ()) {
	            connection.Open ();
	            cmd.CommandText = "SELECT * FROM People";
	            using (var reader = cmd.ExecuteReader ()) {
	                while (reader.Read ()) {
	                    Console.Error.Write ("(Row ");
						sb.Append("(Row ");
	                    Write (reader, 0);
	                    for (int i = 1; i < reader.FieldCount; ++i) 
						{ 
	                        //Write (reader, i);
							var name = reader.GetName(i);
							var val = reader[i];
					        Console.Error.Write("[{0}:'{1}']",  name, val); 
							sb.AppendFormat(" [{0}:'{1}'] ", name, val);
	                    }
	                    Console.Error.WriteLine(")");
						sb.Append(")\n");
	                }
	            }
	            connection.Close ();
	        }
			return sb.ToString();
		}
		
		
    static SqliteConnection GetConnection()
    {
        var documents = Environment.GetFolderPath (
                Environment.SpecialFolder.Personal);
        string db = Path.Combine (documents, "mydb.db3");
        bool exists = File.Exists (db);
		//	exists = false;
			
        if (!exists)
            SqliteConnection.CreateFile (db);
        var conn = new SqliteConnection("Data Source=" + db);
        if (!exists) {
            var commands = new[] {
            "CREATE TABLE People (PersonID INTEGER NOT NULL, FirstName ntext, LastName ntext)",
            "INSERT INTO People (PersonID, FirstName, LastName) VALUES (1, 'First', 'Last')",
            "INSERT INTO People (PersonID, FirstName, LastName) VALUES (2, 'Dewey', 'Cheatem')",
            "INSERT INTO People (PersonID, FirstName, LastName) VALUES (3, 'And', 'How')",
            };
            foreach (var cmd in commands)
                using (var c = conn.CreateCommand()) {
                    c.CommandText = cmd;
                    c.CommandType = CommandType.Text;
                    conn.Open ();
                    c.ExecuteNonQuery ();
                    conn.Close ();
                }
        }
        return conn;
    }

    static void Write(SqliteDataReader reader, int index)
    {
        Console.Error.Write("({0} '{1}')",  reader.GetName(index), reader [index]);
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

