using Microsoft.AspNetCore.Mvc;
using TbTest.Interfaces;

namespace TbTest.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _client;
        public UserController(IUser user)
        {
            _client = user;
        }


        [HttpGet]
        public async Task<IActionResult> GetUserAll()
        {
            try
            {
                var users = await _client.GetUserAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
