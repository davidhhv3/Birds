using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _4.BirdsInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace _4.BirdsInfrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(BirdsContext context) : base(context) { }

        public async Task<Security?> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }

    }
}
