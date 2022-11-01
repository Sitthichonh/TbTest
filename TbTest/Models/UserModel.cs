using System.ComponentModel.DataAnnotations;

namespace TbTest.Models
{
    public class UserModel
    {
        public int UserID { get; set; } = default(int);
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int StatusID { get; set; } = default(int);
    }
}
