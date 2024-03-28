using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IFileService
    {
        string Add(IFormFile formFile, string uploadPath);
        string Update(string pathToUpdate, IFormFile formFile, string uploadPath);
        void Delete(string path);
    }
}
