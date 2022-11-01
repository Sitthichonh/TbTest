using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TbTest.Interfaces;
using TbTest.Models;

namespace TbTest.Repository
{
    public class UserRepository : IUser
    {
        private const string BaseUrl = "http://localhost:5160/api/User";
        private readonly HttpClient _client;

        public UserRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<UserModel>> GetUserAll()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<UserModel>>(content);

            return tasks;
        }

        public async Task<UserModel> GetUserByIdAsync(int UserId)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{UserId}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var todoItem = JsonConvert.DeserializeObject<UserModel>(content);

            return todoItem;
        }

        public Task<UserModel> GetUserByName()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> InsertUserAsync(UserModel user)
        {
            var content = JsonConvert.SerializeObject(user);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a user task");
            }

            var createdTask = JsonConvert.DeserializeObject<UserModel>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var content = JsonConvert.SerializeObject(user);
            var httpResponse = await _client.PutAsync($"{BaseUrl}{user.UserID}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update user task");
            }

            var createdTask = JsonConvert.DeserializeObject<UserModel>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteUserAsync(int UserId)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{UserId}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the user item");
            }
        }
    }
}
