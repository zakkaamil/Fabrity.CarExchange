using System.ComponentModel.DataAnnotations;

namespace Fabrity.CarExchange.WebAPI.Dto
{
    public class CarRequestDto
    {
        [Required]
        [MinLength(3)]
        public string Brand { get; set; }
        [Required]
        [MinLength(3)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public bool FirstOwner { get; set; }
    }
}
