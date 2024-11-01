using Hospi.Core.Interfaces;

namespace Hospi.Core.Entities
{
    public class Offer : IEntity
    {
        public Guid Id { get; set; }
        public Guid HouseId { get; set; }
        public required House House { get; set; }
        public Guid RoomId { get; set; }
        public required Room Room { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
