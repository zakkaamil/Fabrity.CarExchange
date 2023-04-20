using Fabrity.CarExchange.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrity.CarExchange.Services.Interfaces
{
    public interface ICarsService
    {
        CarDetailsDto Get(Guid carId);
        IEnumerable<CarDto> Browse();
        CarDto Add(CarRequestDto dto);
        void Update(Guid carId, CarRequestDto dto);
        void Delete(Guid carId);
    }
}
