using BCASRequireMates.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace BCASRequireMates.Models
{
    public class DocumentRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string YearLevel { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public List<DocumentItem> AvailableDocuments { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        //public IFormFile Image { get; set; }

        [Required]
        public string GcashReference { get; set; }

        public string Comments { get; set; }
    }
    
}
