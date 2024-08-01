using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }


        public IResult Add(User user)
        {
           if (user.Password.Length <= 6) 
            {
                return new ErorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _userdal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            
            _userdal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<User>>(_userdal.GetAll(), Messages.UserListed);
            }
        }

        public IDataResult<List<User>> GetByUserId(int Id)
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(u => u.Id == Id),Messages.UserListed);
        }

        public IResult Update(User user)
        {
           _userdal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
