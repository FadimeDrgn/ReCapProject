using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba ismi: " + car.CarName);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Entities.Concrete.Car()
            {BrandId = 2, CarName = "Doblo", ColorId = 5, ModelYear = 2005, DailyPrice = 50, Description = "Arabaya dair herhangi bir sorundan müşteri sorumludur." });
            
        }
    }
}
