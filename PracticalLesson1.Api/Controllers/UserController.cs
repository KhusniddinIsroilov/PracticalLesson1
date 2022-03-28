using Microsoft.AspNetCore.Mvc;
using PracticalLesson1.Api.Models;
using PracticalLesson1.Api.Service.Interfaces;
using PracticalLesson1.Api.Service.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public Task<User> Create(UserviewModel model)
        {
            return _userService.CreateAsync(model);
        }

        [HttpGet]
        public async Task<User> User(long id)
        {
            return await _userService.GetAsync(o => o.Id == id);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPut]
        public Task<User> Update(User user)
        {
            return _userService.UpdateAsync(user);
        }

        [HttpDelete]
        public Task<bool> Delete(long id)
        {
            return _userService.DeleteAsync(i => i.Id.Equals(id));
        }
        [HttpPatch]
        public Task<User> UpdatePatch(long id, string firstname)
        {
            return _userService.UpdateFirstname(id, firstname);
        }



    }
}
