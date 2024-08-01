using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntitiyRepositoryBase<Customer,ReCapProjectContext>, ICustomerDal
    {
       

        public List<CustomerDetailDto> GetCustomerDetailDto()
        {


            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from p in context.Customers
                             join c in context.Users
                             on p.UserId equals c.Id
                             select new CustomerDetailDto
                             {
                                 UserId = p.UserId,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 Password = c.Password,
                                 CompanyName = p.CompanyName,

                                 
                             };


                return result.ToList();


                

            }

        }
    }
}
