using _1.BirdsApi.Responses;
using _2.BirdsDomain.CustomEntities;
using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _2.BirdsDomain.QueryFilters;
using _3.BirdsApplication.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _1.BirdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve all countries
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet("GetCountries")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CountryDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCountries([FromQuery] QueryFilter filters)
        {
            PagedList<Country> countries = await _countryService.GetCountries(filters);
            IEnumerable<CountryDto> countryDto = _mapper.Map<IEnumerable<CountryDto>>(countries);
            Metadata metadata = new Metadata
            {
                TotalCount = countries.TotalCount,
                PageSize = countries.PageSize,
                CurrentPage = countries.CurrentPage,
                TotalPages = countries.TotalPages,
                HasNextPage = countries.HasNextPage,
                HasPreviousPage = countries.HasPreviousPage,
            };
            ApiResponse<IEnumerable<CountryDto>> response = new ApiResponse<IEnumerable<CountryDto>>(countryDto)
            {
                Meta = metadata
            };
            return Ok(response);
        }

        /// <summary>
        /// Retrieve Country
        /// </summary>
        /// <param name="id">The ID of the country to retrieve</param>
        /// <returns></returns>
        [HttpGet("GetCountry/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CountryDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCountry(int id)
        {
            Country? country = await _countryService.GetCountry(id);
            CountryDto countryDto = _mapper.Map<CountryDto>(country);
            ApiResponse<CountryDto> response = new ApiResponse<CountryDto>(countryDto);
            return Ok(response);
        }

        /// <summary>
        /// Create a new country
        /// </summary>
        /// <param name="country">Country data</param>
        /// <returns></returns>
        [HttpPost("CreateCountry")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CountryDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCountry(CountryDto countryDto)
        {
            Country country = _mapper.Map<Country>(countryDto);
            await _countryService.InsertCountry(country);
            ApiResponse<CountryDto> response = new ApiResponse<CountryDto>(countryDto);
            return Ok(response);
        }

        /// <summary>
        /// Update a country
        /// </summary>   
        /// <param name="id">The ID of the country to update</param>
        /// <param name="CountryDto">Updated country data</param>
        /// <returns></returns>
        [HttpPut("UpdateCountry")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCountry(int id, CountryDto countryDto)
        {
            Country country = _mapper.Map<Country>(countryDto);
            country.Id = id;
            bool result = await _countryService.UpdateCountry(country);
            ApiResponse<bool> response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Delete a country by ID
        /// </summary>    
        /// <param name="id">The ID of the country to delete</param>
        /// <returns></returns>
        [HttpDelete("DeleteCountry/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            bool result = await _countryService.DeleteCountry(id);
            ApiResponse<bool> response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
