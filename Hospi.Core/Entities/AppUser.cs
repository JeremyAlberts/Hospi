using Microsoft.AspNetCore.Identity;

namespace Hospi.Core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IReadOnlyCollection<House> Houses => _houses.AsReadOnly();
        private List<House> _houses = [];
    }
}
