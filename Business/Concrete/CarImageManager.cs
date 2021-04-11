using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.TransactionScopeAspect;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckCarImageLımıt(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var result1 = CarImagesFileHelper.Add(formFile);
            carImage.ImagePath = result1;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult("Araba resmi eklendi.");
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckForDeleteImage(carImage.Id));
            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult("Araba resmi silindi.");
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfAnyCarImageExists(carId));
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(CarImage carImage, IFormFile file)
        {
            Add(carImage, file);
            Update(carImage, file);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckCarImageLımıt(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult("Araba resmi güncellendi.");
        }

        private IResult CheckCarImageLımıt(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CheckCarImageLımıtError);
            }
            return new SuccessResult();
        }

        private IResult CheckForDeleteImage(int id)
        {
            bool result = _carImageDal.GetAll(c => c.Id == id).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckCarForDeleteImageError);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfAnyCarImageExists(int carId)
        {
            string path = @"\images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImageDal.GetAll(p => p.CarId == carId);
            }

            return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
        }

    }
}
