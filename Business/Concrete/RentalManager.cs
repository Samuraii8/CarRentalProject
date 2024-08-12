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
    public class RentalManager : IRentalService
    {

        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentaldal = rentalDal;
        }


        public IResult Add(Rental rental)
        {
            var result = _rentaldal.Get(r => r.Id == rental.RentalId);
            var time = result == null ? -1 : DateTime.Compare((DateTime)result.ReturnDate, rental.RentDate);

            if (rental.ReturnDate == null || time >= 0)
            {
                return new ErorResult(Messages.CarNotRentaled);
            }
            else
            {
                _rentaldal.Add(rental);
                return new SuccessResult(Messages.CarRentaled);
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            if (DateTime.Now.Hour == 14)
            {
                return new ErorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.RentalListed);
            }
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(p => p.RentalId == RentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetRentalDetail(),Messages.RentalDetailListed);
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }    
}