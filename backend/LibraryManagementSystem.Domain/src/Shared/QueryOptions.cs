namespace LibraryManagementSystem.Domain.src.Shared
{
    public class QueryOptions
    {
        public String SearchKeyword { get; set; } = String.Empty;
        public String SortKeyword { get; set; } = "Title";
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set;} = 10;
        // TO DO: Filtering options, try to implement if time and brain allow
        public String Language { get; set; } = "English";
        public int YearOfPublishing { get; set; }
        public int AvalableCopies { get; set; }

        public enum SortOptions
        {
            Title,
            Author
        }
    }
}