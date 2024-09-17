using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Metrics;

namespace BCASRequireMates.Models
{
    public class SubmitRequest
    {
        [Key]
        public int Id { get; set; }
        public string  FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        [Required]
        public string PaymentReference { get; set; }

        public string Image { get; set; }
        public int UserId { get; set; }
        
        public AppUser? User { get; set; }

        


    }
}
