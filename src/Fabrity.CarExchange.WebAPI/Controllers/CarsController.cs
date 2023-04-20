using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.DataAccess.Repositories;
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

            return Ok(car);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var cars = _carsRepository.Browse();
            return Ok(cars);
        }
    }
}
