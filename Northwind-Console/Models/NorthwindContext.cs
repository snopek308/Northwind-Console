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
