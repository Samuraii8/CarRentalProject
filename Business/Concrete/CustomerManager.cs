using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerdal;

        public CustomerManager(ICustomerDal customerService)
        {
            _customerdal = customerService;
        }


        public IResult Add(Customer customer)
        {
            _customerdal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

      

        public IResult Delete(Customer customer)
        {
           _customerdal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            if (DateTime.Now.Hour == 16)
            {
                return new ErorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerdal.GetAll(), Messages.CustomerListed);
            }
        }

        public IDataResult<List<Customer>> GetByUserId(int UserId)
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll(p => p.UserId == UserId), Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerdal.GetCustomerDetailDto(),Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
           _customerdal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}