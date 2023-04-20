using Fabrity.CarExchange.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrity.CarExchange.DataAccess.Interfaces
{
    public interface ICarsRepository
    {
        Car Get(Guid carId);
        IEnumerable<Car> Browse();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car carId);
    }
}
