using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntitiyRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.Id equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 Description = c.Description,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
