using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using Business.Abstract;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Entities.DTOs;
using System.Runtime.InteropServices;

namespace ReCapProject 
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //IoC 
            // Data Transformation Object
            //BrandTest();
            //CarBrandColorTest();
        }


        private static void RentalAddTest()
        {
            Rental rental1 = new Rental() { RentalId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(1), ReturnDate = DateTime.Now.AddDays(3) };
            IRentalService rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(rental1);
            Console.WriteLine(result.Message);
        }

        //private static void CustomerTest()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            
        //    CustomerDetailDto customer = new CustomerDetailDto() { FirstName = "Tuğçe", LastName = "Tuncay", Email = "tugce@gmail.com", Password = "12345", CompanyName = "Tuğçe Ticaret" };
        //    customerManager.Add(customer);
        //}           

        

         private static void CarBrandColorTest()
         {
            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());

            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);
            foreach (var car in result.Data)
            {
                Console.WriteLine("Araba Markası: " + car.BrandName + "-- Araba Modeli: " + car.DailyPrice + "-- Araba Rengi: " + car.ColorName + "\n");

            } 
         }
    }
}