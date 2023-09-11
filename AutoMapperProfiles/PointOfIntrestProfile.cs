using AutoMapper;

namespace CityInfo.API.AutoMapperProfiles
{
    public class PointOfIntrestProfile: Profile
    {
        public PointOfIntrestProfile()
        {
            CreateMap<Entities.PointOfIntrest, Models.PointOfIntrestDto>();

            CreateMap<Models.PointOfIntrestForCreationDto, Entities.PointOfIntrest>();

            CreateMap<Models.PointOfIntrestForUpdateDto, Entities.PointOfIntrest>();

            CreateMap<Entities.PointOfIntrest, Models.PointOfIntrestForUpdateDto>();
        }
    }
}
