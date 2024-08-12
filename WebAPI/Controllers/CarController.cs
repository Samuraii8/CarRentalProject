using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("GetCarDetail")]
       public IActionResult Getalls()
        {
            var result = _carService.GetCarDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("Get All Cars")]

        public IActionResult GetAll()
        {

            Thread.Sleep(5000);

            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetCarsById")]


        public  IActionResult GetAll(int Id)
        {
            var result = _carService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("Add Cars")]


        public IActionResult Post(Car car)
        {

            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
