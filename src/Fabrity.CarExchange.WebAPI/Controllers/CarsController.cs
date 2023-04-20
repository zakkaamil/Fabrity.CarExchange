using Fabrity.CarExchange.DataAccess.Entities;
using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.DataAccess.Repositories;
using Fabrity.CarExchange.Services.Dto;
using Fabrity.CarExchange.Services.Exceptions;
using Fabrity.CarExchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Fabrity.CarExchange.WebAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            CarDetailsDto result;

            try
            {
                result = _carsService.Get(id);
            }
            catch (CarNotFoundException)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _carsService.Browse();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CarRequestDto dto)
        {
            var result = _carsService.Add(dto);
            return Created($"/api/cars/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] CarRequestDto dto)
        {
            CarDetailsDto car;

            try
            {
                car = _carsService.Get(id);
            }
            catch (CarNotFoundException)
            {
                return NotFound();
            }

            _carsService.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CarDetailsDto car;

            try
            {
                car = _carsService.Get(id);
            }
            catch (CarNotFoundException)
            {
                return NotFound();
            }

            _carsService.Delete(id);
            return NoContent();
        }
    }
}
