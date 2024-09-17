using BCASRequireMates.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BCASRequireMates.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        
        {
            
        }
        public DbSet<BCASRequireMates.Models.Document> Document { get; set; } = default!;
        public DbSet<UserDocumentRequest> UserDocumentRequests { get; set; } = default;
        //public DbSet<DocumentRequest> documentRequests { get; set; } = default!;


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    // Additional configuration if needed
        //}
    }
}
