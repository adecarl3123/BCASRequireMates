using BCASRequireMates.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BCASRequireMates.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        
        {
            
        }
        public DbSet<BCASRequireMates.Models.Document> Document { get; set; } = default!;
        public DbSet<BCASRequireMates.Models.SubmitRequest> SubmitRequest { get; set; } = default!;
        
        
    }
}
