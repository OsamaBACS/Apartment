using System.Threading.Tasks;
using BackEnd.Data.Repo;
using BackEnd.Interfaces;

namespace BackEnd.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICityRepository cityRepository => new CityRepository(dc);

        public IUserRepository userRepository => new UserRepository(dc);

        public IPropertyRepository propertyRepository => 
            new PropertyRepository(dc);

        public IPropertyTypeRepository propertyTypeRepository =>
            new PropertyTypeRepository(dc);

        public IFurnishingTypeRepository furnishingTypeRepository => 
            new FurnishingTypeRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}