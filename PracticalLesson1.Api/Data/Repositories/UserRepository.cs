using PracticalLesson1.Api.Data.IRepositories;
using PracticalLesson1.Api.Models;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PracticalDbContext practicalDbContext) : base(practicalDbContext)
        {
        }

        public async Task<User> UpdateFirstname(long id, string firstname)
        {
            var user = await _dbSet.FindAsync(id);
            user.Firstname = firstname;

            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
