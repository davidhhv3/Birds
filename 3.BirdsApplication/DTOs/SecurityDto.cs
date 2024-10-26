using _2.BirdsDomain.Enumerations;

namespace _3.BirdsApplication.DTOs
{
    public class SecurityDto
    {
        public string? User { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
