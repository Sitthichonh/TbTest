using Microsoft.AspNetCore.Mvc;
using TbTest.Interfaces;
using TbTest.Models;

namespace TbTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }
        public IActionResult Login()
        {
            return View();
        }


        //public IActionResult GetUser(string userName, string passWord)
        //{
        //    if (string.IsNullOrEmpty(userName)) return Ok(new { IsSuccess = false, Message = "UserName is not empty" });
        //    if (string.IsNullOrEmpty(passWord)) return Ok(new { IsSuccess = false, Message = "PassWord is not empty" });
        //    if (!userName.Equals("adc")) return Ok(new { IsSuccess = false, Message = "Username is not valid" });
        //    if (!passWord.Equals("adc123")) return Ok(new { IsSuccess = false, Message = "Password is not valid" });
        //    return Ok(new { IsSuccess = true, Message = "Login Success!", Url = "/Home/index" });
        //}  

        public async Task<IActionResult> GetUser(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName)) return Ok(new { IsSuccess = false, Message = "UserName is not empty" });
            if (string.IsNullOrEmpty(password)) return Ok(new { IsSuccess = false, Message = "PassWord is not empty" });

            var user = await _user.GetUserAll();
            var isEmail = userName.Contains("@");
            if (isEmail)
            {
                var result = user.FirstOrDefault(x => x.Email.Equals(userName) && x.Password.Equals(password));
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "ไม่พบข้อมูลผู้ใช้ในระบบ" });
                }
            }
            else
            {
                var result = user.FirstOrDefault(x => x.Username.Equals(userName) && x.Password.Equals(password));
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "ไม่พบข้อมูลผู้ใช้ในระบบ" });
                }
            }

           
            return Ok(new { IsSuccess = true, Message = "Login Success!", Url = "/Home/index", Key = Guid.NewGuid() });

        }
    }
}
