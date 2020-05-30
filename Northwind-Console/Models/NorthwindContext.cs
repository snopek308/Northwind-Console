using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NorthwindConsole.Models
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("name=NorthwindContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        //I put the CRUD in here, and identified it below. This way, I was able to save the changes in a cleaner way
        //then I did in the previous Blog/Post. I repeated it in the Switch on Blog/Post. This time I tried to clean
        //up my code so I didn't do that


        //C-Create Categories
        public void addCategory(Category category)
        {
            this.Categories.Add(category);
            this.SaveChanges();
        }

        //C-Create Products
        public void addProduct(Product product)
        {
            this.Products.Add(product);
            this.SaveChanges();
        }

        //U-Update Categories
        public void EditCategory(Category UpdatedCategory)
        {
            Category category = this.Categories.Find(UpdatedCategory.CategoryId);
            category.CategoryName = UpdatedCategory.CategoryName;
            category.Description = UpdatedCategory.Description;
            this.SaveChanges();
        }

        //D-Delete Categories
        public void deleteCategory(Category category)
        {
            this.Categories.Remove(category);
            this.SaveChanges();
        }

        //D-Delete Products
        public void deleteProduct(Product product)
        {
            this.Products.Remove(product);
            this.SaveChanges();
        }
    }
}
