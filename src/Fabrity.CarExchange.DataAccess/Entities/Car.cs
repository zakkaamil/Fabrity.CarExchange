using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrity.CarExchange.DataAccess.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model  { get; set; }
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public bool FirstOwner { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
