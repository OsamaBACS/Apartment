using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Repo
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DataContext dc;
        public PropertyTypeRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypeAsync()
        {
            return await dc.PropertyTypes.ToListAsync();
        }
    }
}