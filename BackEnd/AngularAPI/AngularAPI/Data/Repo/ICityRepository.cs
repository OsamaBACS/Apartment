using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAPI.models;

namespace AngularAPI.Data.Repo
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();

         void AddCity(City city);

         void DeleteCity(int cityId);

         Task<bool> SaveAsync();
    }
}