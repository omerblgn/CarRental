using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
