using System.Threading.Tasks;
using BackEnd.models;

namespace BackEnd.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Authenticate(string userName, string password);
    }
}