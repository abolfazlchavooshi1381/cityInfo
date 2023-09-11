using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Profiles;
using CityInfo.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.controllers
{
    [Route("api/cities")]
    [Authorize]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository cityInfoRepository;
        private readonly IMapper mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            this.cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {

            var Cities = await cityInfoRepository.GetCitiesAsync();

            if (Cities == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<CityDto>>(Cities));
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetCity(int id, bool includePointOfIntrest = false)
        {

            var city = await cityInfoRepository.GetCityAsync(id, includePointOfIntrest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointOfIntrest)
            {
                return Ok(mapper.Map<CityDto>(city));
            }

            return Ok(mapper.Map<CityWithoutPointOfIntrestDto>(city));
        }
    }
}