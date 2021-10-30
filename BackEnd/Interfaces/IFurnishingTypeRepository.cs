using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.models;

namespace BackEnd.Interfaces
{
    public interface IFurnishingTypeRepository
    {
        Task<IEnumerable<FurnishingType>> GetFurnishingTypeAsync();
    }
}