using _2.BirdsDomain.Entities;

namespace _2.BirdsDomain.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
