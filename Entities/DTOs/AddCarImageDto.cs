using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class AddCarImageDto : IDto
    {
        public int CarId { get; set; }
        public IFormFile formFile { get; set; }
    }
}
