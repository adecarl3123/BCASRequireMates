namespace BCASRequireMates.Models
{
    public class UserDocumentRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to ApplicationUser
        public int DocumentId { get; set; } // Foreign key to Document
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // e.g., Pending, Approved, Rejected
        public Document Document { get; set; }
    }
}
