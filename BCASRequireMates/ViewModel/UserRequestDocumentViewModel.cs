using BCASRequireMates.Models;

namespace BCASRequireMates.ViewModel
{
    public class UserRequestDocumentViewModel
    {
        public int SelectedDocumentId { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
