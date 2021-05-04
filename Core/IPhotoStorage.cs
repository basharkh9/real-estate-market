using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace real_estate_market.Core
{
    public interface IPhotoStorage
    {
        Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}