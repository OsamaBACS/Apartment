using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dc;
        public PropertyRepository(DataContext dc)
        {
            this.dc = dc;

        }

        public void AddProperty(Property property)
        {
            dc.Properties.Add(property);
        }

        public void DeleteProperty(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellrent)
        {
            var properties = await dc.Properties
            .Include(p => p.PropertyType)
            .Include(p => p.City)
            .Include(p => p .FurnishingType)
            .Where(p => p.SellRent == sellrent)
            .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var properties = await dc.Properties
            .Include(p => p.PropertyType)
            .Include(p => p.City)
            .Include(p => p.FurnishingType)
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();
            return properties;
        }
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var properties = await dc.Properties
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();
            return properties;
        }
    }
}