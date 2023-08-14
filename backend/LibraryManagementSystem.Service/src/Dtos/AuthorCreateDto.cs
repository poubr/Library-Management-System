// Some of the dtos contain the exact same information but it is less code repetition
// than having varying number of dtos and then having to have unique interfaces,
// and it allows for easier future modifications of properties.
namespace LibraryManagementSystem.Service.src.Dtos
{
    public class AuthorCreateDto
    {
        public String FirstName { get; set; } = string.Empty;
        public String LastName { get; set;} = string.Empty;
    }
}