﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             orderby c.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorId = c.ColorId,
                                 ColorName = co.ColorName,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = context.CarImages.Where(x=> x.CarId == c.CarId).Select(x=>x.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
