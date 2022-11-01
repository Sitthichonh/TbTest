using Microsoft.AspNetCore.Mvc;
using TbTest.Models;

namespace TbTest.Interfaces
{
    public interface IThaipost
    {
        Task<List<ThaipostModel>> GetThaipostAll();
        Task<ThaipostModel> GetThaipostByIdAsync(string ZipCode);
    }
}
