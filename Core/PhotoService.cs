using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using real_estate_market.Core.Models;

namespace real_estate_market.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPhotoStorage photoStorage;
        public PhotoService(IUnitOfWork unitOfWork, IPhotoStorage photoStorage)
        {
            this.photoStorage = photoStorage;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Photo> UploadPhoto(RealEstate realEstate, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new Photo { FileName = fileName };
            realEstate.Photos.Add(photo);
            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}