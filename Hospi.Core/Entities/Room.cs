using Hospi.Core.Interfaces;

namespace Hospi.Core.Entities
{
    public class Room : IEntity
    {
        public Guid Id { get; set; }
        public double Sqm { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool Indefinite { get; set; }
        public decimal Price { get; set; }
        public Guid HouseId { get; set; }
        public House House { get; set; }
    }
}
