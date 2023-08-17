namespace LibraryManagementSystem.Domain.src.Entities
{
    public class Author : BaseEntity
    {
        public String FirstName { get; set; } = string.Empty;
        public String LastName { get; set;} = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}