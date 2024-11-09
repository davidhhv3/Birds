using _2.BirdsDomain.CustomEntities;
using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _2.BirdsDomain.QueryFilters;
using _3.BirdsApplication.Exceptions;

namespace _3.BirdsApplication.Helpers
{
    public class CountryServiceHelpers
    {
        internal static QueryFilter SetValueFilter(QueryFilter filters, PaginationOptions _paginationOptions)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            return filters;
        }
        internal static async Task<Country> VerifyCountryExistence(int id, IUnitOfWork _unitOfWork)
        {
            Country? country = await _unitOfWork.CountryRepository.GetById(id);
            ObjectVerifier.VerifyExistence(country, "El pais no está registrado");
            return country;
        }
        internal static async Task<List<Country>> VerifyClientessExistence(IUnitOfWork _unitOfWork)
        {
            List<Country> countries = (await _unitOfWork.CountryRepository.GetAll()).ToList();
            ObjectVerifier.VerifyExistence(countries, "Aún no hay paises registrados", countries.Count());
            return countries;
        }
    }
}
