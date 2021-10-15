using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository cityRepository { get; }
         Task<bool> SaveAsync();
    }
}