namespace Hopsi.Api.DTOs.House
{
    public class HouseCreateDTO
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Affiliation { get; set; }
    }
}
