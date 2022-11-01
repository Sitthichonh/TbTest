using Microsoft.AspNetCore.Mvc;
using TbTest.Interfaces;

namespace TbTest.Controllers
{
    public class ThaipostController : Controller
    {
        private readonly IThaipost _thaipost;

        public ThaipostController(IThaipost thaipost)
        {
            _thaipost = thaipost;
        }
        public IActionResult Thaipost()
        {
            return View();
        }

        public async Task<IActionResult> GetThaiPostByZipCode(string ZipCode)
        {
            try
            {
                var result = await _thaipost.GetThaipostByIdAsync(ZipCode);
                if (result is null)
                {
                    return Ok(new { IsSuccess = false, Message = "Data Not Found.", Result = "" });
                }
                return Ok(new { IsSuccess = true, Message = "Success", Result = result });
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccess = false, Message = ex.Message, Result = "" });
            }
            
        }
    }
}
