using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService 
    {
        ICarDal _cardal;

       
      

        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;
        }

       public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            if(CheckIfBrandIdCount(car.BrandId).Success)
            {
                _cardal.Add(car);
                return new SuccessResult(Messages.CarListed);
            }
            return new ErorResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarListed);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.BrandId == BrandId), Messages.CarListed);
;       }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p=> p.ColorId == ColorId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByUnitPrice(double min,double max)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(u => u.DailyPrice >= min && u.DailyPrice <= max), Messages.CarListed);
        }

        public IResult Update(Car car)
        {
           _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfBrandIdCount(int brandId)
        {
            var result = _cardal.GetAll(p => p.BrandId == brandId).Count;
            if (result >=3)
            {
                return new ErorResult(Messages.CarBrandCountOfCategoryEror);
            }
            return new SuccessResult();
        }
    }
}
