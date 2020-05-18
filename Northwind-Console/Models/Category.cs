using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindConsole.Models
{
    public class Category
    {
        //code knows this is the primary key because it is named after the model + Id
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "YO - Enter the name!")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
