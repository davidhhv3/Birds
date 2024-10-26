using _2.BirdsDomain.Enumerations;

namespace _2.BirdsDomain.Entities
{
    public class Security : BaseEntity
    {
        public string? User { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public RoleType Role { get; set; }
    }
}
