using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.DataAccess.Repositories;
using Fabrity.CarExchange.WebAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fabrity.CarExchange.WebAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var car = _carsRepository.Get(id);
            if (car is null)
            {
                return NotFound();
            }

            var result = new CarDetailsDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Color = car.Color,
                Engine = car.Engine,
                FirstOwner = car.FirstOwner
            };

            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var cars = _carsRepository.Browse();
            var result = cars.Select(c => new CarDto
            {
                Id = c.Id,
                Brand = c.Brand,
                Year = c.Year,
                Model = c.Model
            });
            return Ok(result);
        }
    }
}
