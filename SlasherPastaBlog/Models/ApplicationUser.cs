using Microsoft.AspNetCore.Identity;

namespace SlasherPastaBlog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }

        // Relationship
        public ICollection<Artigos> Artigos { get; set; } = default!;
    }
}
