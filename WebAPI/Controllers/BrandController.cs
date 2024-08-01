using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            
            _brandService = brandService;

        }

        [HttpGet("GetAllBrands")]

        public IActionResult Getall()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {

                return Ok(result);
                
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetBrandsById")]


        public IActionResult GetALL(int id)
        {

            var result = _brandService.GetByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            { 

                return BadRequest(result); 
            }
        }



    }
}
