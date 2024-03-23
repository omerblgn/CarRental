using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarTest();

//BrandTest();

//ColorTest();

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