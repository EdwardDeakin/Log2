using SQLite.Net.Attributes;

namespace FirstAid.Database
{
    // Class describes the database table Treatment.
    class Treatment
    {
        // SQLite class attribute, defines the primary key.
        [PrimaryKey, AutoIncrement]
        public int TreatmentId { get; set; }
        public string TreatmentHeading { get; set; }
        public string TreatmentText { get; set; }
    }
}
