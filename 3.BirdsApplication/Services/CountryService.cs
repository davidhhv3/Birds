using _2.BirdsDomain.CustomEntities;
using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _2.BirdsDomain.QueryFilters;
using _3.BirdsApplication.Helpers;
using Microsoft.Extensions.Options;

namespace _3.BirdsApplication.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public CountryService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<bool> DeleteCountry(int id)
        {
            await CountryServiceHelpers.VerifyCountryExistence(id,_unitOfWork);
            await _unitOfWork.CountryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PagedList<Country>> GetCountries(QueryFilter filters)
        {
            filters = CountryServiceHelpers.SetValueFilter(filters, _paginationOptions);
            List<Country> countries = await CountryServiceHelpers.VerifyClientessExistence(_unitOfWork);
            PagedList<Country> pagedStudents = PagedList<Country>.Create(countries, filters.PageNumber, filters.PageSize);
            return pagedStudents;
        }

        public async Task<Country?> GetCountry(int Id)
        {
            Country? country = await CountryServiceHelpers.VerifyCountryExistence(Id, _unitOfWork);
            return country;
        }

        public async Task<bool> InsertCountry(Country country)
        {
            await _unitOfWork.CountryRepository.Add(country);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            Country? existingCountry = await CountryServiceHelpers.VerifyCountryExistence(country.Id, _unitOfWork);
            if (existingCountry != null)
            {
                existingCountry.NameCountry = country.NameCountry;             
                await _unitOfWork.CountryRepository.Update(existingCountry);
            }
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
