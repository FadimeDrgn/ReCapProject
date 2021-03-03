using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AddTest();

        }

        private static void AddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "BMW" });

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 350, Description = "Genç", ModelYear = 2015 });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Siyah" });
        }
    }
}
