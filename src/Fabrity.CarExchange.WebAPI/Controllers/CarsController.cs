using Fabrity.CarExchange.DataAccess.Entities;
using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.DataAccess.Repositories;
using Fabrity.CarExchange.WebAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        [HttpPost]
        public ActionResult Post([FromBody] CarRequestDto dto)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                Engine = dto.Engine,
                FirstOwner = dto.FirstOwner,
                Created = DateTime.UtcNow
            };
            _carsRepository.Add(car);
            return Created($"/api/cars/{car.Id}", new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Year = car.Year,
                Model = car.Model
            });
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] CarRequestDto dto)
        {
            var car = _carsRepository.Get(id);
            if (car is null)
            {
                return BadRequest();
            }

            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.Engine = dto.Engine;
            car.FirstOwner = dto.FirstOwner;
            _carsRepository.Update(car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingCar = _carsRepository.Get(id);
            if (existingCar is null)
            {
                return BadRequest();
            }

            _carsRepository.Delete(existingCar);
            return NoContent();
        }
    }
}
