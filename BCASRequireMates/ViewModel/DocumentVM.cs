
using BCASRequireMates.Models;

namespace BCASRequireMates.ViewModel
{
    public class DocumentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YearLevel { get; set; }
        public string Phone { get; set; }

        // List of available documents, with quantity
        public List<DocumentItem> Documents { get; set; }

        public decimal TotalPrice { get; set; }
        //public IFormFile Image { get; set; }
        public string GcashReference { get; set; }
        public string Comments { get; set; }
    }

    public class DocumentItem
    {
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0; // Default quantity is 0
    }

}
