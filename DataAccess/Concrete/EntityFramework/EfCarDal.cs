using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsById(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             where b.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             where co.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByFilters(List<string> brandNames, List<string> colorNames, decimal? minPrice, decimal? maxPrice, string? minYear, string? maxYear)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };

                if (brandNames.Count > 0)
                {
                    result = result.Where(c => brandNames.Contains(c.BrandName));
                }

                if (colorNames.Count > 0)
                {
                    result = result.Where(c => colorNames.Contains(c.ColorName));
                }

                if (minPrice != null)
                {
                    result = result.Where(c => c.DailyPrice >= minPrice);
                }

                if (maxPrice != null)
                {
                    result = result.Where(c => c.DailyPrice <= maxPrice);
                }

                if (!string.IsNullOrEmpty(minYear))
                {
                    result = result.Where(c => Convert.ToInt32(c.ModelYear) >= Convert.ToInt32(minYear));
                }

                if (!string.IsNullOrEmpty(maxYear))
                {
                    result = result.Where(c => Convert.ToInt32(c.ModelYear) <= Convert.ToInt32(maxYear));
                }

                return result.ToList();
            }
        }
    }
}
