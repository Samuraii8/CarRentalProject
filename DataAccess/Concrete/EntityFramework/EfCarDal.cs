using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntitiyRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join co in context.Colors
                             on p.ColorId equals co.ColorId
                             select new CarDetailDto {
                                 Id = p.Id,
                                 Description = p.Description,
                                 BrandName = c.BrandName, 
                                 ColorName = co.ColorName,
                                 ModelYear = p.ModelYear,
                                 DailyPrice = p.DailyPrice,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == p.Id select ci.ImagePath).FirstOrDefault()
                             };
              
                return result.ToList();


            }
        }
        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where car.Id == carId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

    }
}
