﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=2, ColorId=5, DailyPrice=100, ModelYear=2005, Description="Taksit geçerlidir."},
                new Car{Id=2, BrandId=1, ColorId=4, DailyPrice=200, ModelYear=2010, Description="Taksit geçerli değildir."},
                new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=300, ModelYear = 2000, Description="Kredi kartı geçerli." },
                new Car{Id=4, BrandId=1, ColorId=2, DailyPrice=400, ModelYear=2004, Description="Haftalık kiralanabilir."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
