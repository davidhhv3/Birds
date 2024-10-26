using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _4.BirdsInfrastructure.Data;

namespace _4.BirdsInfrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(BirdsContext context) : base(context) { }
  
    }
}
