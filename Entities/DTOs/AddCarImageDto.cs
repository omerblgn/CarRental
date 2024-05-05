using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class AddCarImageDto : IDto
    {
        public int CarId { get; set; }
        public List<IFormFile> FormFiles { get; set; }
    }
}
