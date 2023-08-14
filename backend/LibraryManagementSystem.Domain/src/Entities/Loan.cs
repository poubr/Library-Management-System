namespace LibraryManagementSystem.Domain.src.Entities
{
    public class Loan : BaseEntity
    {
        public User User { get; set; } = default!;
        public Book Book { get; set; } = default!;
        public DateTime CheckekOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; } = default!;
        public String Status {get; set; } = String.Empty;
        public float Fee {get; set; }
    }

    public enum Status
    {
        Reserved,
        Borrowed,
        Returned,
        Late,
        Lost,
        Damaged,
        Cancelled
    }
}