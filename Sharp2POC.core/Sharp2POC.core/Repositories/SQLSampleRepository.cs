using Sharp2POC.Core.Models;
using Sharp2POC.Core.Repositories.Interfaces;
using SQLite;
using System.Collections.Generic;

namespace Sharp2POC.Core.Repositories
{
	public abstract class SQLSampleRepository : ISQLSampleRepository
	{
		private SQLiteConnection connection;
		private List<SQLExampleObject> sampleList;

		//Repositories are the connection from a Database to the application 
		public SQLSampleRepository()
		{
			if (connection != null)	return;

			Initialize();
		}

		//This initialize method is; 
		// - pulling the database file path from the device to create a new connection
		// - Checking to see if the table already exists then deleting all of the data
		// - creating a new local list for the elements of the database
		// - then generating a sample list
		public void Initialize()
		{
			string path = GetPlatformDatabasePath("exampleRepository.sql");
			connection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

			//connection.DropTable<SQLExampleObject>();
			connection.CreateTable<SQLExampleObject>();

			connection.DeleteAll<SQLExampleObject>();

			sampleList = new List<SQLExampleObject>();
			//sampleList = connection.Table<SQLExampleObject>().ToList();

			GenerateSampleList();
		}

		//An example of adding objects to a database
		public void GenerateSampleList()
		{
			Add(new SQLExampleObject() { Name = "Test Object 1", Count = 4, Description = "It's the first object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 2", Count = 1, Description = "It's the second object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 3", Count = 0, Description = "It's the third object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 4", Count = 6, Description = "It's the fourth object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 5", Count = 0, Description = "It's the fifth object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 6", Count = 3, Description = "It's the sixth object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 7", Count = 2, Description = "It's the seventh object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 8", Count = 7, Description = "It's the eighth object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 9", Count = 10, Description = "It's the ninth object in the list." });
			Add(new SQLExampleObject() { Name = "Test Object 10", Count = 5, Description = "It's the tenth object in the list." });
		}

		//This function gets the database file path from the android device to allow the core to create and store the 
		//SQL tables required for the app to work
		public abstract string GetPlatformDatabasePath(string dbName);

		//Adds provided object to the table
		public void Add(SQLExampleObject sampleobj)
		{
			foreach (SQLExampleObject obj in sampleList)
			{
				if (obj.Name == sampleobj.Name)
				{
					System.Diagnostics.Debug.WriteLine("Unable to add: " + sampleobj.Name + ". Already exists in database.");
					return;
				}
			}

			connection.Insert(sampleobj);
			sampleList = connection.Table<SQLExampleObject>().ToList();
		}

		//Removes the provided object from the table
		public void Remove(SQLExampleObject sampleobj)
		{
			foreach (SQLExampleObject obj in sampleList)
			{
				if (obj.Id == sampleobj.Id)
				{
					connection.Delete(sampleobj);
					sampleList = connection.Table<SQLExampleObject>().ToList();
					return;
				}
			}

			System.Diagnostics.Debug.WriteLine("Unable to add: " + sampleobj.Name + ". Already exists in database.");
		}

		//Returns the current table 
		public List<SQLExampleObject> ReturnList()
		{
			sampleList = connection.Table<SQLExampleObject>().ToList();
			return sampleList;
		}

		//Deletes all of the elements in the sample table without dropping the table
		public void EraseList()
		{
			connection.DeleteAll<SQLExampleObject>();
		}
	}
}
