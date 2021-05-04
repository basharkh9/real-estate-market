using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using real_estate_market.Core.Models;

namespace real_estate_market.Core
{
    public interface IPhotoService
    {
        Task<Photo> UploadPhoto(RealEstate vehicle, IFormFile file, string uploadsFolderPath);
    }
}