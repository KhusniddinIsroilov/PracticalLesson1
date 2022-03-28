using PracticalLesson1.Api.Models;
using PracticalLesson1.Api.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserviewModel user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate);
        Task<User> GetAsync(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate = null);
        Task<User> UpdateFirstname(long id, string firstName);

    }
}
