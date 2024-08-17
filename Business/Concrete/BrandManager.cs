using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using Core.Utilities.Results;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
           if (brand.BrandName.Length < 2)
           {
                return new ErorResult(Messages.BrandNameInvalid);
           }
           else
            {
                _brandDal.Add(brand);   
                return new SuccessResult(Messages.BrandAdded);
            }

        }

        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
            }
        }

        public IDataResult<List<Brand>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == brandId), Messages.BrandListed);
        }
    }
}
