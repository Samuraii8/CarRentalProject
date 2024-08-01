using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colordal;

        public ColorManager(IColorDal colorDal)
        {
            _colordal = colorDal;

        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colordal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color color)
        {
           _colordal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colordal.GetAll(), Messages.ColorListed);
            }
        }

        public IDataResult<List<Color>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(d => d.ColorId == colorId), Messages.ColorListed);
        }
    }
}
