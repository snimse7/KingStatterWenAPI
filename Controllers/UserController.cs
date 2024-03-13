using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Statter_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _user;
        public UserController(IUserLogic match)
        {
            _user = match;
        }

        [HttpPost]
        [Route("/NewUserRegistration")]
        public async Task<IActionResult> NewUserRegistration(User user)
        {
            try
            {
                return Ok(await _user.newUser(user));
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet]
        [Route("/GetUser")]
        public async Task<IActionResult> GetUser(string userName)
        {
            try
            {
                return Ok(await _user.GetUser(userName)); 
            }
            catch { throw; }
        }

        [HttpGet]
        [Route("/SignIn")]
        public async Task<IActionResult> SignInUser(string userName,string passWord)
        {
            try
            {
                return Ok(await _user.signInUser(userName,passWord));
            }
            catch { throw; }
        }

        [HttpGet]
        [Route("/CheckUserPresentOrNot")]
        public async Task<IActionResult> CheckUserPresentOrNot(string userName)
        {
            try
            {
                return Ok(await _user.checkUserPresent(userName));
            }
            catch { throw; }
        }
    }
}
