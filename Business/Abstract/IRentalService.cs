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
    public interface IRentalService
    {

        IDataResult<Rental> GetById(int RentalId);

        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<RentalDetailDto>> GetRentalDetail();

    }
}
