using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository cityRepository { get; }
         IUserRepository userRepository { get; }
         IPropertyRepository propertyRepository { get; }
         Task<bool> SaveAsync();
    }
}