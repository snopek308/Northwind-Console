﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindConsole.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Must provide a Company name")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Please check your input")]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [Phone]
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
