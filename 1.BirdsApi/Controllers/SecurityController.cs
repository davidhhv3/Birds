using _1.BirdsApi.Responses;
using _2.BirdsDomain.Entities;
using _2.BirdsDomain.Interfaces;
using _3.BirdsApplication.DTOs;
using _4.BirdsInfrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _1.BirdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        /// <summary>
        /// Create a new security user
        /// </summary>    
        /// <param name="securityDto">Security user data</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SecurityDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {
            Security security = _mapper.Map<Security>(securityDto);
            if (security.Password != null)
                security.Password = _passwordService.Hash(security.Password);
            await _securityService.RegisterUser(security);
            securityDto = _mapper.Map<SecurityDto>(security);
            ApiResponse<SecurityDto> response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}
