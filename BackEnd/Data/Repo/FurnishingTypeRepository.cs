using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Repo
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        private readonly DataContext dc;
        public FurnishingTypeRepository(DataContext dc)
        {
            this.dc = dc;

        }

        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypeAsync()
        {
            return await dc.FurnishingTypes.ToListAsync();
        }
    }
}