using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Multi
{
	public class MovieService
	{
		public MovieService ()
		{
		}
		
		public  const string dbName = "movieDb.db3";
			 
		public static List<Movie> Get()
		{
			var list = new List<Movie>(); 
			var connection = GetConnection ();
			using (var cmd = connection.CreateCommand ()) {
				connection.Open ();
				cmd.CommandText = "SELECT * FROM Movie";
				using (var reader = cmd.ExecuteReader ()) {
					while (reader.Read ()) {
						Movie m = new Movie();
						m.Title = reader[1].ToString();
						m.Rating = reader[2].ToString();
						//list.Add(new Movie{ Title = reader[1], Rating = reader[2]}); 
						list.Add(m); 
					}
				}
				connection.Close ();
			} 
			return list;
		}
		
		  
		
		public static SqliteConnection GetConnection ()
		{
			var documents = Environment.GetFolderPath (
	                Environment.SpecialFolder.Personal);
			string db = Path.Combine (documents, dbName);
			bool exists = File.Exists (db); 
			if (!exists)
				SqliteConnection.CreateFile (db);
			var conn = new SqliteConnection ("Data Source=" + db);
			if (!exists) { 
				var commands = new[] {
			            "CREATE TABLE Movie (Id INTEGER NOT NULL, Title ntext, Rating ntext, DateCreated datetime)",
			            "INSERT INTO Movie (Id, Title, Rating, DateCreated) VALUES (1, 'Traffic', 'R', '2007-01-01 10:00:00')",
			            "INSERT INTO Movie (Id, Title, Rating, DateCreated) VALUES (2, 'The Breakfast Club', 'R', '2007-01-01 10:00:00')",
			        };
				foreach (var cmd in commands) {
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
	}
}

