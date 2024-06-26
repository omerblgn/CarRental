﻿using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileOperations
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
