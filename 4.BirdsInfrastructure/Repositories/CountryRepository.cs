using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _4.BirdsInfrastructure.Data;

namespace _4.BirdsInfrastructure.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(BirdsContext context) : base(context)
        {
        }
    }
}
