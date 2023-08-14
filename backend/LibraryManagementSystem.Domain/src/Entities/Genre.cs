namespace LibraryManagementSystem.Domain.src.Entities
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set;} = "Other";
    }

    public enum GenreName
    {
        Adventure,
        Biography,
        Comedy,
        Crime,
        Drama,
        Fantasy,
        History,
        Horror,
        NonFiction,
        Philosophy,
        Poetry,
        Romance,
        Science,
        SciFi,
        SelfHelp,
        Thriller,
        Travel,
        YoungAdult,
        Other
    }
}