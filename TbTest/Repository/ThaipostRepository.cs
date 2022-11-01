using Newtonsoft.Json;
using TbTest.Interfaces;
using TbTest.Models;

namespace TbTest.Repository
{
    public class ThaipostRepository : IThaipost
    {
        private const string BaseUrl = "http://localhost:5160/api/Thaipost/";
        private readonly HttpClient _client;
        public ThaipostRepository(HttpClient client)
        {
            _client = client;
        }

        public Task<List<ThaipostModel>> GetThaipostAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ThaipostModel> GetThaipostByIdAsync(string ZipCode)
        {
            var thaipost = await _client.GetAsync($"{BaseUrl}{ZipCode}");
            if (!thaipost.IsSuccessStatusCode)
            {
                throw new Exception($"[{(int)thaipost.StatusCode} {thaipost.StatusCode}]");
            }

            var postof = await thaipost.Content.ReadAsStringAsync();
            var postItem = JsonConvert.DeserializeObject<ThaipostModel>(postof);
            return postItem;
        }
    }
}
