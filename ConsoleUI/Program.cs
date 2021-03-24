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
            //CustomerManager customerManager1 = new CustomerManager(new EfCustomerDal());
            //customerManager1.Add(new Customer
            //{

            //    UserId = 4,
            //    CompanyName = "D Company"
            //});
            //UserAddTest();
            //CustomerAddTest();

            //AddTest();
            //CarManager carManager1 = new CarManager(new EfCarDal());
            //carManager1.Update(new Car
            //{
            //    CarId = 3,
            //    BrandId = 4,
            //    ColorId = 2,
            //    DailyPrice = 1000000,
            //    Description = "Tesla Model S",
            //    ModelYear = 2012
            //});

        }

        private static void UserAddTest()
        {
            UserManager userManager1 = new UserManager(new EfUserDal());
            userManager1.Add(new User
            {
                FirstName = "Halime",
                LastName = "Yeşil",
                Email = "asdfghn58@gmail.com",
                Password = "asdfghn58"
            });
        }

        //private static void CustomerAddTest()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    customerManager.Add(new Customer
        //    {

        //        UserId = 5,
        //        CompanyName = "C Company"
        //    });
        //}

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
