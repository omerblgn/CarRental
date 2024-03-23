using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();

//BrandTest();

//ColorTest();

//UserTest();

RentalTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();
    if (result.Success)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName + " " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    var result = brandManager.Add(new Brand { Name = "aa" });
    if (result.Success)
    {
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    var result = colorManager.GetAll();
    if (result.Success)
    {
        foreach (var color in result.Data)
        {
            Console.WriteLine(color.Name);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    var result = userManager.GetAll();
    if (result.Success)
    {
        foreach (var user in result.Data)
        {
            Console.WriteLine(user.FirstName + " " + user.LastName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    var result = rentalManager.Add(new Rental { CarId = 2, CustomerId = 2 });
    if (result.Success)
    {
        //foreach (var rental in result.Data)
        //{
        //    Console.WriteLine(rental.CarId);
        //}
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}