using SQLite.Net.Attributes;
using System; 

namespace FirstAid.Database
{
	// Class describes the database table Category.
	class Log
	{
		// SQLite class attribute, defines the primary key.
		[PrimaryKey, AutoIncrement]
		public int LogId { get; set; }
		public DateTime Date { get; set; }
		public int LogTypeId { get; set; }
		public string LogText { get; set; }
	}
}

