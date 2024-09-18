using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BCASRequireMates.Models
{
    public class AppUser : IdentityUser<int>
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}
