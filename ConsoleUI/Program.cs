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

    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.CarName + " " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());

    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.Name);
    }
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine(color.Name);
    }
}