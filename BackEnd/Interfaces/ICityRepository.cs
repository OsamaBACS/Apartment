using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.models;

namespace BackEnd.Interfaces
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();
         void AddCity(City city);
         void DeleteCity(int cityId);
        Task<City> FindCity(int id);
    }
}