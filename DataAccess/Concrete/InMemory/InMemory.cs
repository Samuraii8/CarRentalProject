using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemory : ICarDal
    {

        List<Car> _cars;

        public InMemory()
        {

            _cars = new List<Car>
            {
                new Car { Id = 1,BrandId=1, ColorId=3,DailyPrice=5198.15, ModelYear=2010,Description="Ford Mustang"},
                new Car { Id = 2,BrandId=2, ColorId=3,DailyPrice=1820.50, ModelYear=2022,Description="Tesla  Suv"},
                new Car { Id = 3,BrandId=2, ColorId=3,DailyPrice=125.4, ModelYear=2015,Description="OPEL CORSA 1.6V"},
                new Car { Id = 4,BrandId=1, ColorId=3,DailyPrice=45984.45, ModelYear=2019,Description="BMW M4"},
                new Car { Id = 5,BrandId=1, ColorId=3,DailyPrice=56875.35, ModelYear=2017,Description="Ford GT Sport"},
                new Car { Id = 6,BrandId=1, ColorId=3,DailyPrice=120.50, ModelYear=1985,Description="Ferrari GT"},

            };

        }





        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car? carsToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carsToDelete);
        }

        public void DeleteById(Car car)
        {
            Car? carsToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carsToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            var car = _cars.SingleOrDefault(p => p.Id == id);
            return car;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car? carToUpdate = _cars.SingleOrDefault(m => m.BrandId == car.BrandId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
