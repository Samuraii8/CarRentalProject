﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        //IResult AddTransactionalTest(Car car);
        

        IDataResult<Car> GetById(int Id);

        IDataResult<List<Car>> GetByUnitPrice(double min, double max);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int Id);
        IDataResult<List<Car>>GetCarsByBrandId(int BrandId);
        IDataResult<List<Car>>GetCarsByColorId(int ColorId);

    }
}
