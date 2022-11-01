using TbTest.Models;

namespace TbTest.Interfaces
{
    public interface IUser
    {
        Task<List<UserModel>> GetUserAll();
        Task<UserModel> GetUserByIdAsync(int UserId);
        Task<UserModel> GetUserByName();
        Task<UserModel> InsertUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int UserId);
    }
}
