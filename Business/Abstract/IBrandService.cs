﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {

        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetByBrandId(int brandId);
            
        IResult Add(Brand brand);

        IResult Delete(Brand brand);


    }
}
