namespace Gift_Ideas.Models
{
    using SQLite.Net.Attributes;

    public class UserDataModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
