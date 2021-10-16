using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository cityRepository { get; }
         IUserRepository userRepository { get; }
         Task<bool> SaveAsync();
    }
}