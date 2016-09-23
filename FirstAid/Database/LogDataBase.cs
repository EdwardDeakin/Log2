using System;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FirstAid.Database
{
	class LogDataBase
	{
		private SQLiteConnection _Database;

		public LogDataBase()
		{
			System.Diagnostics.Debug.WriteLine("I'm in the category database");
			_Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

			// Create the table if it doesn't not exist.
			_Database.CreateTable<Log>();

			// Check how many rows are in the table, if it's empty. Add the initial data.
			if (_Database.Table<Log>().Count() == 0)
			{
				// Add data here.

				_Database.Insert(new Log { Date = DateTime.Now, LogTypeId = 1, LogText = "Text" });

			}
		}

		public IEnumerable<Log> GetAllLogs()
		{
			// Get all of the categories from the database table.
			return _Database.Table<Log>();
		}

		public IEnumerable<Log> GetLogsByLogType(int LogTypeId)
		{
			// Get all of the categories from the database table.
			return _Database.Query<Log>("SELECT * FROM Log WHERE LogTypeId = ?", LogTypeId);
		}
	}
}
