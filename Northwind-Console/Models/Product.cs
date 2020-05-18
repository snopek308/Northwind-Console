using System;
using System.ComponentModel.DataAnnotations;

namespace NorthwindConsole.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Enter name Please")]
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "ENTER UNIT PRICE")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(-9999999999999999.99, 9999999999999999.99)]
        public decimal? UnitPrice { get; set; }
        [Required(ErrorMessage = "Enter Units in Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? UnitsOnOrder { get; set; }
        [Required(ErrorMessage = "Enter reorder level")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? ReorderLevel { get; set; }
        [Required(ErrorMessage = "Enter Y/N for Discontinued")]
        public bool Discontinued { get; set; }

        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
