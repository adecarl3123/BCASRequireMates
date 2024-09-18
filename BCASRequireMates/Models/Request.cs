using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCASRequireMates.Models
{
    public enum RequestStatus
    {
        Pending,
        Accepted,
        OnProcess,
        Completed,
        Rejected
    }
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        [Required]
        public string PaymentReference { get; set; }

        public string Image { get; set; }
        

        //public int UserId { get; set; }
        public int AppUserId { get; set; } //Foreign Key
        [ForeignKey(nameof(AppUserId))]
        public AppUser? User { get; set; } // navigator

        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime RequestDate { get; set; }

        
    }
}
