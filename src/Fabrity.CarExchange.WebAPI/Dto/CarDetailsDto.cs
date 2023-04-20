namespace Fabrity.CarExchange.WebAPI.Dto
{
    public class CarDetailsDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public bool FirstOwner { get; set; }
    }
}
