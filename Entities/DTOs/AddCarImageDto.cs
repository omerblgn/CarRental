using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddCarImageDto
    {
        public int CarId { get; set; }
        public IFormFile formFile { get; set; }
    }
}
