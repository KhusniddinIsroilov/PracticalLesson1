using PracticalLesson1.Api.Models;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UpdateFirstname(long id, string firstname);
    }
}
