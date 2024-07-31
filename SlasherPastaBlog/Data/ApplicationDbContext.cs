using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlasherPastaBlog.Models;

namespace SlasherPastaBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //relationship
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Artigos)
                .WithOne(a => a.ApplicationUser)
                .HasForeignKey(a => a.ApplicationUserId);

            builder.Entity<Artigos>()
                .HasMany(a => a.Ratings)
                .WithOne(ar => ar.Artigo)
                .HasForeignKey(ar => ar.ArtigoId);

            // New ArtigoRatings model
            builder.Entity<ArtigoRatings>()
                .HasKey(ar => ar.Id);
        }
        public DbSet<SlasherPastaBlog.Models.Artigos> Artigos { get; set; } = default!;
        public DbSet<ArtigoRatings> ArtigoRatings { get; set; } = default!;
    }
}