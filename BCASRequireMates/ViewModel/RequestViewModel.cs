﻿using System.ComponentModel.DataAnnotations;

namespace BCASRequireMates.ViewModel
{
    public class RequestViewModel
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

        public IFormFile? Photo { get; set; }
    }
}
