using Hospi.Core.Interfaces;

namespace Hospi.Core.Entities
{
    public class House : IEntity
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Adres => $"{StreetName} {HouseNumber}";
        public string Affiliation { get; set; }
        public Room Room { get; set; }
        public Guid OwnerId { get; set; }
        public AppUser Owner { get; set; }
    }
}
