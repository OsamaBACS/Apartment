using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.models;

namespace BackEnd.Interfaces
{
    public interface IPropertyTypeRepository
    {
         Task<IEnumerable<PropertyType>> GetPropertyTypeAsync();
    }
}