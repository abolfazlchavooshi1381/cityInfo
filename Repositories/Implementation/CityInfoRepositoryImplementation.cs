using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Repositories.Implementation
{
    public class CityInfoRepositoryImplementation : ICityInfoRepository
    {
        private readonly CityInfoDbContexts cityInfoDbContexts;

        public CityInfoRepositoryImplementation(CityInfoDbContexts cityInfoDbContexts)
        {
            this.cityInfoDbContexts = cityInfoDbContexts ?? throw new ArgumentException(nameof(cityInfoDbContexts));
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await cityInfoDbContexts.Cities.Include(city => city.PointOfIntrest).OrderBy(city => city.Name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfIntrest)
        {
            if (includePointOfIntrest)
            {
                return await cityInfoDbContexts.Cities.Include(city => city.PointOfIntrest).Where(city => city.Id == cityId).FirstOrDefaultAsync();
            }
            return await cityInfoDbContexts.Cities.Where(city => city.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<bool> CityExistAsync(int cityId)
        {
            {
                return await cityInfoDbContexts.Cities.AnyAsync(city => city.Id == cityId);
            }
        }

        public async Task<IEnumerable<PointOfIntrest>> GetPointsOfIntrestForCityAsync(int cityId)
        {
            return await cityInfoDbContexts.PointsOfIntrest.Where(point => point.cityId == cityId).ToListAsync();
        }

        public async Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int pointOfIntrestId)
        {
            return await cityInfoDbContexts.PointsOfIntrest.Where(point => point.cityId == cityId && point.Id == pointOfIntrestId).FirstOrDefaultAsync();
        }

        public async Task AddPointOfIntrestForCityAsync(int cityId, PointOfIntrest pointOfIntrest)
        {
            var city = await GetCityAsync(cityId, false);

            if (city != null)
            {
                city.PointOfIntrest.Add(pointOfIntrest);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await cityInfoDbContexts.SaveChangesAsync() > 0);
        }


        public async Task DeletePointOfIntrestForCityAsync(PointOfIntrest pointOfIntrest)
        {
            cityInfoDbContexts.PointsOfIntrest.Remove(pointOfIntrest);
        }
    }
}
