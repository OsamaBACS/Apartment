using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Interfaces
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
         // Will add one or more than method for deleting the photo.
    }
}