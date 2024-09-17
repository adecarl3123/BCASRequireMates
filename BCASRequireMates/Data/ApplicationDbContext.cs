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
        
    }
}
