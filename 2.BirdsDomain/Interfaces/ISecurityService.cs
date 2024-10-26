using _2.BirdsDomain.Entities;

namespace _2.BirdsDomain.Interfaces
{
    public interface ISecurityService
    {        
        Task RegisterUser(Security security);
    }
}
