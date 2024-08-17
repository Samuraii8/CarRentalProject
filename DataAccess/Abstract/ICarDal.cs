﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Abstract
{
    public interface ICarDal : IEntitiyRepository<Car>
    {

        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailByCarId(int Id);



    }
}
// Code Refactoring 