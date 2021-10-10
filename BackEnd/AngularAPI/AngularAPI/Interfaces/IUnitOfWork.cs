using System.Threading.Tasks;

namespace AngularAPI.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository cityRepository { get; }
         Task<bool> SaveAsync();
    }
}