using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Domain.src.Entities
{
    public class User : BaseEntity 
    {
        public String FirstName { get; set; } = string.Empty;
        public String LastName { get; set; } = string.Empty;
        public String Password { get; set; } = string.Empty;
        public String Email { get; set; } = string.Empty;
        public String Address { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        User
    }
}