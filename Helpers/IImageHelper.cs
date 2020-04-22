using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SoccerWebApi.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);

        string UploadImage(byte[] pictureArray, string folder);
    }
}
