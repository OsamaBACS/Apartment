using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.models;

namespace BackEnd.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int sellrent);
        Task<Property> GetPropertyDetailAsync(int id);
        Task<Property> GetPropertyByIdAsync(int id);
        void AddProperty(Property property);
        void DeleteProperty(int Id);
    }
}