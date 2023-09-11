using CityInfo.API.Entities;

namespace CityInfo.API.Repositories
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City?> GetCityAsync(int cityId, bool includePointOfIntrest);

        Task<bool> CityExistAsync(int cityId);

        Task<IEnumerable<PointOfIntrest>> GetPointsOfIntrestForCityAsync(int cityId);

        Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int pointOfIntrestId);

        Task AddPointOfIntrestForCityAsync(int cityId, PointOfIntrest pointOfIntrest);

        Task<bool> SaveChangesAsync();

        Task DeletePointOfIntrestForCityAsync(PointOfIntrest pointOfIntrest);
    }
}
