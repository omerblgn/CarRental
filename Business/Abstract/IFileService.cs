using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        string Add(IFormFile formFile, string uploadPath);
        string Update(string pathToUpdate, IFormFile formFile, string uploadPath);
        void Delete(string path);
    }
}
