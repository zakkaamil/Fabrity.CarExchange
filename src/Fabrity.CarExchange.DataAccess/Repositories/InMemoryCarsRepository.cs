using Fabrity.CarExchange.DataAccess.Entities;
using Fabrity.CarExchange.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrity.CarExchange.DataAccess.Repositories
{
    public class InMemoryCarsRepository : ICarsRepository
    {
        private readonly ISet<Car> _cars = new HashSet<Car>()
        {
            new()
            {
                Id = new Guid("cfde7c58-8c66-4500-8647-e4f35b0ae3ca"),
                Brand = "Volkswagen",
                Model = "Passat",
                Year = 2006,
                Color = "Red",
                Engine = "1.9 TDI",
                FirstOwner = false,
                Created = new DateTime(2023, 1, 1)
            },
            new()
            {
                Id = new Guid("7aed0c5e-35d2-4b72-a453-cc3784fe283a"),
                Brand = "Peugeot",
                Model = "307",
                Year = 2007,
                Color = "Silver",
                Engine = "1.6 HDI",
                FirstOwner = true,
                Created = new DateTime(2023, 1, 2)
            }
        };
        public Car Get(Guid carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public IEnumerable<Car> Browse()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            car.LastUpdated = DateTime.UtcNow;
        }

        public void Delete(Car car)
        {
            _cars.Remove(car);
        }
    }
}
