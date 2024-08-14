using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetALl")]

        public IActionResult Get()
        {
            var result = _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);    
        }
        [HttpGet("GetByCarId")]

        public IActionResult GetByCarId(int id)
        {

            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddCarImage")]

        public IActionResult Add([FromForm] IFormFile file, [FromForm] int carId)
        {
            CarImage carImage = new() { CarId = carId };
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("UpdateImage")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] int id)
        {
            CarImage carImage = _carImageService.GetById(id).Data;
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteCarImage")]
        public IActionResult Delete([FromForm] IFormFile file, [FromForm] int carId)
        {
            CarImage carImage = new() { CarId = carId };
            var result = _carImageService.Delete(file,carImage);
            if ( result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
