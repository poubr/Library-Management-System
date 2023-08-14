using LibraryManagementSystem.Domain.src.Entities;

namespace LibraryManagementSystem.Service.src.Dtos
{
    public class BookCreateDto
    {
        public String Isbn { get; set; } = string.Empty;
        public String Title { get; set; } = string.Empty;
        public String Author { get; set; } = string.Empty;
        public Genre Genre{  get; set; } = default!;
        public int LibraryCopies { get; set; }          // at least helmet shows all library copies 
        public int AvalableCopies { get; set; }
        public int YearOfPublishing { get; set; }
        public String Language { get; set; } = string.Empty;
        public String Publisher { get; set; } = string.Empty;
    }
}