using Hospi.Core.Entities;

namespace Hospi.Core.Models.House
{
    public class HouseCreateModel
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Affiliation { get; set; }
        public AppUser Owner { get; set; }
    }
}
