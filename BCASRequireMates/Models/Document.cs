using System.ComponentModel.DataAnnotations;

namespace BCASRequireMates.Models
{
    public class Document
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
