using LibraryManagementSystem.Domain.src.Entities;

namespace LibraryManagementSystem.Service.src.Dtos
{
    public class BookReadDto
    {
        public String Isbn { get; set; } = string.Empty;
        public String Title { get; set; } = string.Empty;
        public String Author { get; set; } = string.Empty;
        public Genre Genre{  get; set; } = default!;
        public int LibraryCopies { get; set; } 
        public int AvalableCopies { get; set; }
        public int YearOfPublishing { get; set; }
        public String Language { get; set; } = string.Empty;
        public String Publisher { get; set; } = string.Empty;
    }
}