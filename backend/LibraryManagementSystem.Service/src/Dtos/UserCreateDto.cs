namespace LibraryManagementSystem.Service.src.Dtos
{
    public class UserCreateDto
    {
        public String FirstName { get; set; } = string.Empty;
        public String LastName { get; set; } = string.Empty;
        public String Password { get; set; } = string.Empty;
        public String Email { get; set; } = string.Empty;
        public String Address { get; set; } = string.Empty;
    }
}