using ConsoleApp1;
using PracticalLesson1.Api.Data.IRepositories;
using PracticalLesson1.Api.Models;
using PracticalLesson1.Api.Service.Interfaces;
using PracticalLesson1.Api.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> CreateAsync(UserviewModel userModel)
        {

            User user = new User()
            {
                Firstname = userModel.Firstname,
                Lastname = userModel.Lastname,
                Age = userModel.Age,
                Gender = userModel.Gender,
                Email = userModel.Email,
                Password = Hash.GetHashSha256(userModel.Password)
            };


            return _userRepository.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.DeleteAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate = null)
        {
            return await _userRepository.GetAllAsync(predicate);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.GetAsync(predicate);

        }

        public Task<User> UpdateAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public Task<User> UpdateFirstname(long id, string firstName)
        {
            return _userRepository.UpdateFirstname(id, firstName);
        }
    }
}
