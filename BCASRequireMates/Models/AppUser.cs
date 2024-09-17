using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BCASRequireMates.Models
{
    public class AppUser : IdentityUser<int>
    {
        [Key]
        public int Id {  get; set; }
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}
