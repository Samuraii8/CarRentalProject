﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
       

        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file,CarImage carImage);
        IResult Update(IFormFile file,CarImage carImage);
        IResult Delete(IFormFile file,CarImage carImage);

        IDataResult<CarImage> GetById(int id);
        IDataResult<CarImage> GetByImageId(int imageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);

    }
}
