using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/PointOfIntrest")]
    //[Authorize]
    [ApiController]
    public class PointOfIntrestController : ControllerBase
    {

        private readonly ILogger<PointOfIntrestController> logger;
        private readonly IMailService mailService;
        private readonly ICityInfoRepository cityInfoRepository;
        private readonly IMapper mapper;

        public PointOfIntrestController(ILogger<PointOfIntrestController> logger, IMailService mailService, CitiesDataStore citiesDataStore,
            ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailService = mailService ?? throw new ArgumentNullException();
            this.cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfIntrestDto>>> GetPointOfIntrest(int cityId)
        {
            try
            {
                var cityExist = await cityInfoRepository.CityExistAsync(cityId);

                if (!cityExist)
                {
                    string message = $"city with id {cityId} wasnt found";
                    logger.LogError(message);
                    return NotFound();
                }

                var pointOfIntrestForCity = await cityInfoRepository.GetPointsOfIntrestForCityAsync(cityId);

                return Ok(mapper.Map<IEnumerable<PointOfIntrestDto>>(pointOfIntrestForCity));

            }
            catch (Exception exception)
            {
                string message = $"Exception getting {cityId}";
                logger.LogCritical(message, exception);
                return StatusCode(500, "A Problem Happend white ...");
            };
        }

        [HttpGet("{pointOfIntrestId}", Name = "GetPointOfIntrest")]
        public async Task<ActionResult<PointOfIntrestDto>> GetPointOfIntrest(int cityId, int pointOfIntrestId)
        {
            try
            {
                var cityExist = await cityInfoRepository.CityExistAsync(cityId);

                if (!cityExist)
                {
                    string message = $"city with id {cityId} wasnt found";
                    logger.LogError(message);
                    return NotFound();
                }
                var pointOfIntrest = await cityInfoRepository.GetPointOfIntrestForCityAsync(cityId, pointOfIntrestId);

                if (pointOfIntrest == null)
                {
                    string message = $"point Of Intrest with id {pointOfIntrestId} wasnt found";
                    logger.LogError(message);
                    return NotFound();
                }

                return Ok(mapper.Map<PointOfIntrestDto>(pointOfIntrest));

            }
            catch (Exception exeption)
            {
                string message = $"Exeption getting {cityId}";
                logger.LogCritical(message, exeption);
                return StatusCode(500, "A Problem Happend white ...");
            };
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult<PointOfIntrestDto>> CreatePointOfIntrest(int cityId, PointOfIntrestForCreationDto pointOfIntrest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = await cityInfoRepository.CityExistAsync(cityId);

            if (!city)
            {
                return NotFound();
            }

            var finalPointOfIntrest = mapper.Map<Entities.PointOfIntrest>(pointOfIntrest);

            await cityInfoRepository.AddPointOfIntrestForCityAsync(cityId, finalPointOfIntrest);

            await cityInfoRepository.SaveChangesAsync();

            var CreatedPointOfIntrest = mapper.Map<Models.PointOfIntrestDto>(finalPointOfIntrest);

            return CreatedAtRoute("GetPointOfIntrest", new
            {
                CityId = cityId,
                pointOfIntrestId = CreatedPointOfIntrest.Id
            }, CreatedPointOfIntrest);
        }

        #endregion

        // for update all element
        #region Put

        [HttpPut("{PointOfIntrestId}")]
        public async Task<ActionResult> UpdatePointOfIntrestWithPutAsync(int cityId, int pointOfIntrestId, PointOfIntrestForUpdateDto pointOfIntrest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = await cityInfoRepository.CityExistAsync(cityId);

            if (!city)
            {
                return NotFound();
            }

            var pointOfIntrestEntity = await cityInfoRepository.GetPointOfIntrestForCityAsync(cityId, pointOfIntrestId);

            if (pointOfIntrestEntity == null)
            {
                return NotFound();
            }

            mapper.Map(pointOfIntrest, pointOfIntrestEntity);

            await cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        // for update some element
        #region Patch

        [HttpPatch("{PointOfIntrestId}")]
        public async Task<ActionResult> UpdatePointOfIntrestWithPatchAsync(int cityId, int pointOfIntrestId, JsonPatchDocument<PointOfIntrestForUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = await cityInfoRepository.CityExistAsync(cityId);

            if (!city)
            {
                return NotFound();
            }

            var pointOfIntrestEntity = await cityInfoRepository.GetPointOfIntrestForCityAsync(cityId, pointOfIntrestId);

            if (pointOfIntrestEntity == null)
            {
                return NotFound();
            }

            var pointOfIntrestToPatch = mapper.Map<PointOfIntrestForUpdateDto>(pointOfIntrestEntity);

            patchDocument.ApplyTo(pointOfIntrestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(pointOfIntrestToPatch))
            {
                return BadRequest(ModelState);
            }

            mapper.Map(pointOfIntrestToPatch, pointOfIntrestEntity);

            await cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{PointOfIntrestId}")]
        public async Task<ActionResult> DeletePointOfIntrest(int cityId, int pointOfIntrestId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = await cityInfoRepository.CityExistAsync(cityId);

            if (!city)
            {
                return NotFound();
            }

            var pointOfIntrestEntity = await cityInfoRepository.GetPointOfIntrestForCityAsync(cityId, pointOfIntrestId);

            if (pointOfIntrestEntity == null) 
            {  
                return NotFound(); 
            }

            await cityInfoRepository.DeletePointOfIntrestForCityAsync(pointOfIntrestEntity);

            await cityInfoRepository.SaveChangesAsync();

            mailService.Send("Point of intrest deleted", $"Point Of Interst {pointOfIntrestEntity.Name} with id {pointOfIntrestEntity.Id}");

            return NoContent();
        }

        #endregion

    }
}