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
                                 DailyPrice = p.DailyPrice
                             };
              
                return result.ToList();


            }
        }
    }
}
