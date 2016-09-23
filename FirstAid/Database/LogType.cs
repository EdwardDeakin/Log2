using SQLite.Net.Attributes;

namespace FirstAid.Database
{
	// Class describes the database table Category.
	class LogType
	{
		// SQLite class attribute, defines the primary key.
		[PrimaryKey, AutoIncrement]

		public int LogTypeId { get; set; }
		public string LogInjuryName { get; set; }

	}
}


