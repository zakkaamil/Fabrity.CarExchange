using Fabrity.CarExchange.DataAccess.Entities;
using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.Services.Dto;
using Fabrity.CarExchange.Services.Exceptions;
using Fabrity.CarExchange.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrity.CarExchange.Services.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;

        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public CarDetailsDto Get(Guid carId)
        {
            var car = _carsRepository.Get(carId);
            if (car is null)
            {
                throw new CarNotFoundException();
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
            return result;
        }

        public IEnumerable<CarDto> Browse()
        {
            var cars = _carsRepository.Browse();
            var result = cars.Select(c => new CarDto
            {
                Id = c.Id,
                Brand = c.Brand,
                Year = c.Year,
                Model = c.Model
            });
            return result;
        }

        public CarDto Add(CarRequestDto dto)
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

            return new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Year = car.Year,
                Model = car.Model
            };
        }

        public void Update(Guid carId, CarRequestDto dto)
        {
            var car = _carsRepository.Get(carId);
            if (car is null)
            {
                throw new CarNotFoundException();
            }

            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.Engine = dto.Engine;
            car.FirstOwner = dto.FirstOwner;

            _carsRepository.Update(car);
        }

        public void Delete(Guid carId)
        {
            var car = _carsRepository.Get(carId);
            if (car is null)
            {
                throw new CarNotFoundException();
            }

            // Removal policy, permission check can be put there

            _carsRepository.Delete(car);
        }
    }
}
