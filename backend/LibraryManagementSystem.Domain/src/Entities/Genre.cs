namespace LibraryManagementSystem.Domain.src.Entities
{
    public class Genre : BaseEntity
    {
        public GenreName GenreName { get; set;} = GenreName.Other;
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