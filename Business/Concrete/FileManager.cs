using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        public string Add(IFormFile formFile, string uploadPath)
        {
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            return uploadPath;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string Update(string pathToUpdate, IFormFile formFile, string uploadPath)
        {
            if (formFile.Length > 0 && uploadPath.Length > 0)
            {
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(pathToUpdate);
            return uploadPath;
        }
    }
}
