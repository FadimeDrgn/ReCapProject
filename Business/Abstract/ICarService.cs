using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId); // hatalı Liste olamaz
        List<Car> GetCarsByColorId(int colorId); //aynı şekilde T olmalı
    }
}
