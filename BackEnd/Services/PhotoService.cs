
using System.Threading.Tasks;
using BackEnd.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Services
{
    public class PhotoService : IPhotoService
    {
        public readonly Cloudinary cloudinary;
        public PhotoService(IConfiguration config)
        {
            Account account = new Account(
                "osamabacs",
                "591242686796747",
                "tgvy496cpuRcLyK06_HP5DnCcFE"
            );

            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploasResult = new ImageUploadResult();
            if(photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(800)
                };
                uploasResult = await cloudinary.UploadAsync(uploadParams);
            }
            return uploasResult;
        }
    }
}