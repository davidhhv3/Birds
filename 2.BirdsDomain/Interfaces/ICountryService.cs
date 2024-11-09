using _2.BirdsDomain.CustomEntities;
using _2.BirdsDomain.Entities;
using _2.BirdsDomain.QueryFilters;

namespace _2.BirdsDomain.Interfaces
{
    public interface ICountryService
    {
        Task<PagedList<Country>> GetCountries(QueryFilter filters);

        Task<Country?> GetCountry(int Id);

        Task<bool> InsertCountry(Country country);

        Task<bool> UpdateCountry(Country country);

        Task<bool> DeleteCountry(int id);
    }
}
